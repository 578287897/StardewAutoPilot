"""Festival maps, the Temp placeholder, and exact item names. No game connection."""

TOWN_DOORS = {
    "CommunityCenter", "Hospital", "SeedShop", "ArchaeologyHouse", "Blacksmith",
    "Saloon", "ManorHouse", "JoshHouse", "HaleyHouse", "SamHouse", "JojaMart",
}


def festival_block(festivals, time, destination):
    """A Town festival removes the Town map, including the community center door."""
    for festival in festivals or []:
        if festival.get("in_days") != 0:
            continue
        start = festival.get("start") or 0
        end = festival.get("end") or 0
        if time < start or time >= end:
            continue
        where = festival.get("location") or ""
        same = destination == where
        town_door = where == "Town" and destination in TOWN_DOORS
        if not same and not town_door:
            continue
        name = festival.get("name") or "festival"
        return (f"{name} occupies {where} from {start} until {end}; "
                f"{destination} has no door until that map returns")
    return None


def explain_route(message, block):
    if block:
        return "festival_map_limit"
    text = message or ""
    if "no reachable route" in text and "unreachable exits" in text:
        return "exit_failed"
    if "no reachable route" in text:
        return "real_unreachable"
    return "other"


def classify_presence(state):
    """Separate a legal event, a loading map, dialogue, and a Temp map that never finished."""
    menu = state.get("menu")
    menu_type = menu.get("type") if isinstance(menu, dict) else menu
    if menu_type in ("DialogueBox", "dialogue", "question"):
        return "waiting_dialogue"
    if state.get("warping"):
        return "temporary_map"
    event = bool(state.get("event"))
    if event and state.get("event_festival"):
        return "legal_festival"
    if state.get("location") == "Temp" and event:
        return "stuck" if state.get("temp_stuck") else "temporary_map"
    if state.get("location") == "Temp":
        return "temporary_map"
    if event:
        return "legal_cutscene"
    return "playing"
