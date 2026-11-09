import unittest
from types import SimpleNamespace
from unittest.mock import Mock

from autopilot import Agent
from execution_guard import ExecutionGuard
from llm import LLMError


class LogRegressionTests(unittest.TestCase):
    def test_fishing_movement_and_money_do_not_restart_farm_jobs(self):
        for kind, message in (("build_road", "laid 0 Cobblestone Path tiles"),
                              ("decorate", "missing materials")):
            guard = ExecutionGuard()
            state = {"inventory": [{"id": "(O)390", "stack": 5}], "location": "Farm"}
            state["work_dependencies"] = {kind: {"stone": 5}}
            action = {"type": kind}
            for _ in range(2):
                guard.observe(state, action, {"ok": False, "message": message})
            state.update(location="FarmHouse", time=1500, player={"money": 500})
            state["inventory"].append({"id": "(O)168", "stack": 1})
            self.assertTrue(guard.blocked(state, {**action, "reason": "try again"}))
            guard.invalidate()
            self.assertTrue(guard.blocked(state, action))
            state["work_dependencies"][kind]["stone"] += 1
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


class RecoveryAndPlanningTests(unittest.TestCase):
    def agent(self):
        agent = Agent.__new__(Agent)
        agent.game = Mock(pending=None)
        agent.day = SimpleNamespace(script=[], script_total=0, shipped_value=0, ended=False,
                                    execution_guard=ExecutionGuard())
        agent.mode = "script"
        agent.safe = lambda call, default: call()
        agent.game.progress.return_value = {}
        agent.game.bundles.return_value = {}
        agent.game.recipes.return_value = []
        agent.replan = Mock()
        return agent

    def test_unsent_task_is_retained(self):
        agent = self.agent()
        action = {"type": "upgrade_tool", "tool": "axe"}
        agent.preserve_interrupted(action, {"status": "AGENT_UNAVAILABLE", "dispatched": False})
        self.assertEqual(agent.day.script, [action])

    def test_uncertain_purchase_is_saved_not_requeued(self):
        agent = self.agent()
        agent.game.pending = {"action": {"type": "buy", "request_id": "id"}}
        original = {"type": "decorate"}
        agent.preserve_interrupted(original, {"status": "ACTION_UNCERTAIN"})
        self.assertEqual(agent.day.script, [])
        self.assertEqual(agent.game.pending["script_action"], original)
        agent.game._save_pending.assert_called_once()

    def test_completed_purchase_is_not_replayed(self):
        agent = self.agent()
        agent.resume_recovered({"ready": True}, {"action": {"type": "buy"}, "result": {"ok": True}})
        agent.replan.assert_not_called()
        self.assertEqual(agent.day.script, [])

    def test_interrupted_macro_replans_remaining_work(self):
        agent = self.agent()
        agent.resume_recovered({"ready": True}, {"action": {"type": "craft"},
            "script_action": {"type": "decorate"}, "result": {"ok": True}})
        agent.replan.assert_called_once()

    def test_uncertain_sleep_after_pass_out_does_not_block_the_morning(self):
        agent = self.agent()
        agent.record = Mock()
        agent.game.pending = {"action": {"type": "sleep", "request_id": "abc"}}
        agent.game._save_pending = Mock()
        st = {"ready": True, "time": 610, "location": "FarmHouse"}
        recovery = {"state": "uncertain", "action": {"type": "sleep", "request_id": "abc"},
                    "result": {"ok": False, "status": "ACTION_UNCERTAIN",
                               "message": "player is busy (usingTool=False, eating=False, warping=True, fade=False)",
                               "after": {"location": "FarmHouse", "time": 610, "money": 16512}}}
        self.assertTrue(agent.release_resolved_sleep(st, recovery))
        self.assertIsNone(agent.game.pending)
        agent.game._save_pending.assert_called_once()
        agent.record.assert_called_once()
        purchase = {"state": "uncertain", "action": {"type": "upgrade_tool"},
                    "result": {"ok": False, "status": "ACTION_UNCERTAIN", "after": {"location": "Blacksmith", "time": 900}}}
        agent.game.pending = {"action": {"type": "upgrade_tool"}}
        self.assertFalse(agent.release_resolved_sleep(st, purchase))
        self.assertIsNotNone(agent.game.pending)

    def test_recovered_sleep_finishes_day(self):
        agent = self.agent()
        agent.on_went_to_sleep = Mock()
        agent.resume_recovered({}, {"action": {"type": "sleep"}, "result": {"ok": True}})
        self.assertTrue(agent.day.ended)
        agent.on_went_to_sleep.assert_called_once()

    def test_modded_recipe_materials_unblock_work_but_junk_does_not(self):
        agent = self.agent()
        agent.game.recipes.return_value = [{"name": "Cobblestone Path", "ingredient_ids": ["Mod.Stone"],
            "output_id": "(O)Mod.Path", "can_make": 0}]
        state = {"farm_items": [{"id": "(O)Mod.Stone", "stack": 1}], "farm_resources": {}}
        action = {"type": "build_road"}
        before = agent.work_state(state, action)
        agent.day.execution_guard.observe(before, action, {"ok": False, "progress_count": 0})
        state["farm_items"].append({"id": "(O)168", "stack": 10})
        self.assertTrue(agent.day.execution_guard.blocked(agent.work_state(state, action), action))
        state["farm_items"][0]["stack"] = 5
        self.assertFalse(agent.day.execution_guard.blocked(agent.work_state(state, action), action))

    def test_zero_progress_blocks_without_matching_message(self):
        agent = self.agent()
        action = {"type": "decorate"}
        agent.day.execution_guard.observe({}, action, {"ok": True, "progress_count": 0, "message": "translated"})
        self.assertTrue(agent.day.execution_guard.blocked({}, action))

    def test_winter_outing_runs_once_then_stops(self):
        agent = self.agent()
        agent.game.progress.return_value = {"gear": {"safe_depth": 20}}
        state = {"time": 900, "season": "winter", "player": {"stamina": 200, "max_stamina": 270}}
        self.assertEqual(agent.supplemental_work(state)["type"], "mine")
        self.assertIsNone(agent.supplemental_work(state))

    def test_no_work_sleeps_and_machine_deadline_waits(self):
        agent = self.agent()
        agent.supplemental_work = Mock(return_value=None)
        agent.farm_plan = Mock(return_value=None)
        state = {"time": 900, "machines": []}
        self.assertTrue(agent.time_filler(state)["work_exhausted"])
        state["machines"] = [{"contains": "Bar", "minutes_left": 30}]
        self.assertEqual(agent.time_filler(state), {"type": "wait", "minutes": 30, "filler": True})

    def test_low_health_cancels_queued_outing(self):
        agent = self.agent()
        agent.day.supplemental_jobs = set()
        agent.day.supplemental_queue = [{"type": "mine"}]
        self.assertIsNone(agent.supplemental_work({"player": {"health": 10}}))
        self.assertEqual(agent.day.supplemental_queue, [])

    def test_original_macro_is_durable_before_post(self):
        from game import Game, GameError
        game = Game()
        game.receipts_supported = True
        game.script_action = {"type": "decorate"}
        saved = []
        game._save_pending = lambda: saved.append(dict(game.pending))
        def fail_post(*args):
            self.assertEqual(saved[0]["script_action"], {"type": "decorate"})
            raise GameError("lost response")
        game._request = fail_post
        with self.assertRaises(GameError):
            game.act({"type": "craft", "item": "Wood Fence"})
        self.assertIsNotNone(game.pending)

    def test_legacy_resources_are_conservative(self):
        guard = ExecutionGuard()
        action = {"type": "build_road"}
        state = {"farm_resources": {"(O)Mod.Stone": 1}}
        guard.observe(state, action, {"ok": False, "progress_count": 0})
        state["farm_resources"]["(O)Mod.Stone"] = 2
        self.assertFalse(guard.blocked(state, action))


