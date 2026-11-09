"""What the game itself is asking for. The roadmap only fills in after these.

Mail, the festival step from the calendar, the community-center target from the
mod, a bundle we can already donate, and a tool upgrade whose cost the ladder says is met.
"""
import milestones


def _bundle_ready(bundles):
    for area in (bundles or {}).get("areas") or []:
        for bundle in area.get("bundles") or []:
            if bundle.get("complete"):
                continue
            needed = bundle.get("still_needed") or []
            if needed and all(item.get("owned", 0) >= item.get("count", 1) for item in needed if "g" not in str(item.get("item"))):
                return True
            if any(item.get("owned", 0) >= item.get("count", 1) and "g" not in str(item.get("item")) for item in needed):
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
    # wait_letter / visit_wizard are not "we already own a bundle item".
    if (stage.startswith("donate") or stage == "") and _bundle_ready(bundles):
        return {"name": "收集包里已经有的东西", "step": [{"type": "donate"}], "advances": {"donate"}, "at": "start"}
    if isinstance(progress, dict):
        info = milestones.tool_upgrades(progress)
        step = info.get("step") if isinstance(info, dict) else []
        if step and step[0].get("type") == "upgrade_tool":
            return {"name": "工具升级要求已经够了", "step": step, "advances": {"upgrade_tool"}, "at": "before_sleep"}
    return None
