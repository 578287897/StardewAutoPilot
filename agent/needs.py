"""What the game itself is asking for. The roadmap only fills in after these.

Mail, the festival step from the calendar, the community-center target from the
mod, a bundle we can already donate, and a tool upgrade whose cost the ladder says is met.
"""
import milestones


def _is_gold(item):
    name = str(item.get("item") or "")
    return name.endswith("g") and name[:-1].isdigit()


def _ready_bundle_items(bundles):
    """Item names the bundles API already counts as owned. Gold bundles are paid, not taken."""
    names = []
    for area in (bundles or {}).get("areas") or []:
        for bundle in area.get("bundles") or []:
            if bundle.get("complete"):
                continue
            for item in bundle.get("still_needed") or []:
                if _is_gold(item):
                    continue
                if item.get("owned", 0) >= item.get("count", 1) and item.get("item"):
                    names.append(str(item["item"]))
    return list(dict.fromkeys(names))


def _in_backpack(state, name):
    for it in (state or {}).get("inventory") or []:
        if it and it.get("name") == name and it.get("stack", 0) > 0:
            return True
    return False


def _as_step(raw):
    if not isinstance(raw, dict) or not raw.get("step"):
        return None
    advances = raw.get("advances") or []
    return {
        "name": raw.get("name") or "游戏要求",
        "step": [dict(action) for action in raw["step"]],
        "advances": set(advances),
        "at": raw.get("at") or "start",
    }


def immediate(progress, state=None, bundles=None, festival_in_days=0):
    """The requirement to do before the roadmap. festival_in_days=1 when planning tomorrow."""
    state = state or {}
    if state.get("unread_mail"):
        return {"name": "未读信件", "step": [{"type": "check_mail"}], "advances": {"check_mail"}, "at": "start"}
    for fest in state.get("festivals") or []:
        if fest.get("in_days") == festival_in_days:
            step = _as_step(fest)
            if step:
                return step
    target = None
    if isinstance(bundles, dict):
        target = bundles.get("current_target")
    if not target:
        target = state.get("community_center_target")
    found = _as_step(target)
    if found:
        return found
    stage = state.get("community_center") or ""
    # donate reads the backpack only. Owned counts include chests, so take those out first.
    # visit_wizard is a different stage; this branch runs only after canReadJunimoText.
    if stage.startswith("donate") or stage == "":
        ready = _ready_bundle_items(bundles)
        if ready:
            step = [{"type": "take", "item": name, "count": 1} for name in ready[:6] if not _in_backpack(state, name)]
            step.append({"type": "donate"})
            return {"name": "收集包里已经有的东西", "step": step,
                    "advances": {"take"} if len(step) > 1 else {"donate"}, "at": "start"}
    if isinstance(progress, dict):
        info = milestones.tool_upgrades(progress)
        step = info.get("step") if isinstance(info, dict) else []
        if step and step[0].get("type") == "upgrade_tool":
            return {"name": "工具升级要求已经够了", "step": step, "advances": {"upgrade_tool"}, "at": "before_sleep"}
    return None
