"""What the game itself is asking for. The roadmap only fills in after these.

Mail, today's or tomorrow's festival, the community-center step, a bundle we can
already donate, and a tool upgrade whose cost is already paid for.
"""
import milestones


def _festival_activity(name):
    text = name or ""
    low = text.lower()
    if "luau" in low or "宴会" in text:
        return "soup"
    if "fair" in low or "展览" in text:
        return "grange"
    if "flower" in low or "花舞" in text:
        return "dance"
    return "start"


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


def immediate(progress, state=None, bundles=None, festival_in_days=0):
    """The requirement to do before the roadmap. festival_in_days=1 when planning tomorrow."""
    state = state or {}
    if state.get("unread_mail"):
        return {"name": "未读信件", "step": [{"type": "check_mail"}], "advances": {"check_mail"}, "at": "start"}
    for fest in state.get("festivals") or []:
        if fest.get("in_days") == festival_in_days and fest.get("location"):
            activity = _festival_activity(fest.get("name"))
            return {
                "name": fest.get("name") or "节日",
                "step": [
                    {"type": "goto_location", "location": fest["location"]},
                    {"type": "festival", "activity": activity},
                ],
                "advances": {"festival"},
                "at": "start",
            }
    stage = state.get("community_center") or ""
    if stage.startswith("enter_cc"):
        return {"name": "进入社区中心", "step": [{"type": "goto_location", "location": "CommunityCenter"}],
                "advances": {"goto_location"}, "at": "start"}
    if stage.startswith("visit_wizard"):
        return {"name": "找法师读祝尼魔文字", "step": [{"type": "goto_location", "location": "WizardHouse"}],
                "advances": {"goto_location"}, "at": "start"}
    if _bundle_ready(bundles):
        return {"name": "收集包里已经有的东西", "step": [{"type": "donate"}], "advances": {"donate"}, "at": "start"}
    if isinstance(progress, dict):
        info = milestones.tool_upgrades(progress)
        step = (info or {}).get("step") or []
        if step and step[0].get("type") == "upgrade_tool":
            return {"name": "工具升级要求已经够了", "step": step, "advances": {"upgrade_tool"}, "at": "before_sleep"}
    return None
