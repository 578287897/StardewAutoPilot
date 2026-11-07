"""Smoke tests for script cleaning, milestone injection, and JSON parsing (stdlib only)."""
import unittest

import actions
import milestones
import needs
import prompts
import wikitext
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

    def test_game_requirement_comes_before_the_roadmap(self):
        progress = {"money": 2000, "tools": {"axe": 1, "pickaxe": 1, "watering_can": 0, "hoe": 0},
                    "materials": {"Copper Bar": 5}, "placed": {"Furnace": 1}, "upgrading": None}
        need = needs.immediate(progress, {"unread_mail": 1, "festivals": []})
        self.assertEqual(need["step"][0]["type"], "check_mail")
        fest = needs.immediate(progress, {"festivals": [{"in_days": 1, "name": "Luau", "location": "Beach"}]}, festival_in_days=1)
        self.assertEqual(fest["step"][1]["activity"], "soup")
        ready = needs.immediate(progress, {})
        self.assertEqual(ready["step"], [{"type": "upgrade_tool", "tool": "watering_can"}])

    def test_tool_upgrade_one_step_when_the_cost_is_met(self):
        short = {"money": 1912, "tools": {"axe": 1, "pickaxe": 1, "watering_can": 0, "hoe": 0},
                 "materials": {"Copper Bar": 71}, "placed": {"Furnace": 1}, "upgrading": None}
        info = milestones.tool_upgrades(short)
        self.assertEqual([a["type"] for a in info["step"]], ["ship_produce", "fish"])
        ready = {**short, "money": 2000}
        step = milestones.tool_upgrades(ready)
        self.assertEqual(step["step"], [{"type": "upgrade_tool", "tool": "watering_can"}])
        steel = {"money": 5000, "tools": {"axe": 1, "pickaxe": 1, "watering_can": 1, "hoe": 1},
                 "materials": {"Iron Bar": 5}, "placed": {"Furnace": 1}, "upgrading": None}
        self.assertEqual(milestones.tool_upgrades(steel)["step"], [{"type": "upgrade_tool", "tool": "axe"}])

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


SAMPLE = """\
# comment
items\tcopper-pickaxe\t铜十字镐\tCopper Pickaxe\t矿井敲石头\t升级费用=2000g\t所需材料=铜锭（5）
items\tsteel-axe\t钢斧头\tSteel Axe\t清大圆木\t升级费用=5000g\t所需材料=铁锭（5）
items\tcopper-axe\t铜斧头\tCopper Axe\t清大树桩\t升级费用=2000g\t所需材料=铜锭（5）
"""


class TestWikiText(unittest.TestCase):
    def test_pickaxe_does_not_match_axe(self):
        rows = wikitext.parse(SAMPLE)
        pick = wikitext.search(rows, "pickaxe", limit=3)
        self.assertEqual([row["en"] for row in pick], ["Copper Pickaxe"])
        axe = wikitext.search(rows, "axe", limit=3)
        self.assertEqual([row["en"] for row in axe], ["Steel Axe", "Copper Axe"])

    def test_chinese_pickaxe_name_finds_copper_pickaxe(self):
        rows = wikitext.parse(SAMPLE)
        hit = wikitext.search(rows, "铜镐", limit=2)
        self.assertEqual(hit[0]["zh"], "铜十字镐")
        self.assertNotIn("斧", hit[0]["zh"])

    def test_downloaded_file_has_the_catalog(self):
        rows = wikitext.load()
        self.assertGreater(len(rows), 3000)
        copper = wikitext.search(rows, "Copper Pickaxe", limit=1)
        self.assertEqual(copper[0]["attrs"]["升级费用"], "2000g")
        self.assertIn("铜锭", copper[0]["attrs"]["所需材料"])


if __name__ == "__main__":
    unittest.main()
