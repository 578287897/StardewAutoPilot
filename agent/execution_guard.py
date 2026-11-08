"""Reason-specific daily circuit breakers; unrelated actions never clear all failures."""
import json


class ExecutionGuard:
    TRACKED = {"load_machines", "collect_machines", "build_road", "decorate", "lay_path",
               "upgrade_tool", "buy_weapon", "goto_location", "open_shop", "buy", "craft", "place"}
    TIMED = {"upgrade_tool", "buy_weapon", "open_shop", "buy"}
    TRANSPORT = {"AGENT_UNAVAILABLE", "ACTION_UNCERTAIN", "ACTION_RECOVERED"}

    def __init__(self):
        self.failures = {}

    @staticmethod
    def identity(action):
        return json.dumps({k: v for k, v in action.items() if k not in
                           ("request_id", "thought", "reason", "filler", "supplemental", "work_exhausted")}, sort_keys=True, ensure_ascii=False)

    def key(self, state, action, timed=False):
        kind = action.get("type")
        if kind not in self.TRACKED:
            return None
        context = {}
        inventory = [{k: i.get(k) for k in ("id", "stack", "quality", "tool_level")}
                     for i in state.get("inventory", []) if i]
        inventory.sort(key=lambda value: json.dumps(value, sort_keys=True))
        resources = state.get("farm_resources", inventory)
        if kind in ("load_machines", "collect_machines"):
            context["machines"] = [{k: v for k, v in m.items() if k != "minutes_left"}
                                   for m in state.get("machines") or []]
            context["machines"].sort(key=lambda value: json.dumps(value, sort_keys=True))
            if kind == "load_machines":
                # The Mod computes this from each machine's current acceptance probe.
                context["resources"] = state.get("machine_inputs", resources)
        elif kind in ("build_road", "decorate"):
            context.update(resources=state.get("work_dependencies", {}).get(kind, resources),
                           revision=state.get("farm_revision", 0), season=state.get("season"))
        elif kind == "goto_location":
            context.update(location=state.get("location"), exits=state.get("exits"),
                           revision=state.get("route_revision", 0))
        elif kind in ("upgrade_tool", "buy_weapon", "buy", "open_shop"):
            context.update(location=state.get("location"), money=state.get("player", {}).get("money"),
                           resources=resources, upgrading=state.get("upgrading"))
        else:
            context.update(resources=resources, revision=state.get("farm_revision", 0))
        if timed:
            context["hour"] = state.get("time", 0) // 100
        return json.dumps(context, sort_keys=True, ensure_ascii=False)

    def blocked(self, state, action):
        entry = self.failures.get(self.identity(action))
        return bool(entry and entry["count"] >= 2
                    and entry["state"] == self.key(state, action, entry["timed"]))

    def observe(self, state, action, result):
        kind = action.get("type")
        if kind not in self.TRACKED or result.get("status") in self.TRANSPORT:
            return False
        identity = self.identity(action)
        msg = str(result.get("message", "")).lower()
        measured = result.get("progress_count")
        reason = result.get("reason_code")
        empty = measured == 0 or reason in {"MISSING_MATERIALS", "NO_WORK", "BLOCKED", "MACHINES_BUSY"}
        # Compatibility with older Mods that don't supply structured feedback.
        empty = empty or ((kind == "load_machines" and any(s in msg for s in
                  ("no empty machine accepts", "no machines", "all machines are busy")))
                 or (kind == "collect_machines" and "no machine has finished output" in msg)
                 or (kind in ("build_road", "lay_path") and "laid 0 " in msg))
        if result.get("ok") and not empty:
            self.failures.pop(identity, None)
            return False
        timed = kind in self.TIMED or (kind == "goto_location" and any(s in msg for s in
                    ("locked", "closed", "open at", "opens", "festival")))
        key = self.key(state, action, timed)
        previous = self.failures.get(identity, {})
        count = previous.get("count", 0) if previous.get("state") == key else 0
        self.failures[identity] = {"state": key, "timed": timed, "count": 2 if empty else count + 1}
        return empty

    def invalidate(self):
        """Legacy chest mutations only re-enable machine loading."""
        for identity in list(self.failures):
            if json.loads(identity).get("type") == "load_machines":
                del self.failures[identity]
