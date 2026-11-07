import csv
import json
from pathlib import Path
import shutil
import uuid
import threading
import unittest
from types import SimpleNamespace
from unittest.mock import Mock, patch

from autopilot import Agent, Memory, ActionInterrupted
from execution_guard import ExecutionGuard
from game import Game, GameError
from storage import atomic_write, read_json
from telemetry import summarize


class Workspace:
    def __init__(self):
        self.root = Path(__file__).resolve().parent
        self.path = self.root / ('.test-' + uuid.uuid4().hex)
        self.path.mkdir()
        self.name = str(self.path)

    def cleanup(self):
        assert self.path.resolve().parent == self.root, 'test directory escaped workspace'
        shutil.rmtree(self.path)


class TestReceiptsClient(unittest.TestCase):
    def setUp(self):
        self.directory = Workspace()
        self.addCleanup(self.directory.cleanup)
        self.path = Path(self.directory.name) / 'pending.json'
        self.game = Game(pending_path=self.path)
        self.game.receipts_supported = True

    def test_timeout_is_not_reposted_and_survives_restart(self):
        self.game._request = Mock(side_effect=GameError('lost response after payment'))
        with self.assertRaises(GameError):
            self.game.act({'type': 'upgrade_tool', 'tool': 'pickaxe'})
        request_id = self.game.pending['action']['request_id']
        self.game.act({'type': 'buy_weapon'})
        self.game._request.assert_called_once()
        restarted = Game(pending_path=self.path)
        restarted._request = Mock(return_value={'state': 'completed', 'result': {
            'ok': True, 'request_id': request_id}})
        result = restarted.recover_pending()
        self.assertEqual(result['state'], 'completed')
        self.assertIsNone(restarted.pending)
        self.assertEqual(restarted._request.call_args.args[0], 'GET')
        self.assertIsNone(json.loads(self.path.read_text()))

    def test_unknown_and_interrupted_receipts_remain_blocked(self):
        for state in ('unknown', 'uncertain', 'pending', 'wrong_save'):
            self.game.pending = {'base': self.game.base, 'action': {'request_id': 'id'}}
            self.game._request = Mock(return_value={'state': state})
            self.game.recover_pending()
            self.assertIsNotNone(self.game.pending)

    def test_completed_but_uncertain_upgrade_is_not_cleared(self):
        self.game.pending = {'base': self.game.base, 'action': {'request_id': 'id'}}
        self.game._request = Mock(return_value={'state': 'completed', 'result': {'status': 'ACTION_UNCERTAIN'}})
        self.assertEqual(self.game.recover_pending()['state'], 'uncertain')
        self.assertIsNotNone(self.game.pending)

    def test_wrong_server_cannot_clear_pending_operation(self):
        self.game.pending = {'base': 'http://another-server', 'action': {'request_id': 'id'}}
        self.game._request = Mock()
        self.assertEqual(self.game.recover_pending()['state'], 'wrong_server')
        self.game._request.assert_not_called()

    def test_old_mod_is_rejected_before_mutation(self):
        self.game.receipts_supported = False
        self.game._request = Mock(return_value={'ok': True})
        self.assertEqual(self.game.act({'type': 'buy_weapon'})['status'], 'AGENT_UNAVAILABLE')
        self.assertEqual(self.game._request.call_count, 1)
        self.assertIsNone(self.game.pending)

    def test_missing_receipt_does_not_allow_another_purchase(self):
        self.game._request = Mock(return_value={'ok': False, 'message': 'server error'})
        self.assertEqual(self.game.act({'type': 'buy_weapon'})['status'], 'ACTION_UNCERTAIN')
        self.assertIsNotNone(self.game.pending)

    def test_verified_response_clears_intent(self):
        self.game._request = lambda method, path, body: {'ok': True, 'request_id': body['request_id']}
        self.assertTrue(self.game.act({'type': 'wait'})['ok'])
        self.assertIsNone(self.game.pending)


