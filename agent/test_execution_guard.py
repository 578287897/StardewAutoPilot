import copy
import unittest
from types import SimpleNamespace
from unittest.mock import Mock, patch

from autopilot import Agent
from execution_guard import ExecutionGuard
from game import GameError


class TestExecutionGuard(unittest.TestCase):
    def setUp(self):
        self.guard = ExecutionGuard()
        self.state = {"location": "Farm", "time": 900,
                      "inventory": [{"id": "ore", "stack": 4}],
                      "machines": [{"contains": None, "ready": False, "minutes_left": 0}]}
        self.load = {"type": "load_machines"}

    def test_empty_feedback_blocks_even_if_old_mod_reports_success(self):
        self.guard.observe(self.state, self.load, {
            "ok": True, "message": "no empty machine accepts anything in the backpack or the farm chests"})
        self.assertTrue(self.guard.blocked(self.state, self.load))
        self.assertFalse(self.guard.blocked(self.state, {"type": "collect_machines"}))

    def test_busy_waits_for_readiness_not_countdown(self):
        self.state["machines"][0].update(contains="Copper Bar", minutes_left=30)
        self.guard.observe(self.state, self.load, {"ok": False, "message": "all machines are busy"})
        self.state["machines"][0]["minutes_left"] = 10
        self.state["time"] = 1100
        self.assertTrue(self.guard.blocked(self.state, self.load))
        self.state["machines"][0]["ready"] = True
        self.assertFalse(self.guard.blocked(self.state, self.load))

    def test_new_materials_allow_another_attempt(self):
        self.guard.observe(self.state, self.load, {"ok": False, "message": "no machines on the farm"})
        self.assertTrue(self.guard.blocked(self.state, self.load))
        self.state["inventory"][0]["stack"] = 5
        self.assertFalse(self.guard.blocked(self.state, self.load))

    def test_generic_failure_budget_and_shop_recovery(self):
        action = {"type": "upgrade_tool", "tool": "pickaxe"}
        for _ in range(2):
            self.guard.observe(self.state, action, {"ok": False})
        self.assertTrue(self.guard.blocked(self.state, action))
        self.assertFalse(self.guard.blocked(self.state, {**action, "tool": "axe"}))
        self.state["time"] = 1000
        self.assertFalse(self.guard.blocked(self.state, action))

    def test_empty_collection_and_zero_road_are_not_progress(self):
        for kind, msg in (("collect_machines", "no machine has finished output"),
                          ("build_road", "laid 0 Cobblestone Path tiles")):
            action = {"type": kind}
            self.guard.observe(self.state, action, {"ok": True, "message": msg})
            self.assertTrue(self.guard.blocked(self.state, action))

    def test_transport_errors_do_not_poison_game_action(self):
        for _ in range(5):
            self.guard.observe(self.state, self.load, {"ok": False, "status": "AGENT_UNAVAILABLE"})
        self.assertFalse(self.guard.blocked(self.state, self.load))

    def test_success_reset_and_new_day(self):
        action = {"type": "decorate"}
        self.guard.observe(self.state, action, {"ok": False})
        self.guard.observe(self.state, action, {"ok": True})
        self.guard.observe(self.state, action, {"ok": False})
        self.assertFalse(self.guard.blocked(self.state, action))
        self.guard.observe(self.state, action, {"ok": False})
        self.assertTrue(self.guard.blocked(self.state, action))
        self.assertFalse(ExecutionGuard().blocked(self.state, action))

    def agent(self):
        agent = Agent.__new__(Agent)
        agent.day = SimpleNamespace(execution_guard=self.guard)
        agent._execute = Mock(return_value={"ok": False, "message": "no empty machine accepts anything"})
        return agent

    def test_executor_suppresses_explicit_script_repeats(self):
        agent = self.agent()
        agent.execute(self.state, self.load)
        for _ in range(100):
            self.assertEqual(agent.execute(self.state, self.load)["status"], "CIRCUIT_OPEN")
        agent._execute.assert_called_once()

    def test_old_mod_empty_success_is_reported_as_no_progress(self):
        agent = self.agent()
        agent._execute.return_value = {"ok": True, "message": "no machine has finished output"}
        result = agent.execute(self.state, {"type": "collect_machines"})
        self.assertFalse(result["ok"])
        self.assertEqual(result["status"], "NO_PROGRESS")

    @patch("autopilot.time.sleep")
    def test_busy_mod_does_not_receive_another_action(self, sleep):
        agent = self.agent()
        agent.step({"busy_action": "mine"})
        agent._execute.assert_not_called()
        sleep.assert_called_once_with(1)

    def test_transport_exception_is_classified(self):
        agent = self.agent()
        agent._execute.side_effect = GameError("connection lost")
        self.assertEqual(agent.execute(self.state, self.load)["status"], "AGENT_UNAVAILABLE")
        self.assertFalse(self.guard.blocked(self.state, self.load))

    def test_chest_mutation_reenables_loading(self):
        agent = self.agent()
        agent.execute(self.state, self.load)
        agent._execute.return_value = {"ok": True}
        agent.execute(self.state, {"type": "take", "item": "Coal"})
        self.assertFalse(self.guard.blocked(self.state, self.load))

    def test_blocked_step_does_not_trigger_replan(self):
        agent = self.agent()
        agent.execute(self.state, self.load)
        agent.day.script = [copy.deepcopy(self.load)]
        agent.day.script_total = 1
        agent.day.awaiting_script = False
        agent.day.steps = []
        agent.mode = "script"
        agent.guardrail = Mock(return_value=None)
        agent.record = Mock()
        agent.replan = Mock()
        agent.step(self.state)
        agent.replan.assert_not_called()
        agent._execute.assert_called_once()

    def test_time_filler_avoids_empty_load_but_keeps_ready_collection(self):
        agent = self.agent()
        agent.execute(self.state, self.load)
        agent.farm_plan = Mock(return_value=None)
        agent.day.fish_failed = True
        self.state["player"] = {"stamina": 100, "max_stamina": 270}
        self.assertEqual(agent.time_filler(self.state)["type"], "wait")
        self.state["machines"][0].update(ready=True, contains="Copper Bar")
        self.assertEqual(agent.time_filler(self.state)["type"], "collect_machines")


if __name__ == "__main__":
    unittest.main()
