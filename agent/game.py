"""HTTP client for the StardewAutoPilot SMAPI mod."""
import json
import urllib.error
import urllib.parse
import urllib.request


class GameError(Exception):
    pass


class Game:
    def __init__(self, base_url="http://localhost:8765"):
        self.base = base_url.rstrip("/")

    def _request(self, method, path, body=None, timeout=330):
        data = json.dumps(body, ensure_ascii=False).encode("utf-8") if body is not None else None
        req = urllib.request.Request(self.base + path, data=data, method=method,
                                     headers={"Content-Type": "application/json"})
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
        q = urllib.parse.urlencode({"name": name, "farm": farm, "favorite": favorite, "farm_type": farm_type})
        return self._request("GET", "/new_game?" + q, timeout=30)

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

    def load_save(self, name):
        return self._request("GET", f"/load_save?name={urllib.parse.quote(name)}", timeout=30)

    def act(self, action: dict):
        return self._request("POST", "/act", action)

    def cancel(self):
        return self._request("POST", "/cancel", {}, timeout=30)