class TestUnifiedDispatch(unittest.TestCase):
    def agent(self):
        agent = Agent.__new__(Agent)
        agent.day = SimpleNamespace(execution_guard=ExecutionGuard())
        agent.game = Mock()
        agent.game.state.return_value = {'ready': True, 'location': 'Farm', 'time': 900}
        agent.record = Mock()
        return agent

    def test_child_action_cannot_bypass_breaker(self):
        agent = self.agent()
        agent.game.act.return_value = {'ok': False, 'message': 'no empty machine accepts anything'}
        for _ in range(5):
            agent.act_and_record({}, {'type': 'load_machines'}, 'child')
        self.assertEqual(agent.game.act.call_count, 1)

    def test_disconnect_aborts_remaining_children(self):
        agent = self.agent()
        agent.game.act.side_effect = GameError('disconnected')
        def macro(*args):
            agent.act_and_record({}, {'type': 'buy_weapon'}, 'child 1')
            agent.act_and_record({}, {'type': 'upgrade_tool'}, 'must not run')
        agent._execute = macro
        result = agent.execute({}, {'type': 'decorate'})
        self.assertEqual(result['status'], 'AGENT_UNAVAILABLE')
        self.assertEqual(agent.game.act.call_count, 1)

    def test_busy_and_unready_mod_are_not_mutated(self):
        agent = self.agent()
        for state in ({'ready': False}, {'ready': True, 'busy_action': 'mine'}):
            agent.game.state.return_value = state
            self.assertEqual(agent.dispatch({}, {'type': 'buy_weapon'})['status'], 'AGENT_UNAVAILABLE')
        agent.game.act.assert_not_called()

    def test_dispatch_measures_game_time_and_failure_once(self):
        agent = self.agent()
        agent.game.act.return_value = {'ok': False, 'after': {'time': 930}}
        result = agent.dispatch({}, {'type': 'upgrade_tool'})
        self.assertEqual(result['game_minutes'], 30)
        self.assertIn('elapsed_seconds', result)

    def test_only_one_direct_mutation_call_remains(self):
        import ast
        tree = ast.parse(Path(__file__).with_name('autopilot.py').read_text(encoding='utf-8'))
        sites = []
        for node in ast.walk(tree):
            if isinstance(node, (ast.FunctionDef, ast.AsyncFunctionDef)):
                for call in ast.walk(node):
                    if isinstance(call, ast.Call) and ast.unparse(call.func) == 'self.game.act':
                        sites.append(node.name)
        self.assertEqual(sites, ['dispatch'])


class TestPreciseBreakers(unittest.TestCase):
    def test_unrelated_money_and_fish_do_not_unblock_furnace(self):
        guard = ExecutionGuard()
        state = {'machines': [{'id': '(BC)13', 'contains': None}],
                 'farm_resources': {'(O)378': 4}, 'player': {'money': 100}}
        action = {'type': 'load_machines'}
        guard.observe(state, action, {'ok': False, 'message': 'no empty machine accepts anything'})
        state['farm_resources']['(O)145'] = 1
        state['player']['money'] = 500
        self.assertTrue(guard.blocked(state, action))
        state['farm_resources']['(O)382'] = 1
        self.assertFalse(guard.blocked(state, action))

    def test_route_failure_is_not_reset_by_crafting_or_clock(self):
        guard = ExecutionGuard()
        state = {'location': 'Backwoods', 'time': 900}
        action = {'type': 'goto_location', 'location': 'Mountain'}
        for _ in range(2):
            guard.observe(state, action, {'ok': False, 'message': 'no reachable route'})
        state.update(time=1300, farm_revision=99, farm_resources={'wood': 100})
        self.assertTrue(guard.blocked(state, action))
        state['route_revision'] = 1
        self.assertFalse(guard.blocked(state, action))

    def test_locked_door_can_retry_after_opening_hour(self):
        guard = ExecutionGuard()
        state = {'location': 'Town', 'time': 800}
        action = {'type': 'goto_location', 'location': 'Blacksmith'}
        for _ in range(2):
            guard.observe(state, action, {'ok': False, 'message': 'locked until 9:00'})
        self.assertTrue(guard.blocked(state, action))
        state['time'] = 900
        self.assertFalse(guard.blocked(state, action))


