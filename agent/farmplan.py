"""Farm master plan for a good-looking farm: zones, 2-tile roads, lamp spots.

Computed once from the real map (/farm_grid) and saved in layout.json, then every placement on the farm goes
through it (autopilot.tidy_spot / ensure_plot / building_site). Grid chars come from the mod's FarmGrid:
x blocked, w water, B building, . free, d clearable debris, t tree/stump/boulder, c tilled/crop, p path, o object.
"""
import heapq

# small trees get chopped while paving; big stumps/boulders need an upgraded tool, so roads go around them
PASS_COST = {".": 1.0, "p": 0.3, "d": 1.6, "c": 6.0, "t": 2.5, "r": 30.0}  # anything else is impassable for roads
MAX_ROAD = 90  # longer routes to secondary exits are not worth paving
TURN_COST = 10.0
LAMP_EVERY = 8

# zone name -> (preferred sizes, purpose)
ZONE_SIZES = {
    "crops": [(20, 14), (13, 14), (13, 9)],     # 6x4 plots with 1-tile walkways: 3x3, 2x3, 2x2 plots
    "workshop": [(9, 7), (8, 6)],               # Shed 7x3 + its door row, machines in rows
    "orchard": [(13, 10), (10, 7)],             # fruit trees every 3 tiles, each with a clear 3x3
    "animals": [(22, 11), (16, 10)],            # coop + barn in a row, paddock in front
}
ZONE_NAMES = {"crops": "菜地", "workshop": "作坊角", "orchard": "果园", "animals": "畜牧区", "plaza": "门前广场"}


def _grid(g):
    return [list(r) for r in g["rows"]]


def _dijkstra(grid, start, goal_fn, extra_cost=None, blocked=None, max_cost=4000):
    """Shortest path with a turn penalty (straight roads). Returns a list of (x, y) or None."""
    h, w = len(grid), len(grid[0])
    dirs = ((1, 0), (-1, 0), (0, 1), (0, -1))
    best = {}
    heap = [(0.0, start[0], start[1], -1, None)]
    parent = {}
    while heap:
        cost, x, y, d, prev = heapq.heappop(heap)
        key = (x, y, d)
        if key in best:
            continue
        best[key] = cost
        parent[key] = prev
        if goal_fn(x, y) and (x, y) != tuple(start):
            path, k = [], key
            while k is not None:
                path.append((k[0], k[1]))
                k = parent[k]
            return path[::-1]
        if cost > max_cost:
            break
        for nd, (dx, dy) in enumerate(dirs):
            nx, ny = x + dx, y + dy
            if not (0 <= nx < w and 0 <= ny < h) or (blocked and (nx, ny) in blocked):
                continue
            c = PASS_COST.get(grid[ny][nx])
            if c is None and not goal_fn(nx, ny):
                continue
            step = (c or 1.0) * (extra_cost(nx, ny) if extra_cost else 1.0)
            if d != -1 and nd != d:
                step += TURN_COST
            if (nx, ny, nd) not in best:
                heapq.heappush(heap, (cost + step, nx, ny, nd, key))
    return None


def _widen(grid, path, taken):
    """Second lane for a 1-tile path: below horizontal runs, right of vertical runs (other side if blocked)."""
    tiles = []
    for i, (x, y) in enumerate(path):
        a = path[max(0, i - 1)]
        b = path[min(len(path) - 1, i + 1)]
        horizontal = a[1] == b[1]
        sides = [(x, y + 1), (x, y - 1)] if horizontal else [(x + 1, y), (x - 1, y)]
        for k, (sx, sy) in enumerate(sides):
            # keep to the preferred side through trees (they get cleared later); switch sides only for real obstacles
            ok_chars = ".dpt" if k == 0 else ".dp"
            if 0 <= sy < len(grid) and 0 <= sx < len(grid[0]) and grid[sy][sx] in ok_chars and (sx, sy) not in taken:
                tiles.append((sx, sy))
                break
    return tiles


