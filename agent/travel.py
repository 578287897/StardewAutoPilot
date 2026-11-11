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
        # Before the start the game already refuses the door. Walking in as the clock
        # hits the start is what leaves the farmer on the Temp map.
        if time >= end:
            continue
        where = festival.get("location") or ""
        same = destination == where
        town_door = where == "Town" and destination in TOWN_DOORS
        if not same and not town_door:
            continue
        name = festival.get("name") or "festival"
        if time < start:
            return (f"{name} is being set up in {where} until {start}; "
                    f"{destination} has no door yet")
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


def cutscene_hold(state):
    """Why the agent should wait, or None when it should keep acting.

    A playable festival (the player can walk, the warp fade is gone) is not a cutscene
    that ends by itself: the clock stays stopped until someone leaves or starts it.
    A Temp map that is still an event, or still fading, will not end either. The mod
    sends the farmer home; this only stops the agent from treating that as a normal cutscene.
    """
    if not (state.get("event") or state.get("location") == "Temp"):
        return None
    kind = state.get("presence") or classify_presence(state)
    player = state.get("player") or {}
    free = bool(player.get("free")) and not state.get("warping")
    if kind == "legal_festival" and free:
        return None
    if kind == "stuck":
        return "stuck"
    if kind == "legal_festival":
        return "festival"
    if kind == "waiting_dialogue":
        return "dialogue"
    # A story cutscene on Temp still ends (the mod force-skips it). A stuck fade, or a
    # festival the farmer cannot walk yet, does not.
    if state.get("location") == "Temp" and state.get("event") and (
            state.get("warping") or (state.get("event_festival") and not player.get("free"))):
        return "stranded"
    return "cutscene"


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