class TestAtomicMemory(unittest.TestCase):
    def setUp(self):
        self.directory = Workspace()
        self.addCleanup(self.directory.cleanup)
        self.root = Path(self.directory.name)
        with patch('autopilot.MEM', self.root):
            self.memory = Memory('test')

    def test_interrupted_replace_keeps_original_and_backup(self):
        path = self.root / 'strategy.md'
        atomic_write(path, 'old strategy')
        import storage
        original = storage.os.replace
        def fail_main(src, dest):
            if Path(dest) == path:
                raise OSError('simulated interruption')
            original(src, dest)
        with patch('storage.os.replace', side_effect=fail_main):
            with self.assertRaises(OSError):
                atomic_write(path, 'new strategy')
        self.assertEqual(path.read_text(), 'old strategy')
        self.assertEqual(Path(str(path) + '.bak').read_text(), 'old strategy')
        self.assertFalse(list(self.root.glob('*.tmp')))

    def test_corrupt_layout_recovers_previous_valid_copy(self):
        self.memory.save_layout({'plots': [1]})
        self.memory.save_layout({'plots': [2]})
        self.memory.layout_path.write_text('{broken')
        with self.assertWarns(RuntimeWarning):
            self.assertEqual(self.memory.layout(), {'plots': [1]})
        self.assertEqual(read_json(self.memory.layout_path), {'plots': [1]})

    def test_concurrent_lesson_updates_are_not_lost(self):
        threads = [threading.Thread(target=self.memory.add_lessons, args=([f'lesson-{i}'],)) for i in range(20)]
        for thread in threads: thread.start()
        for thread in threads: thread.join()
        self.assertEqual(len(self.memory.lessons().splitlines()), 20)

    def test_old_metrics_header_migrates_without_losing_rows(self):
        self.memory.metrics_path.write_text('date,income\nold,100\n', encoding='utf-8')
        self.memory.add_metrics({'date': 'new', 'income': 200, 'effective_rate': 0.8})
        with self.memory.metrics_path.open(encoding='utf-8', newline='') as stream:
            rows = list(csv.DictReader(stream))
        self.assertEqual(rows[0]['income'], '100')
        self.assertEqual(rows[1]['effective_rate'], '0.8')

    def test_review_snapshot_contains_strategy_and_new_lesson(self):
        self.memory.save_review('new strategy ' * 10, ['verified lesson'], 'day1')
        snapshot = self.memory.snapshot()
        self.assertIn('new strategy', snapshot['strategy'])
        self.assertIn('verified lesson', snapshot['lessons'])

    def test_interrupted_review_is_completed_on_next_snapshot(self):
        import autopilot
        write = autopilot.atomic_write
        failed = False
        def interrupt(path, text, **kwargs):
            nonlocal failed
            if Path(path) == self.memory.lessons_path and not failed:
                failed = True
                raise OSError('crash between strategy and lessons')
            return write(path, text, **kwargs)
        with patch('autopilot.atomic_write', side_effect=interrupt):
            with self.assertRaises(OSError):
                self.memory.save_review('updated strategy ' * 10, ['paired lesson'], 'day1')
        snapshot = self.memory.snapshot()
        self.assertIn('updated strategy', snapshot['strategy'])
        self.assertIn('paired lesson', snapshot['lessons'])
        self.assertIsNone(read_json(self.memory.review_commit_path))


class TestTelemetry(unittest.TestCase):
    def test_recovered_result_supersedes_transport_error_for_same_receipt(self):
        rows = [{'ok': False, 'status': 'AGENT_UNAVAILABLE', 'request_id': 'x',
                 'action': {'type': 'upgrade_tool'}, 'elapsed_seconds': 30},
                {'ok': True, 'request_id': 'x', 'status': 'SUCCESS', 'action': {'type': 'upgrade_tool'}}]
        stats = summarize(rows)
        self.assertEqual(stats['useful_actions'], 1)
        self.assertEqual(stats['unavailable'], 0)
        self.assertEqual(summarize(list(reversed(rows)))['useful_actions'], 1)

    def test_uploaded_journal_parser_preserves_noop_and_receipts(self):
        from analyze_logs import read_steps
        from journal import render
        event = {'kind': 'step', 'time': 900, 'location': 'Farm', 'ok': False,
                 'action': {'type': 'load_machines'}, 'status': 'NO_PROGRESS',
                 'request_id': 'abc123', 'elapsed_seconds': 2.1, 'game_minutes': 10,
                 'message': 'no empty machine accepts anything'}
        steps = read_steps(render(event))
        self.assertEqual(steps[0]['request_id'], 'abc123')
        self.assertEqual(steps[0]['status'], 'NO_PROGRESS')
        self.assertEqual(summarize(steps)['failed_game_minutes'], 10)

    def test_noop_success_is_not_useful_and_duplicate_receipts_count_once(self):
        rows = [{'ok': True, 'message': 'harvested 0 crops', 'action': {'type': 'harvest_crops'}},
                {'ok': True, 'request_id': 'a', 'action': {'type': 'fish'}},
                {'ok': True, 'request_id': 'a', 'action': {'type': 'fish'}},
                {'ok': False, 'status': 'CIRCUIT_OPEN', 'action': {'type': 'load_machines'}},
                {'ok': False, 'elapsed_seconds': 2, 'game_minutes': 10, 'action': {'type': 'mine'}},
                {'ok': True, 'action': {'type': 'wait'}}]
        stats = summarize(rows)
        self.assertEqual(stats['work_attempts'], 3)
        self.assertEqual(stats['no_progress'], 1)
        self.assertEqual(stats['useful_actions'], 1)
        self.assertEqual(stats['circuit_skips'], 1)
        self.assertEqual(stats['failed_game_minutes'], 10)
        self.assertEqual(stats['failure_seconds'], 2)


if __name__ == '__main__':
    unittest.main()
