"""HTTP client for the StardewAutoPilot SMAPI mod."""
import json
from pathlib import Path
import uuid
import urllib.error
import urllib.parse
import urllib.request
from storage import atomic_write


class GameError(Exception):
    pass


class Game:
    # POST /act waits this long. An unknown receipt must not outlive it.
    ACTION_TIMEOUT = 330

    def __init__(self, base_url="http://localhost:8765", api_token="", pending_path=None):
        self.base = base_url.rstrip("/")
        self.api_token = api_token or ""
        self.pending_path = Path(pending_path) if pending_path else None
        self.pending = None
        self.receipts_supported = False
        if self.pending_path and self.pending_path.exists():
            self.pending = json.loads(self.pending_path.read_text(encoding="utf-8"))

    def _request(self, method, path, body=None, timeout=None):
        if timeout is None:
            timeout = self.ACTION_TIMEOUT
        data = json.dumps(body, ensure_ascii=False).encode("utf-8") if body is not None else None
        headers = {"Content-Type": "application/json"}
        if self.api_token:
            headers["Authorization"] = f"Bearer {self.api_token}"
        req = urllib.request.Request(self.base + path, data=data, method=method, headers=headers)
        try:
            with urllib.request.urlopen(req, timeout=timeout) as resp:
                return json.loads(resp.read().decode("utf-8"))
        except urllib.error.HTTPError as e:
            try:
                return json.loads(e.read().decode("utf-8"))
            except Exception:
                raise GameError(f"HTTP {e.code} on {path}")
        except (urllib.error.URLError, ConnectionError, TimeoutError) as e:
            raise GameError(f"cannot reach the game mod at {self.base} ({e}); is the game running with SMAPI?")

    def ping(self):
        return self._request("GET", "/ping", timeout=10)

    def state(self):
        return self._request("GET", "/state", timeout=30)

    def map(self, radius=9):
        return self._request("GET", f"/map?radius={radius}", timeout=30)

    def crops(self, location=None):
        q = f"?location={location}" if location else ""
        return self._request("GET", "/crops" + q, timeout=30)

    def messages(self, since=0):
        return self._request("GET", f"/messages?since={since}", timeout=30)

    def items(self, ids):
        return self._request("GET", "/items?ids=" + urllib.parse.quote(",".join(ids)), timeout=30)

    def saves(self):
        return self._request("GET", "/saves", timeout=30)

    def new_game(self, name, farm, favorite, farm_type=0):
        return self._request("POST", "/new_game", {
            "name": name, "farm": farm, "favorite": favorite, "farm_type": farm_type}, timeout=30)

    def plot_check(self, x, y, w, h):
        return self._request("GET", f"/plot_check?x={x}&y={y}&w={w}&h={h}", timeout=30)

    def find_plot(self, w, h, near_x, near_y):
        return self._request("GET", f"/find_plot?w={w}&h={h}&x={near_x}&y={near_y}", timeout=60)

    def tile(self, x, y):
        return self._request("GET", f"/tile?x={x}&y={y}", timeout=30)

    def crop_data(self):
        return self._request("GET", "/crop_data", timeout=30)

    def farm_grid(self):
        return self._request("GET", "/farm_grid", timeout=30)

    def progress(self):
        return self._request("GET", "/progress", timeout=30)

    def ranch(self):
        return self._request("GET", "/ranch", timeout=30)

    def building_sites(self, building, near_x, near_y):
        return self._request("GET", f"/building_sites?type={urllib.parse.quote(building)}&x={near_x}&y={near_y}", timeout=60)

    def bundles(self):
        return self._request("GET", "/bundles", timeout=30)

    def social(self):
        return self._request("GET", "/social", timeout=30)

    def recipes(self, cooking=False):
        return self._request("GET", "/recipes" + ("?cooking=1" if cooking else ""), timeout=30)

    def achievements(self):
        return self._request("GET", "/achievements", timeout=30)

    def collections(self):
        return self._request("GET", "/collections", timeout=60)

    def quests(self):
        return self._request("GET", "/quests", timeout=30)

    def special_orders(self):
        return self._request("GET", "/special_orders", timeout=30)

    def tool_upgrades(self):
        return self._request("GET", "/tool_upgrades", timeout=30)

    def actions(self):
        return self._request("GET", "/actions", timeout=30)

    def load_save(self, name):
        return self._request("POST", "/load_save", {"name": name}, timeout=30)

    def act(self, action: dict):
        if self.pending:
            return {"ok": False, "status": "ACTION_UNCERTAIN",
                    "message": "previous operation unresolved; query action_status before sending another action"}
        if not self.receipts_supported:
            self.receipts_supported = self.ping().get("action_receipts") is True
            if not self.receipts_supported:
                return {"ok": False, "status": "AGENT_UNAVAILABLE",
                        "message": "update the Mod: durable action receipts are required"}
        body = {**action, "request_id": uuid.uuid4().hex}
        self.pending = {"base": self.base, "action": body,
                        "script_action": getattr(self, "script_action", None) or dict(action)}
        self._save_pending()
        try:
            result = self._request("POST", "/act", body)
        except GameError:
            # Never re-POST an ambiguous mutation, even after restarting the Python agent.
            raise
        if result.get("request_id") != body["request_id"]:
            return {"ok": False, "status": "ACTION_UNCERTAIN", "message": "missing operation receipt; query actual result",
                    "request_id": body["request_id"]}
        if result.get("status") != "ACTION_UNCERTAIN":
            self.pending = None
            self._save_pending()
        return result

    def _save_pending(self):
        if self.pending_path:
            atomic_write(self.pending_path, json.dumps(self.pending, ensure_ascii=False))

    def recover_pending(self):
        if not self.pending:
            return None
        if self.pending["base"] != self.base:
            return {"state": "wrong_server", "message": "pending operation belongs to another Mod URL"}
        request_id = self.pending["action"]["request_id"]
        result = self._request("GET", "/action_status?request_id=" + urllib.parse.quote(request_id), timeout=30)
        result["action"] = self.pending["action"]
        result["script_action"] = self.pending.get("script_action", result["action"])
        if result.get("state") == "completed" and result.get("result", {}).get("status") == "ACTION_UNCERTAIN":
            result["state"] = "uncertain"
        if result.get("state") == "completed":
            self.pending = None
            self._save_pending()
        return result

    def cancel(self):
        return self._request("POST", "/cancel", {}, timeout=30)
