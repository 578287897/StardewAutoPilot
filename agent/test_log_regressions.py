import unittest
from types import SimpleNamespace
from unittest.mock import Mock

from autopilot import Agent
from execution_guard import ExecutionGuard


class LogRegressionTests(unittest.TestCase):
    def test_fishing_movement_and_money_do_not_restart_farm_jobs(self):
        for kind, message in (("build_road", "laid 0 Cobblestone Path tiles"),
                              ("decorate", "missing materials")):
            guard = ExecutionGuard()
            state = {"inventory": [{"id": "(O)390", "stack": 5}], "location": "Farm"}
            action = {"type": kind}
            for _ in range(2):
                guard.observe(state, action, {"ok": False, "message": message})
            state.update(location="FarmHouse", time=1500, player={"money": 500})
            state["inventory"].append({"id": "(O)168", "stack": 1})
            self.assertTrue(guard.blocked(state, {**action, "reason": "try again"}))
            guard.invalidate()
            self.assertTrue(guard.blocked(state, action))
            state["inventory"][0]["stack"] += 1
            self.assertFalse(guard.blocked(state, action))

    def test_existing_paths_work_without_a_craftable_recipe(self):
        agent = Agent.__new__(Agent)
        agent.day = SimpleNamespace(road_skip=set())
        agent.ensure_farm_plan = Mock(return_value={"plaza": [[0, 0]], "roads": []})
        agent.game = Mock()
        agent.game.farm_grid.return_value = {"rows": ["."]}
        agent.game.recipes.return_value = []
        agent.safe = lambda call, default: call()
        result = {"ok": True, "message": "laid 1 Cobblestone Path tiles"}
        agent.game.act.return_value = result
        agent.dispatch = Mock(return_value=result)
        agent.act_and_record = Mock()
        self.assertTrue(agent.build_road({"inventory": [
            {"name": "Cobblestone Path", "stack": 1}]})["ok"])
        agent.act_and_record.assert_not_called()
        calls = agent.dispatch.call_args_list or agent.game.act.call_args_list
        self.assertEqual(calls[0].args[-1]["item"], "Cobblestone Path")
