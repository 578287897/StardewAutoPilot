"""Smoke tests for script cleaning, milestone injection, and JSON parsing (stdlib only)."""
import unittest

import actions
import milestones
import needs
import prompts
import restart_decision
from llm import parse_json
from autopilot import Agent


class FakeAgent:
    """Minimal stand-in so we can call Agent helpers without a live game."""

    KNOWN_ACTIONS = actions.KNOWN_ACTIONS
    clean_script = Agent.clean_script
    enforce_milestone = staticmethod(Agent.enforce_milestone)
    is_minor_failure = staticmethod(Agent.is_minor_failure)


class TestActionsAndScripts(unittest.TestCase):
    def test_known_actions_include_house_and_macros(self):
        self.assertIn("upgrade_house", actions.KNOWN_ACTIONS)
        self.assertIn("store_items", actions.KNOWN_ACTIONS)
        self.assertEqual(actions.MACRO_EXPANDS_TO["store_items"], "store")

    def test_clean_script_filters_unknown_and_dialog(self):
        a = FakeAgent()
        raw = [
            {"type": "fish", "casts": 3},
            {"type": "dialog_advance"},
            {"type": "not_a_real_action"},
            "bad",
            {"type": "upgrade_house"},
        ]
        out = a.clean_script(raw)
        self.assertEqual([x["type"] for x in out], ["fish", "upgrade_house"])

    def test_clean_script_collapses_load_machines_spam(self):
        a = FakeAgent()
        raw = [
            {"type": "load_machines"},
            {"type": "load_machines"},
            {"type": "load_machines"},
            {"type": "fish", "casts": 2},
            {"type": "load_machines"},
        ]
        out = a.clean_script(raw)
        self.assertEqual([x["type"] for x in out], ["load_machines", "fish", "load_machines"])

    def test_clean_script_uses_mod_primitives_not_the_prompt(self):
        a = FakeAgent()
        raw = [
            {"type": "fish", "casts": 1},
            {"type": "upgrade_house"},
            {"type": "store_items"},
        ]
        self.assertIn("upgrade_house", prompts.ACTIONS_DOC)
        out = a.clean_script(raw, primitives=["fish", "sleep"])
        self.assertEqual([x["type"] for x in out], ["fish", "store_items"])

    def test_busy_furnace_does_not_block_later_loads(self):
        self.assertFalse(Agent.load_failure_blocks_filler(
            "all machines are busy; collect them when they finish"))
        self.assertFalse(Agent.load_failure_blocks_filler(
            "no empty machine accepts that, and the rest are busy; try again after they finish"))
        self.assertTrue(Agent.load_failure_blocks_filler(
            "no empty machine accepts anything in the backpack or the farm chests"))
        self.assertTrue(Agent.load_failure_blocks_filler("no machines on the farm"))

    def test_upgrade_and_weapon_are_not_minor_failures(self):
        self.assertFalse(FakeAgent.is_minor_failure({"type": "upgrade_tool", "tool": "pickaxe"}))
        self.assertFalse(FakeAgent.is_minor_failure({"type": "buy_weapon"}))
        self.assertTrue(FakeAgent.is_minor_failure({"type": "load_machines"}))

    def test_shop_hours_include_guild_and_saloon(self):
        locs = {loc: start for _, loc, start, _, _ in prompts.SHOP_HOURS}
        self.assertEqual(locs["Saloon"], 1200)
        self.assertEqual(locs["AdventureGuild"], 1400)
        self.assertEqual(locs["Blacksmith"], 900)

    def test_scarecrow_milestone_gathers_wood_before_craft(self):
        info = milestones.scarecrow({
            "placed": {}, "recipes": ["Scarecrow"],
            "materials": {"Wood": 20, "Coal": 5, "Fiber": 40},
        })
        self.assertEqual(info["step"][0]["type"], "clear_debris")
        self.assertNotIn("craft", info["advances"])

    def test_enforce_milestone_injects_house_upgrade(self):
        script = [{"type": "fish", "casts": 2}, {"type": "sleep"}]
        progress = {
            "materials": {"Wood": 500}, "money": 20000, "house_level": 0, "house_upgrade_days": 0,
            "placed": {}, "recipes": [], "buildings": [], "backpack": 24, "skills": {}, "tools": {},
            "gear": {"safe_depth": 80}, "deepest_mine": 80, "rod": "Fiberglass Rod", "bait": 10,
        }
        # Force house as current by marking earlier milestones done via evaluate path:
        # chest placed, backpack ok, furnace placed, scarecrow later/done, copper tools done, etc.
        progress["placed"] = {
            "Chest": 1, "Furnace": 1, "Scarecrow": 1, "Sprinkler": 4, "Preserves Jar": 4,
        }
        progress["tools"] = {"axe": 4, "pickaxe": 4, "watering_can": 4, "hoe": 4}
        progress["buildings"] = ["Coop", "Shed"]
        progress["skills"] = {"farming": 8, "fishing": 5}
        out = FakeAgent.enforce_milestone(script, progress)
        types = [a["type"] for a in out]
        self.assertIn("upgrade_house", types)
        self.assertEqual(types[-1], "sleep")

    def test_restart_only_when_the_model_says_yes_and_the_farmer_is_wedged(self):
        ok = {"ok": True, "action": {"type": "fish"}, "message": ""}
        bad = {"ok": False, "action": {"type": "sleep"}, "message": "exit to FarmHouse did not open"}
        self.assertFalse(restart_decision.wedged([bad, bad, ok]))
        self.assertTrue(restart_decision.wedged([bad, bad, bad, bad]))
        self.assertFalse(restart_decision.wants_restart({"restart": False}))
        self.assertFalse(restart_decision.wants_restart({"restart": "true"}))
        self.assertTrue(restart_decision.wants_restart({"restart": True}))
        self.assertTrue(restart_decision.cooldown_active("100", now=100 + 60))
        self.assertFalse(restart_decision.cooldown_active("100", now=100 + 1300))

    def test_game_requirement_comes_before_the_roadmap(self):
        progress = {"money": 2000, "tool_ladder": _ladder({"axe": 1, "pickaxe": 1, "watering_can": 0, "hoe": 0}, price=2000, amount=5, item="Copper Bar", owned=5)}
        need = needs.immediate(progress, {"unread_mail": 1, "festivals": []})
        self.assertEqual(need["step"][0]["type"], "check_mail")
        named = needs.immediate({"money": 0}, {"festivals": [{"in_days": 1, "name": "Luau", "location": "Beach"}]}, festival_in_days=1)
        self.assertIsNone(named)
        fest = needs.immediate(progress, {"festivals": [{
            "in_days": 1, "name": "Luau", "location": "Beach",
            "step": [{"type": "goto_location", "location": "Beach"}, {"type": "festival", "activity": "soup"}],
            "advances": ["festival"],
        }]}, festival_in_days=1)
        self.assertEqual(fest["step"][1]["activity"], "soup")
        self.assertIsNone(needs.immediate({}, {"community_center": "visit_wizard: go to the tower"}))
        wizard = needs.immediate({}, {"community_center_target": {
            "name": "Meet the Wizard",
            "step": [{"type": "goto_location", "location": "WizardHouse"}],
            "advances": ["goto_location"],
        }})
        self.assertEqual(wizard["step"][0]["location"], "WizardHouse")
        ready = needs.immediate(progress, {})
        self.assertEqual(ready["step"], [{"type": "upgrade_tool", "tool": "watering_can"}])

    def test_tool_upgrade_one_step_when_the_cost_is_met(self):
        short = {"money": 1912, "tool_ladder": _ladder(
            {"axe": 1, "pickaxe": 1, "watering_can": 0, "hoe": 0}, price=2000, amount=5, item="Copper Bar", owned=71)}
        info = milestones.tool_upgrades(short)
        # Bars are already owned. Short money is ship_produce, not a fishing trip:
        # a fish step must not count as progress toward the missing bars.
        self.assertEqual([a["type"] for a in info["step"]], ["ship_produce"])
        ready = {**short, "money": 2000}
        step = milestones.tool_upgrades(ready)
        self.assertEqual(step["step"], [{"type": "upgrade_tool", "tool": "watering_can"}])
        steel = {"money": 5000, "tool_ladder": _ladder(
            {"axe": 1, "pickaxe": 1, "watering_can": 1, "hoe": 1}, price=5000, amount=5, item="Iron Bar", owned=5, levels_offered=(1, 2))}
        self.assertEqual(milestones.tool_upgrades(steel)["step"], [{"type": "upgrade_tool", "tool": "axe"}])

    def test_tool_upgrade_reads_the_interface_ladder(self):
        self.assertFalse(hasattr(milestones, "TOOL_TIERS"))
        missing = milestones.tool_upgrades({"money": 999999, "materials": {"Iridium Bar": 99, "Copper Bar": 99}})
        self.assertEqual(missing, milestones.LATER)
        odd = {"money": 1234, "tool_ladder": _ladder(
            {"axe": 1, "pickaxe": 1, "watering_can": 1, "hoe": 1}, price=1234, amount=7, item="Custom Bar", owned=7, levels_offered=(1, 2))}
        self.assertEqual(milestones.tool_upgrades(odd)["step"], [{"type": "upgrade_tool", "tool": "axe"}])
        odd["money"] = 1233
        self.assertNotEqual(milestones.tool_upgrades(odd)["step"][0].get("type"), "upgrade_tool")
        done = {"money": 10**9, "tool_ladder": _ladder(
            {"axe": 2, "pickaxe": 2, "watering_can": 2, "hoe": 2}, price=999, amount=1, item="Custom Bar", owned=1, levels_offered=(1, 2))}
        self.assertIsNone(milestones.tool_upgrades(done))

    def test_second_furnace_waits_for_materials_then_crafts(self):
        base = {"placed": {"Furnace": 1}, "recipes": ["Furnace"], "materials": {"Copper Ore": 10, "Stone": 25}}
        self.assertEqual(milestones.second_furnace(base), milestones.LATER)
        ready = {"placed": {"Furnace": 1}, "recipes": ["Furnace"], "materials": {"Copper Ore": 20, "Stone": 25}}
        step = milestones.second_furnace(ready)
        self.assertEqual(step["step"][0]["item"], "Furnace")
        self.assertIsNone(milestones.second_furnace({**ready, "placed": {"Furnace": 2}}))

    def test_house_milestone_ready(self):
        info = milestones.house({
            "house_level": 0, "house_upgrade_days": 0, "money": 10000,
            "materials": {"Wood": 450},
        })
        self.assertEqual(info["step"][0]["type"], "upgrade_house")
        self.assertIn("upgrade_house", info["advances"])

    def test_house_milestone_in_progress(self):
        info = milestones.house({"house_level": 0, "house_upgrade_days": 2, "money": 0, "materials": {}})
        self.assertTrue(info["step"])
        self.assertIn("ship_produce", info["advances"])

    def test_parse_json_tolerates_fence(self):
        self.assertEqual(parse_json('```json\n{"a": 1}\n```')["a"], 1)
        self.assertEqual(parse_json('noise {"script":[]} trailing')["script"], [])


def _ladder(levels, price, amount, item, owned, levels_offered=(1,)):
    tools = []
    for key, current in levels.items():
        tools.append({
            "key": key,
            "held": True,
            "current_level": current,
            "max_level": max(levels_offered),
            "tiers": [
                {"level": level, "price": price, "trade_item_amount": amount, "trade_item_name": item,
                 "trade_item_display": item, "display_name": f"{item} {level}", "owned": owned}
                for level in levels_offered
            ],
        })
    return {"ok": True, "tools": tools, "upgrading": None}


if __name__ == "__main__":
    unittest.main()
