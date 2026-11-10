"""Rules that decide whether a donation or a road start actually progressed."""


def donation_succeeded(result, before_count, after_count):
    """Opening a menu is not success. The live count has to move."""
    message = str((result or {}).get("message") or "")
    if "nothing could be deposited" in message or "nothing in the backpack" in message:
        return False
    if not (result or {}).get("ok"):
        return False
    return after_count > before_count


def museum_succeeded(result, before_donated, after_donated):
    message = str((result or {}).get("message") or "")
    if message.startswith("arrived at"):
        return False
    if not (result or {}).get("ok"):
        return False
    return after_donated > before_donated
