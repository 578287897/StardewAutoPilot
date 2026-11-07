"""Read-only compatibility check. Never sends game actions or changes the save."""
import argparse
import json

from autopilot import load_config, ROOT
from game import Game


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--config', default=str(ROOT / 'config.json'))
    args = parser.parse_args()
    cfg = load_config(args.config)
    game = Game(cfg['mod_url'], cfg.get('mod_api_token', ''))
    ping = game.ping()
    state = game.state()
    if ping.get('action_receipts') is not True:
        parser.error('running Mod does not support action receipts; restart with 0.2.10 or newer')
    if not state.get('ready'):
        parser.error('load your intended save before checking')
    missing = {'farm_resources', 'farm_revision', 'route_revision', 'upgrading'} - state.keys()
    if missing:
        parser.error('missing state fields: ' + ', '.join(sorted(missing)))
    print(json.dumps({'compatible': True, 'save': state.get('save_name'),
                      'busy_action': state.get('busy_action'), 'upgrading': state.get('upgrading'),
                      'inventory_free_slots': state.get('inventory_free_slots')}, ensure_ascii=False, indent=2))


if __name__ == '__main__':
    main()
