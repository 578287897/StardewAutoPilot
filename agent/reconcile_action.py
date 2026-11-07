"""Inspect an ambiguous operation; resolve only after checking the real game, with the agent stopped."""
import argparse
import json
from datetime import datetime

from autopilot import load_config, MEM, ROOT
from game import Game
from storage import atomic_write


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--config', default=None)
    parser.add_argument('--resolve', metavar='REQUEST_ID')
    parser.add_argument('--decision', choices=('confirmed-success', 'confirmed-failure'))
    parser.add_argument('--note', help='What you verified in the actual game')
    args = parser.parse_args()
    cfg = load_config(args.config or str(ROOT / 'config.json'))
    pending_path = MEM / cfg.get('profile', 'default') / 'pending_action.json'
    game = Game(cfg['mod_url'], cfg.get('mod_api_token', ''), pending_path)
    if not game.pending:
        print('No unresolved action.')
        return
    pending = game.pending
    state = game.state()
    receipt = game.recover_pending()
    print(json.dumps({'pending': pending, 'receipt': receipt, 'state': state,
                      'progress': game.progress()}, ensure_ascii=False, indent=2))
    if not args.resolve:
        return
    if not args.decision or not args.note:
        parser.error('--resolve requires --decision and --note; stop the agent and inspect the game first')
    if args.resolve != pending['action']['request_id']:
        parser.error('request ID does not match the pending action')
    if not state.get('ready') or state.get('busy_action') or receipt.get('state') in ('pending', 'wrong_save', 'wrong_server'):
        parser.error('cannot resolve while game is busy/unready or save/server does not match')
    audit = pending_path.with_name('reconciliation.jsonl')
    event = {'ts': datetime.now().isoformat(), 'pending': pending, 'receipt': receipt,
             'decision': args.decision, 'note': args.note, 'player': state.get('player')}
    text = audit.read_text(encoding='utf-8') if audit.exists() else ''
    atomic_write(audit, text + json.dumps(event, ensure_ascii=False) + '\n')
    atomic_write(pending_path, 'null')
    print('Resolution recorded. Restart the agent to resume; no game action was replayed.')


if __name__ == '__main__':
    main()
