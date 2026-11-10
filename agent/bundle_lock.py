"""Community Center scroll locks. The boiler room note stays hidden until two bundles are done."""

# Same numbers as CommunityCenter.getNotePosition / shouldNoteAppearInArea.
AREA_INDEX = {
    "Pantry": 0,
    "Crafts Room": 1,
    "Fish Tank": 2,
    "Boiler Room": 3,
    "Vault": 4,
    "Bulletin Board": 5,
    "Abandoned Joja Mart": 6,
}

REASON_CLASS = {
    "BLOCKED": "temporary",
    "NO_WORK": "temporary",
    "CIRCUIT_OPEN": "do-not-retry",
    "FESTIVAL_BLOCKED": "needs-precondition",
    "BACKPACK_FULL": "needs-recovery",
    "BUNDLE_LOCKED": "needs-precondition",
}


def scroll_unlocked(area, complete_bundles, joja_seen=False):
    """Whether that room's Junimo scroll is visible. Area 1 is the crafts room."""
    if area == 1:
        return True
    if area in (0, 2):
        return complete_bundles > 0
    if area == 3:
        return complete_bundles > 1
    if area == 5:
        return complete_bundles > 2
    if area == 4:
        return complete_bundles > 3
    if area == 6:
        return bool(joja_seen)
    return False


def missing_precondition(area, complete_bundles):
    need = {0: 1, 2: 1, 3: 2, 5: 3, 4: 4}.get(area)
    if area == 6:
        return "see the abandoned Joja Mart event before that scroll appears"
    if not need:
        return ""
    return f"complete {need} other bundle(s) first (now {complete_bundles})"


def classify_block(reason_code):
    return REASON_CLASS.get(reason_code, "temporary")


def allow_repeat(reason_code, goal, precondition, seen):
    """False when this goal already failed and its precondition has not changed."""
    kind = classify_block(reason_code)
    if kind in ("needs-precondition", "do-not-retry") and (goal, str(precondition)) in seen:
        return False
    return True


def _held_names(inventory):
    names = set()
    for item in inventory or []:
        if item and item.get("name") and item.get("stack", 0) > 0 and "tool_level" not in item:
            names.add(item["name"])
    return names


def _complete_count(bundles):
    count = 0
    for area in (bundles or {}).get("areas") or []:
        for bundle in area.get("bundles") or []:
            if bundle.get("complete"):
                count += 1
    return count


def _bundle_items(bundle):
    items = []
    for item in bundle.get("still_needed") or []:
        name = str(item.get("item") or "")
        if name.endswith("g") and name[:-1].isdigit():
            continue
        items.append(name)
    return items


def decide(bundles, inventory, joja_seen=False):
    """None when a held item can go on a visible scroll. Otherwise one BUNDLE_LOCKED result."""
    held = _held_names(inventory)
    complete = _complete_count(bundles)
    locked = None
    next_goal = None
    next_partial = None
    for area in (bundles or {}).get("areas") or []:
        area_name = area.get("area") or ""
        index = AREA_INDEX.get(area_name)
        if index is None:
            continue
        unlocked = scroll_unlocked(index, complete, joja_seen)
        for bundle in area.get("bundles") or []:
            if bundle.get("complete"):
                continue
            if unlocked and next_partial is None and not str(bundle.get("slots") or "").startswith("0/"):
                next_partial = bundle.get("name")
            if unlocked and next_goal is None:
                next_goal = bundle.get("name")
            names = _bundle_items(bundle)
            if not any(name in held for name in names):
                continue
            if unlocked:
                return None
            if locked is None:
                locked = (bundle.get("name"), area_name, index, next(name for name in names if name in held))
    if locked is None:
        return None
    bundle, area_name, index, held_item = locked
    goal = next_partial or next_goal or ""
    missing = missing_precondition(index, complete)
    prompt = prompt_text(bundle, area_name, missing, held_item, goal, complete)
    return {
        "ok": False,
        "status": "BUNDLE_LOCKED",
        "reason_code": "BUNDLE_LOCKED",
        "class": "needs-precondition",
        "bundle": bundle,
        "area": area_name,
        "unlock": "locked",
        "holds_item": True,
        "item_belongs": True,
        "area_enterable": True,
        "missing": missing,
        "next_goal": goal,
        "precondition": f"complete_bundles={complete}",
        "message": (
            f"{bundle} scroll is locked ({missing}). {held_item} stays in the backpack. "
            f"Next visible bundle: {goal}."
        ),
        "prompt": prompt,
    }


def prompt_text(bundle, area, missing, held_item, next_goal, complete_bundles):
    """Text added to the existing replan prompt. It does not force the next script."""
    return (
        f"收集包卷轴还锁着，不要把这当成走路失败，也不要当成捐献失败。\n"
        f"{bundle}（{area}）：unlock=locked。{missing}。\n"
        f"背包里的 {held_item} 属于这个包，社区中心进得去，但这张卷轴还没出现。\n"
        f"已经能看见卷轴的下一个包：{next_goal}。\n"
        f"在 complete_bundles={complete_bundles} 没变之前，不要再对 {bundle} 执行 donate。"
    )
