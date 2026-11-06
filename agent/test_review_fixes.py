"""Smoke tests for script cleaning, milestone injection, and JSON parsing (stdlib only)."""
import unittest

import actions
import milestones
from llm import parse_json
from autopilot import Agent


class FakeAgent:
    """Minimal stand-in so we can call Agent helpers without a live game."""

    KNOWN_ACTIONS = actions.KNOWN_ACTIONS
    clean_script = Agent.clean_script
    enforce_milestone = staticmethod(Agent.enforce_milestone)


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
        progress["tools"] = {"axe": 1, "pickaxe": 1}
        progress["buildings"] = ["Coop", "Shed"]
        progress["skills"] = {"farming": 8, "fishing": 5}
        out = FakeAgent.enforce_milestone(script, progress)
        types = [a["type"] for a in out]
        self.assertIn("upgrade_house", types)
        self.assertEqual(types[-1], "sleep")

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


if __name__ == "__main__":
    unittest.main()
