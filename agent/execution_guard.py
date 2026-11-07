"""Daily circuit breakers for repeated work in an unchanged game state."""
import json


class ExecutionGuard:
    TRACKED = {"load_machines", "collect_machines", "build_road", "decorate",
               "upgrade_tool", "buy_weapon", "goto_location", "open_shop"}
    TIMED = {"upgrade_tool", "buy_weapon", "goto_location", "open_shop"}

    def __init__(self):
        self.failures = {}

    def key(self, state, action):
        kind = action.get("type")
        if kind not in self.TRACKED:
            return None
        # Countdown changes don't mean a machine can be used again. Readiness does.
        machines = [{k: v for k, v in m.items() if k != "minutes_left"}
                    for m in state.get("machines") or []]
        context = {"inventory": state.get("inventory"), "machines": machines,
                   "location": state.get("location"),
                   "money": state.get("player", {}).get("money")}
        if kind in self.TIMED:
            context["hour"] = state.get("time", 0) // 100
        return json.dumps([action, context], sort_keys=True, ensure_ascii=False)

    def blocked(self, state, action):
        return self.failures.get(self.key(state, action), 0) >= 2

    def observe(self, state, action, result):
        key = self.key(state, action)
        if key is None or result.get("status") == "AGENT_UNAVAILABLE":
            return
        kind = action.get("type")
        msg = str(result.get("message", "")).lower()
        empty = ((kind == "load_machines" and any(s in msg for s in
                  ("no empty machine accepts", "no machines", "all machines are busy")))
                 or (kind == "collect_machines" and "no machine has finished output" in msg)
                 or (kind == "build_road" and "laid 0 " in msg))
        if empty:
            self.failures[key] = 2
        elif not result.get("ok"):
            self.failures[key] = self.failures.get(key, 0) + 1
        else:
            self.failures.pop(key, None)
        return empty

    def invalidate(self):
        """A successful world/resource mutation can make previously empty work useful."""
        self.failures.clear()
