import unittest
from types import SimpleNamespace
from unittest.mock import Mock

from autopilot import Agent
from travel import classify_presence, cutscene_hold, explain_route, festival_block

FEAST = [{
    "in_days": 0, "name": "Feast of the Winter Star", "location": "Town",
    "start": 900, "end": 1400, "id": "winter25",
}]


class TravelTests(unittest.TestCase):
    def test_feast_blocks_the_community_center_until_it_ends(self):
        reason = festival_block(FEAST, 910, "CommunityCenter")
        self.assertIn("Feast of the Winter Star", reason)
        self.assertIn("1400", reason)
        self.assertIsNone(festival_block(FEAST, 1500, "CommunityCenter"))
        setup = festival_block(FEAST, 800, "ArchaeologyHouse")
        self.assertIn("being set up", setup)
        self.assertIn("900", setup)
        self.assertIn("ArchaeologyHouse", setup)
        self.assertIsNone(festival_block(FEAST, 800, "Farm"))
        self.assertEqual(
            explain_route("no reachable route from Mountain to CommunityCenter (unreachable exits: mountain->town)", reason),
            "festival_map_limit")
        self.assertEqual(explain_route("no reachable route from Farm to WizardHouse", None), "real_unreachable")

    def test_temp_without_a_festival_event_is_not_a_restart(self):
        self.assertEqual(classify_presence({"location": "Temp", "event": True, "warping": True}), "temporary_map")
        self.assertEqual(classify_presence({"location": "Temp", "event": True, "menu": {"type": "DialogueBox"}}), "waiting_dialogue")
        self.assertEqual(classify_presence({"location": "Temp", "event": True, "event_festival": True}), "legal_festival")
        self.assertEqual(classify_presence({"location": "Temp", "event": True, "temp_stuck": True}), "stuck")
        stranded = {
            "location": "Temp", "event": True, "event_festival": False, "warping": True,
            "presence": "temporary_map", "time": 910,
            "player": {"x": 1, "y": 90, "free": False},
        }
        self.assertEqual(cutscene_hold(stranded), "stranded")
        self.assertIsNone(cutscene_hold({
            "location": "Temp", "event": True, "event_festival": True, "warping": False,
            "presence": "legal_festival", "player": {"free": True},
        }))
        self.assertEqual(cutscene_hold({"event": True, "location": "FarmHouse", "time": 1100}), "cutscene")
        self.assertEqual(cutscene_hold({
            "location": "Temp", "event": True, "event_festival": False, "warping": False,
            "player": {"free": False},
        }), "cutscene")
        agent = Agent.__new__(Agent)
        agent.mock = False
        agent.llm = Mock()
        agent.restart_declined = False
        agent.launch_restart = Mock()
        agent.consider_restart({"location": "Temp", "event": True, "temp_stuck": True, "festivals": FEAST})
        agent.launch_restart.assert_not_called()

    def test_donate_during_the_feast_does_not_spend_the_bar(self):
        agent = Agent.__new__(Agent)
        agent.dispatch = Mock()
        state = {"time": 910, "festivals": FEAST, "inventory": [{"name": "Copper Bar", "stack": 1}]}
        result = agent.festival_gate(state, {"type": "donate"})
        self.assertEqual(result["reason_code"], "FESTIVAL_BLOCKED")
        agent.dispatch.assert_not_called()
        self.assertEqual(state["inventory"][0]["stack"], 1)

    def test_refined_quartz_does_not_satisfy_a_quartz_take(self):
        agent = Agent.__new__(Agent)
        agent.day = SimpleNamespace(take_blocked=set())
        agent.safe = lambda call, default: {"inventory": [{"name": "Refined Quartz", "stack": 1}]}
        agent.block_take = Agent.block_take.__get__(agent, Agent)
        action = {"type": "take", "item": "80", "item_name": "Quartz"}
        result = {"ok": True, "message": "took 1x Refined Quartz from chest at (75,15)"}
        # The same check the executor uses: the taken display name must be the requested name.
        import re
        held = {"Refined Quartz"}
        expect = action["item_name"]
        taken = re.search(r"took \d+x (.+) from", result["message"]).group(1)
        self.assertNotEqual(taken.lower(), expect.lower())
        self.assertNotIn(expect, held)
