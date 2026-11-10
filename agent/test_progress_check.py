import unittest
from types import SimpleNamespace
from unittest.mock import Mock

from autopilot import Agent
from progress_check import donation_succeeded, museum_succeeded


class DonationProgressTests(unittest.TestCase):
    def test_opening_the_bundle_menu_is_not_success(self):
        result = {"ok": True, "message": "opened the bundles but nothing could be deposited"}
        self.assertFalse(donation_succeeded(result, 50, 50))

    def test_bundle_success_requires_the_owned_count_to_fall_or_progress_to_rise(self):
        # owned-in-chest stays high; the deposited stack is the progress_count the caller compares.
        result = {"ok": True, "message": "donated: 1x Copper Bar -> Blacksmith's"}
        self.assertFalse(donation_succeeded(result, 0, 0))
        self.assertTrue(donation_succeeded(result, 0, 1))

    def test_walking_into_the_museum_is_not_a_donation(self):
        result = {"ok": True, "message": "arrived at ArchaeologyHouse (3,14)"}
        self.assertFalse(museum_succeeded(result, 0, 0))

    def test_museum_success_requires_the_donated_count(self):
        result = {"ok": True, "message": "donated Dwarf Scroll I (96) to the museum at (12,5)"}
        self.assertFalse(museum_succeeded(result, 0, 0))
        self.assertTrue(museum_succeeded(result, 0, 1))

    def test_a_failed_deposit_does_not_count_a_second_removal(self):
        result = {"ok": False, "message": "opened the bundles but nothing could be deposited"}
        self.assertFalse(donation_succeeded(result, 1, 1))
        self.assertFalse(donation_succeeded(result, 1, 0))


class BackpackTests(unittest.TestCase):
    def test_full_backpack_stores_non_goal_items_then_rereads_slots(self):
        agent = Agent.__new__(Agent)
        agent.items_to_hold = lambda st: {"Copper Bar"}
        agent.game = SimpleNamespace(state=lambda: {"inventory_free_slots": 5})
        agent.store_items = Mock(return_value={"ok": True, "request_id": "store-1"})
        agent.record = Mock()
        agent.safe = lambda call, default: call()
        st = {"inventory_free_slots": 0, "inventory": [
            {"name": "Copper Bar", "stack": 1},
            {"name": "Stone", "stack": 20, "category": "Resource"},
            {"name": "Dwarf Scroll I", "stack": 1, "category": "Artifact"},
        ]}
        after, blocked = agent.ensure_backpack(st, 5)
        self.assertIsNone(blocked)
        self.assertEqual(agent.store_items.call_args.args[1]["items"], ["Stone"])
        self.assertEqual(after["inventory_free_slots"], 5)

    def test_only_goal_items_left_is_an_explicit_blocker(self):
        agent = Agent.__new__(Agent)
        agent.items_to_hold = lambda st: {"Copper Bar"}
        agent.store_items = Mock()
        st = {"inventory_free_slots": 0, "inventory": [{"name": "Copper Bar", "stack": 1}]}
        _, blocked = agent.ensure_backpack(st, 1)
        self.assertEqual(blocked["reason_code"], "BACKPACK_FULL")
        agent.store_items.assert_not_called()

    def test_take_failure_is_not_retried(self):
        agent = Agent.__new__(Agent)
        agent.day = SimpleNamespace(take_blocked=set())
        action = {"type": "take", "item": "Diamond"}
        agent.block_take(action)
        self.assertTrue(agent.take_is_blocked(action))
        self.assertTrue(agent.take_is_blocked({"type": "take", "item": "diamond"}))
