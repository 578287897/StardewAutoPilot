"""Single source of truth for action type names used by the Python agent.

Mod primitives (POST /act) live in ActionRunner.ActionTypes.
Agent macros are expanded in autopilot.execute before calling the mod:

  store_items  -> store (+ optional craft/place Chest)
  build_road   -> craft flooring + lay_path (+ lights)
  decorate     -> place trees / fences / flowers per farm plan
"""

# Types the nightly script / replan may emit (macros + primitives the agent forwards).
KNOWN_ACTIONS = {
    "move_to", "goto_location", "use_tool", "interact", "place", "select", "eat", "ship", "ship_produce",
    "open_shop", "buy", "dialog_answer", "dialog_advance", "menu_click", "choose_profession", "close_menu",
    "wait", "sleep", "check_mail", "water_crops", "harvest_crops", "clear_debris", "plant_seeds", "forage",
    "craft", "store", "take", "store_items", "fish", "mine", "leave_mine", "fight", "donate", "donate_museum",
    "build", "buy_animal", "care_animals", "clear_area", "load_machines", "collect_machines", "cook",
    "buy_backpack", "buy_weapon", "build_road", "upgrade_tool", "upgrade_house", "decorate", "festival",
}

# Expanded only on the agent side; the mod never accepts these names.
AGENT_MACROS = {"store_items", "build_road", "decorate"}

# Corresponding mod endpoints for macros (documentation / tests).
MACRO_EXPANDS_TO = {
    "store_items": "store",
    "build_road": "lay_path",
    "decorate": "place",
}
