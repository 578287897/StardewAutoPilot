import unittest
from types import SimpleNamespace

import bundle_lock
from autopilot import Agent
from needs import immediate


def bundles(complete_names=()):
    crafts = [
        {"name": "Construction", "complete": "Construction" in complete_names, "slots": "1/4",
         "still_needed": [{"item": "Wood", "count": 99, "owned": 10}]},
        {"name": "Spring Foraging", "complete": False, "slots": "0/4",
         "still_needed": [{"item": "Wild Horseradish", "count": 1, "owned": 0}]},
    ]
    boiler = [
        {"name": "Blacksmith's", "complete": False, "slots": "0/3",
         "still_needed": [
             {"item": "Copper Bar", "count": 1, "owned": 50},
             {"item": "Iron Bar", "count": 1, "owned": 0},
             {"item": "Gold Bar", "count": 1, "owned": 0},
         ]},
    ]
    return {"areas": [
        {"area": "Crafts Room", "bundles": crafts},
        {"area": "Boiler Room", "bundles": boiler},
    ]}


class BundleLockTests(unittest.TestCase):
    def test_blacksmith_is_locked_until_two_bundles_are_complete(self):
        decision = bundle_lock.decide(bundles(), [{"name": "Copper Bar", "stack": 1}])
        self.assertEqual(decision["reason_code"], "BUNDLE_LOCKED")
        self.assertEqual(decision["bundle"], "Blacksmith's")
        self.assertEqual(decision["unlock"], "locked")
        self.assertIn("complete 2 other bundle", decision["missing"])
        self.assertEqual(decision["next_goal"], "Construction")
        self.assertTrue(decision["holds_item"])
        self.assertTrue(decision["item_belongs"])
        self.assertTrue(decision["area_enterable"])
        self.assertNotIn("no reachable route", decision["message"])
        self.assertNotIn("nothing could be deposited", decision["message"])
        self.assertIn("不要再对 Blacksmith's 执行 donate", decision["prompt"])

    def test_two_complete_bundles_open_the_boiler_scroll(self):
        opened = bundles(("Construction", "Spring Foraging"))
        opened["areas"][0]["bundles"][1]["complete"] = True
        self.assertIsNone(bundle_lock.decide(opened, [{"name": "Copper Bar", "stack": 1}]))

    def test_an_unlocked_scroll_is_not_reported_as_locked(self):
        pack = [{"name": "Wild Horseradish", "stack": 1}, {"name": "Copper Bar", "stack": 1}]
        self.assertIsNone(bundle_lock.decide(bundles(), pack))

    def test_the_same_locked_donate_is_not_repeated(self):
        agent = Agent.__new__(Agent)
        agent.day = SimpleNamespace(bundle_seen=set(), bundle_prompt="")
        agent.safe = lambda call, default: bundles()
        agent.game = SimpleNamespace(bundles=lambda: bundles())
        state = {"inventory": [{"name": "Copper Bar", "stack": 1}]}
        first = agent.bundle_lock_gate(state)
        second = agent.bundle_lock_gate(state)
        self.assertEqual(first["status"], "BUNDLE_LOCKED")
        self.assertEqual(second["status"], "CIRCUIT_OPEN")
        self.assertEqual(second["class"], "do-not-retry")
        self.assertEqual(state["inventory"][0]["stack"], 1)

    def test_locked_blacksmith_does_not_overwrite_the_script(self):
        state = {"community_center": "donate: can donate", "inventory": [{"name": "Copper Bar", "stack": 1}]}
        self.assertIsNone(immediate({}, state, bundles()))

    def test_block_classes_and_repeat_rule(self):
        self.assertEqual(bundle_lock.classify_block("BLOCKED"), "temporary")
        self.assertEqual(bundle_lock.classify_block("NO_WORK"), "temporary")
        self.assertEqual(bundle_lock.classify_block("CIRCUIT_OPEN"), "do-not-retry")
        self.assertEqual(bundle_lock.classify_block("FESTIVAL_BLOCKED"), "needs-precondition")
        self.assertEqual(bundle_lock.classify_block("BACKPACK_FULL"), "needs-recovery")
        self.assertEqual(bundle_lock.classify_block("BUNDLE_LOCKED"), "needs-precondition")
        seen = {("Blacksmith's", "complete_bundles=0")}
        self.assertFalse(bundle_lock.allow_repeat("BUNDLE_LOCKED", "Blacksmith's", "complete_bundles=0", seen))
        self.assertTrue(bundle_lock.allow_repeat("BUNDLE_LOCKED", "Blacksmith's", "complete_bundles=2", seen))
        self.assertTrue(bundle_lock.allow_repeat("BACKPACK_FULL", "mine", "free=1", seen))