def _exit_points(g):
    """One target per neighbouring map (middle of each warp strip) plus building doors."""
    by_map = {}
    for e in g.get("exits", []):
        by_map.setdefault(e["to"], []).append((e["x"], e["y"]))
    points = {}
    for to, pts in by_map.items():
        pts.sort()
        points[to] = pts[len(pts) // 2]
    return points


def _rect_tiles(r):
    x, y, w, h = r
    return {(i, j) for i in range(x, x + w) for j in range(y, y + h)}


def _road_dist(roads, w, h):
    """Manhattan-ish BFS distance from every tile to the nearest road tile."""
    INF = 10 ** 6
    dist = [[INF] * w for _ in range(h)]
    q = list(roads)
    for x, y in q:
        dist[y][x] = 0
    i = 0
    while i < len(q):
        x, y = q[i]
        i += 1
        for nx, ny in ((x + 1, y), (x - 1, y), (x, y + 1), (x, y - 1)):
            if 0 <= nx < w and 0 <= ny < h and dist[ny][nx] > dist[y][x] + 1:
                dist[ny][nx] = dist[y][x] + 1
                q.append((nx, ny))
    return dist


def _best_rect(grid, size, used, score_fn):
    """Best placement of a w x h rectangle on free/clearable/tree ground, 1 tile away from everything already used."""
    rw, rh = size
    h, w = len(grid), len(grid[0])
    best = None
    for y in range(1, h - rh - 1):
        for x in range(1, w - rw - 1):
            ok, trees, debris, crops = True, 0, 0, 0
            for j in range(y - 1, y + rh + 1):
                row = grid[j]
                for i in range(x - 1, x + rw + 1):
                    inside = x <= i < x + rw and y <= j < y + rh
                    if (i, j) in used and inside:
                        ok = False
                        break
                    if not inside:
                        continue
                    ch = row[i]
                    if ch not in ".dtcr":
                        ok = False
                        break
                    trees += 0.3 if ch == "t" else 1.0 if ch == "r" else 0
                    debris += ch == "d"
                    crops += ch == "c"
                if not ok:
                    break
            if not ok:
                continue
            # 1-tile margin to other zones (roads may touch)
            if any((i, j) in used and used[(i, j)] != "road"
                   for i in range(x - 1, x + rw + 1) for j in (y - 1, y + rh)) or \
               any((i, j) in used and used[(i, j)] != "road" for j in range(y, y + rh) for i in (x - 1, x + rw)):
                continue
            s = score_fn(x, y, rw, rh) + trees * 3.0 + debris * 0.2
            if best is None or s < best[0]:
                best = (s, (x, y, rw, rh))
    return best[1] if best else None


def make_plan(g, storage_row=None):
    grid = _grid(g)
    h, w = len(grid), len(grid[0])
    door = tuple(g["door"])
    used = {}  # tile -> "road" | zone name | "reserved"

    # reserve the existing storage row by the shipping bin (12 tiles) and the area right around the house door
    if storage_row:
        for i in range(12):
            used[(storage_row[0] + i, storage_row[1])] = "reserved"

    # --- plaza in front of the door (paved), 5 wide x 3 deep
    plaza = [(x, y) for y in range(door[1] + 1, door[1] + 4) for x in range(door[0] - 2, door[0] + 3)
             if 0 <= y < h and 0 <= x < w and grid[y][x] in ".dpc" and (x, y) not in used]
    for t in plaza:
        used[t] = "road"

    # --- main roads, most used first: town (BusStop), greenhouse, then the other exits
    exits = _exit_points(g)
    targets = []
    if "BusStop" in exits:
        targets.append(("去镇上（BusStop）", exits["BusStop"]))
    for b in g.get("buildings", []):
        if b["type"] == "Greenhouse":
            targets.append(("去温室", tuple(b["door"])))
    for to, pt in exits.items():
        if to not in ("BusStop", "FarmHouse", "Greenhouse") and not to.startswith("Farm"):
            targets.append((f"去 {to}", pt))

    roads = []  # [(name, [tiles in order])]
    road_set = set(plaza)

    def near(pt, r=2):
        return lambda x, y: abs(x - pt[0]) + abs(y - pt[1]) <= r and grid[y][x] in ".dpct"

    start = (door[0], door[1] + 1)
    for name, pt in targets:
        path = _dijkstra(grid, start, near(pt), extra_cost=lambda x, y: 0.3 if (x, y) in road_set else 1.0,
                         blocked={t for t, v in used.items() if v == "reserved"})
        if not path or (len(path) > MAX_ROAD and not name.startswith("去镇上")):
            continue
        tiles = [t for t in path if t not in road_set]
        tiles += [t for t in _widen(grid, path, road_set | set(tiles)) if t not in road_set]
        tiles = [t for t in tiles if t not in used or used[t] == "road"]
        for t in tiles:
            used[t] = "road"
            road_set.add(t)
        roads.append((name, tiles))

    # --- zones
    rd = _road_dist(road_set, w, h)

    def dist_door(x, y, rw, rh):
        return abs(x + rw / 2 - door[0]) + abs(y + rh / 2 - door[1])

    def road_touch(x, y, rw, rh):
        return min(rd[j][i] for i in range(x, x + rw) for j in (y, y + rh - 1))

    scorers = {
        # crops: close to the house and right along a road
        "crops": lambda x, y, rw, rh: 2 * dist_door(x, y, rw, rh) + 4 * max(0, road_touch(x, y, rw, rh) - 1),
        # workshop: behind (north of) the house or tucked into a corner, away from the roads
        "workshop": lambda x, y, rw, rh: dist_door(x, y, rw, rh) * 0.8 + (0 if y + rh <= door[1] - 2 else 25)
        - 3 * min(road_touch(x, y, rw, rh), 5) + 0.3 * min(x, w - x - rw, y),
        # orchard: towards the north or an edge of the farm, not on prime land next to the house
        "orchard": lambda x, y, rw, rh: 0.6 * min(y, x, w - x - rw) + 0.2 * y + 0.2 * dist_door(x, y, rw, rh),
        # animals: a bit away from the house, reachable by road
        "animals": lambda x, y, rw, rh: 0.5 * dist_door(x, y, rw, rh) + 3 * max(0, road_touch(x, y, rw, rh) - 2),
    }
    zones = {}
    for name in ("crops", "workshop", "animals", "orchard"):  # most-visited first, so it gets the land nearest the house
        for size in ZONE_SIZES[name]:
            r = _best_rect(grid, size, used, scorers[name])
            if r:
                zones[name] = list(r)
                for t in _rect_tiles(r):
                    used[t] = name
                break

    # --- connector roads: from each zone's entrance (border tile nearest a road) to the nearest existing road
    for name in ("animals", "workshop", "crops"):
        if name not in zones:
            continue
        x, y, zw, zh = zones[name]
        zt = _rect_tiles(zones[name])
        border = [(i, j) for i in range(x, x + zw) for j in (y - 1, y + zh)] +                  [(i, j) for j in range(y, y + zh) for i in (x - 1, x + zw)]
        border = [t for t in border if 0 <= t[0] < w and 0 <= t[1] < h and grid[t[1]][t[0]] in ".dpt" and used.get(t) in (None, "road")]
        if not border:
            continue
        entrance = min(border, key=lambda t: rd[t[1]][t[0]])
        if rd[entrance[1]][entrance[0]] <= 1:
            continue  # the zone already touches a road
        blocked = {t for t, v in used.items() if v != "road"} | zt
        path = _dijkstra(grid, entrance, lambda i, j: (i, j) in road_set, blocked=blocked)
        if not path:
            continue
        tiles = [t for t in path if t not in road_set]
        tiles += [t for t in _widen(grid, tiles, road_set | set(tiles) | blocked) if t not in road_set and t not in used]
        for t in tiles:
            used[t] = "road"
            road_set.add(t)
        roads.append((f"去{ZONE_NAMES[name]}", tiles))

    # --- lamp posts along the roads, just outside them, every few tiles
    lamps = []
    for _, tiles in roads:
        for t in tiles[::LAMP_EVERY]:
            for sx, sy in ((t[0], t[1] - 1), (t[0] - 1, t[1]), (t[0] + 1, t[1]), (t[0], t[1] + 1)):
                if 0 <= sx < w and 0 <= sy < h and (sx, sy) not in used and grid[sy][sx] in ".d" \
                        and all(abs(sx - lx) + abs(sy - ly) >= 5 for lx, ly in lamps):
                    lamps.append((sx, sy))
                    used[(sx, sy)] = "lamp"
                    break

    decor = plan_decor(grid, zones, plaza, used, rd)
    return {
        "version": 1,
        **decor,
        "door": list(door),
        "plaza": [list(t) for t in plaza],
        "roads": [{"name": n, "tiles": [list(t) for t in tiles]} for n, tiles in roads],
        "zones": zones,
        "lamps": [list(t) for t in lamps],
    }


def plan_decor(grid, zones, plaza, used, rd):
    """Pastoral touches: a row of trees screening the workshop, a fence around the animal zone, flowerbeds by the plaza."""
    h, w = len(grid), len(grid[0])
    ok = lambda x, y: 0 <= x < w and 0 <= y < h and grid[y][x] in ".dt" and used.get((x, y)) in (None,)

    def ring(r, d):
        x, y, rw, rh = r
        top = [(i, y - d) for i in range(x - d, x + rw + d)]
        bottom = [(i, y + rh - 1 + d) for i in range(x - d, x + rw + d)]
        left = [(x - d, j) for j in range(y - d + 1, y + rh - 1 + d)]
        right = [(x + rw - 1 + d, j) for j in range(y - d + 1, y + rh - 1 + d)]
        return {"top": top, "bottom": bottom, "left": left, "right": right}

    def road_side(sides):
        """The side closest to a road: that's where the entrance/gate goes."""
        return min(sides, key=lambda k: min(rd[t[1]][t[0]] if 0 <= t[0] < w and 0 <= t[1] < h else 10 ** 6 for t in sides[k]))

    out = {"screen": [], "fence": [], "gate": None, "flowers": []}
    if "workshop" in zones:
        sides = ring(zones["workshop"], 1)
        entrance = road_side(sides)
        for k, tiles in sides.items():
            if k != entrance:
                out["screen"] += [list(t) for i, t in enumerate(tiles) if i % 2 == 0 and ok(*t)]
    if "animals" in zones:
        sides = ring(zones["animals"], 0)
        gate_side = road_side(sides)
        mid = sides[gate_side][len(sides[gate_side]) // 2]
        out["gate"] = list(mid)
        for tiles in sides.values():
            out["fence"] += [list(t) for t in tiles if t != mid and 0 <= t[0] < w and 0 <= t[1] < h and grid[t[1]][t[0]] in ".dt"]
    if plaza:
        xs = [t[0] for t in plaza]
        ys = sorted({t[1] for t in plaza})
        for fx in (min(xs) - 1, max(xs) + 1):
            bed = [[fx, y] for y in ys if ok(fx, y)]
            if len(bed) == len(ys):
                out["flowers"].append([fx, ys[0], 1, len(ys)])
    return out


# ---------------- slots inside zones ----------------

def plot_slots(zone, pw=6, ph=4):
    """6x4 plots with 1-tile walkways laid out inside the crop zone."""
    x, y, w, h = zone
    return [(x + i, y + j) for j in range(0, h - ph + 1, ph + 1) for i in range(0, w - pw + 1, pw + 1)]


def orchard_slots(zone):
    """Fruit trees every 3 tiles, starting one tile in: each tree keeps its own clear 3x3 (the game blocks growth
    if any of the 8 surrounding tiles has an object, path, crop or building)."""
    x, y, w, h = zone
    return [(x + 1 + 3 * i, y + 1 + 3 * j) for j in range((h - 1) // 3) for i in range((w - 1) // 3)]


def workshop_slots(zone):
    """Shed footprint top-left (7x3, door row below kept free); machines in rows with a walkway between rows."""
    x, y, w, h = zone
    shed = (x, y, 7, 3)
    spots = []
    for j in range(y + 4, y + h, 2):                   # rows below the shed's door row
        spots += [(i, j) for i in range(x, x + w)]
    for j in range(y, y + 3, 2):                       # beside the shed, if the zone is wider than it
        spots += [(i, j) for i in range(x + 8, x + w)]
    return shed, spots


# ---------------- rendering ----------------

def classify(g, plan):
    """One class per tile: what the map shows there (shared by the text map and the status page's SVG map)."""
    grid = _grid(g)
    base = {"x": "blocked", "w": "water", "B": "building", "t": "tree", "r": "clump", "o": "object"}
    out = [[base.get(ch, "free") for ch in row] for row in grid]
    for name, (x, y, w, h) in plan.get("zones", {}).items():
        for j in range(y, y + h):
            for i in range(x, x + w):
                if out[j][i] in ("free", "tree", "clump"):
                    out[j][i] = name
    for t in plan.get("plaza", []):
        out[t[1]][t[0]] = "paved" if grid[t[1]][t[0]] == "p" else "plaza"
    for r in plan.get("roads", []):
        for t in r["tiles"]:
            out[t[1]][t[0]] = "paved" if grid[t[1]][t[0]] == "p" else "road"
    for key in ("lamps", "screen", "fence"):
        for t in plan.get(key, []):
            out[t[1]][t[0]] = key
    if plan.get("gate"):
        out[plan["gate"][1]][plan["gate"][0]] = "gate"
    for x, y, bw, bh in plan.get("flowers", []):
        for j in range(y, y + bh):
            out[j][x] = "flowers"
    d = plan["door"]
    out[d[1]][d[0]] = "door"
    return out


# single-width characters only, so the columns line up in any monospace font
CHARS = {"blocked": "#", "water": "~", "building": "H", "tree": "T", "clump": "R", "object": "o", "free": " ", "crops": "c", "workshop": "w",
         "orchard": "f", "animals": "a", "plaza": ":", "road": "=", "paved": "%", "lamps": "*", "screen": "Y", "fence": "+",
         "gate": "/", "flowers": "@", "door": "D"}
COLORS = {"blocked": "#5b5a55", "water": "#4f8fc7", "building": "#8a5a3c", "tree": "#2f6b3a", "clump": "#6b5d4a", "object": "#9a8f7a", "free": "#cdbf94",
          "crops": "#a8c66c", "workshop": "#b48b5a", "orchard": "#7fb069", "animals": "#e2c26b", "plaza": "#d9d2c3", "road": "#bdb6a6",
          "paved": "#8f877a", "lamps": "#f2d14b", "screen": "#1f5a2c", "fence": "#6e4b2a", "gate": "#c9a26b", "flowers": "#e07aa8",
          "door": "#d64545"}
NAMES = {"crops": "菜地", "workshop": "作坊角", "orchard": "果园", "animals": "畜牧区", "plaza": "门前广场", "road": "规划道路",
         "paved": "已铺好的路", "lamps": "路灯位", "screen": "遮挡树", "fence": "栅栏", "gate": "栅栏门", "flowers": "花坛",
         "door": "家门", "tree": "小树（斧头可砍）", "clump": "大树桩/大石头（要铜工具）", "water": "水", "building": "建筑", "blocked": "不可建造"}


def render(g, plan):
    """Text map for the play log."""
    return "\n".join("".join(CHARS[c] for c in row).rstrip() for row in classify(g, plan))


def render_svg(g, plan, cell=6):
    cls = classify(g, plan)
    h, w = len(cls), len(cls[0])
    rects = "".join(f'<rect x="{i * cell}" y="{j * cell}" width="{cell}" height="{cell}" fill="{COLORS[c]}"/>'
                    for j, row in enumerate(cls) for i, c in enumerate(row) if c != "free")
    return (f'<svg viewBox="0 0 {w * cell} {h * cell}" class=farm role=img aria-label="农场规划图">'
            f'<rect width="{w * cell}" height="{h * cell}" fill="{COLORS["free"]}"/>{rects}</svg>')


LEGEND = "图例：" + " · ".join(f"{CHARS[k]} {v}" for k, v in NAMES.items()) + " · 空格 空地"


def describe(plan):
    z = plan.get("zones", {})
    parts = [f"{ZONE_NAMES[k]} ({v[0]},{v[1]}) {v[2]}x{v[3]}" for k, v in z.items()]
    return "农场分区：" + "；".join(parts) + f"；主干道 {len(plan.get('roads', []))} 条，路灯位 {len(plan.get('lamps', []))} 个"