class ReviewAuthRetryTests(unittest.TestCase):
    def test_review_json_reloads_key_after_401(self):
        agent = Agent.__new__(Agent)
        agent.review_llm = Mock()
        agent.review_llm.chat_json.side_effect = [
            LLMError('auth failed (401): api key not found'),
            {"analysis": "ok"},
        ]
        agent.try_init_llm = Mock(return_value=True)
        self.assertEqual(agent.review_json([{"role": "user", "content": "x"}]), {"analysis": "ok"})
        agent.try_init_llm.assert_called_once()
        self.assertEqual(agent.review_llm.chat_json.call_count, 2)

    def test_review_json_explains_persistent_401(self):
        agent = Agent.__new__(Agent)
        agent.review_llm = Mock()
        agent.review_llm.chat_json.side_effect = LLMError('auth failed (401): api key not found')
        agent.try_init_llm = Mock(return_value=True)
        with self.assertRaises(LLMError) as ctx:
            agent.review_json([{"role": "user", "content": "x"}])
        self.assertIn("F8", str(ctx.exception))
        self.assertIn("401", str(ctx.exception))

    def test_step_waits_during_cutscene_instead_of_sleeping(self):
        from unittest.mock import patch
        agent = Agent.__new__(Agent)
        agent.game = Mock(pending=None)
        agent.day = SimpleNamespace(script=[{"type": "sleep"}], steps=[])
        agent.execute = Mock()
        with patch("autopilot.time.sleep") as sleeper:
            agent.step({"ready": True, "event": True, "time": 1100, "menu": None, "busy_action": None})
        sleeper.assert_called()
        agent.execute.assert_not_called()
