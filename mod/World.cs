using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Buildings;
using StardewValley.Objects;
using StardewValley.TerrainFeatures;
using StardewValley.Tools;
using SObject = StardewValley.Object;

namespace StardewAutoPilot
{
    /// <summary>An exit from one location to another.</summary>
    internal class Exit
    {
        public string To;
        public string Kind; // warp | door | building
        public int X, Y;
        public int TargetX = -1, TargetY = -1;

        public Dictionary<string, object> ToJson() => new() { ["to"] = this.To, ["kind"] = this.Kind, ["x"] = this.X, ["y"] = this.Y };
    }

    internal static class World
    {
        public static Farmer P => Game1.player;

        public static int Manhattan(Point a, Point b) => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        public static int Chebyshev(Point a, Point b) => Math.Max(Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y));

        /// <summary>Farmer bounding box offset/size relative to Position, measured at runtime.</summary>
        public static Rectangle FarmerBoxAt(Point tile)
        {
            var bb = P.GetBoundingBox();
            return new Rectangle(tile.X * 64 + 32 - bb.Width / 2, tile.Y * 64 + 32 - bb.Height / 2, bb.Width, bb.Height);
        }

        /// <summary>The Position that puts the farmer's bounding box at the center of a tile.</summary>
        public static Vector2 PositionFor(Point tile)
        {
            var bb = P.GetBoundingBox();
            float offX = bb.X - P.Position.X, offY = bb.Y - P.Position.Y;
            var box = FarmerBoxAt(tile);
            return new Vector2(box.X - offX, box.Y - offY);
        }

        public static bool InBounds(GameLocation loc, int x, int y) => loc.isTileOnMap(new Vector2(x, y));

        public static bool IsWalkable(GameLocation loc, int x, int y)
        {
            if (!InBounds(loc, x, y))
                return false;
            // no isWaterTile check: bridges are walkable tiles with water underneath, and real water
            // is already fenced off by colliding shore tiles, so the game's own collision decides
            // pathfinding: true ignores characters (pets sleeping on the bed, villagers walking by), like the game's own pathfinder
            return !loc.isCollidingPosition(FarmerBoxAt(new Point(x, y)), Game1.viewport, true, 0, false, P, pathfinding: true);
        }

        /// <summary>BFS over walkable tiles. Returns the steps after <paramref name="start"/>, or null if no goal is reachable.</summary>
        public static List<Point> FindPath(GameLocation loc, Point start, Func<Point, bool> isGoal, int maxNodes = 30000)
        {
            if (isGoal(start))
                return new List<Point>();
            var prev = new Dictionary<Point, Point> { [start] = start };
            var queue = new Queue<Point>();
            queue.Enqueue(start);
            var dirs = new[] { new Point(0, -1), new Point(1, 0), new Point(0, 1), new Point(-1, 0) };
            while (queue.Count > 0 && prev.Count < maxNodes)
            {
                var cur = queue.Dequeue();
                foreach (var d in dirs)
                {
                    var next = new Point(cur.X + d.X, cur.Y + d.Y);
                    if (prev.ContainsKey(next) || !IsWalkable(loc, next.X, next.Y))
                        continue;
                    prev[next] = cur;
                    if (isGoal(next))
                    {
                        var path = new List<Point>();
                        for (var p = next; p != start; p = prev[p])
                            path.Add(p);
                        path.Reverse();
                        return path;
                    }
                    queue.Enqueue(next);
                }
            }
            return null;
        }

        public static int DirectionTo(Point from, Point to)
        {
            int dx = to.X - from.X, dy = to.Y - from.Y;
            if (Math.Abs(dx) > Math.Abs(dy))
                return dx > 0 ? 1 : 3;
            return dy > 0 ? 2 : 0;
        }

        // ---------------- items & tools ----------------

        public static int FindToolSlot(string kind)
        {
            kind = (kind ?? "").ToLowerInvariant().Replace(" ", "_");
            for (int i = 0; i < P.Items.Count; i++)
            {
                var item = P.Items[i];
                bool match = kind switch
                {
                    "hoe" => item is Hoe,
                    "watering_can" or "wateringcan" or "can" => item is WateringCan,
                    "axe" => item is Axe,
                    "pickaxe" => item is Pickaxe,
                    "scythe" => item is MeleeWeapon w && w.isScythe(),
                    "sword" or "weapon" => item is MeleeWeapon w2 && !w2.isScythe(),
                    "rod" or "fishing_rod" => item is FishingRod,
                    _ => false
                };
                if (match)
                    return i;
            }
            return -1;
        }

        /// <summary>Find an inventory slot by slot number, qualified id, item id or (partial) name.</summary>
        public static int FindItemSlot(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return -1;
            if (int.TryParse(query, out int slot) && slot >= 0 && slot < P.Items.Count && P.Items[slot] != null)
                return slot;
            string q = query.Trim().ToLowerInvariant();
            int partial = -1;
            for (int i = 0; i < P.Items.Count; i++)
            {
                var item = P.Items[i];
                if (item == null)
                    continue;
                if (item.QualifiedItemId.ToLowerInvariant() == q || item.ItemId.ToLowerInvariant() == q
                    || item.DisplayName.ToLowerInvariant() == q || item.Name.ToLowerInvariant() == q)
                    return i;
                if (partial < 0 && (item.DisplayName.ToLowerInvariant().Contains(q) || item.Name.ToLowerInvariant().Contains(q)))
                    partial = i;
            }
            return partial;
        }

        // ---------------- classification ----------------

        public static string ObjectKind(SObject obj)
        {
            if (obj is Chest)
                return "chest";
            string name = obj.Name ?? "";
            if (obj.IsSpawnedObject)
                return "forage";
            if (name.Contains("Weed"))
                return "weed";
            if (name == "Stone" || name.Contains("Stone") && !obj.bigCraftable.Value)
                return "stone";
            if (name == "Twig")
                return "twig";
            if (obj.bigCraftable.Value)
                return "machine";
            return "object";
        }

        public static string CropName(Crop crop)
        {
            try { return ItemRegistry.GetDataOrErrorItem("(O)" + crop.indexOfHarvest.Value).DisplayName; }
            catch { return crop.indexOfHarvest.Value; }
        }

        public static Building ShippingBin(Farm farm) => farm.buildings.FirstOrDefault(b => b is ShippingBin);

        public static IEnumerable<Point> BuildingTiles(Building b)
        {
            for (int x = 0; x < b.tilesWide.Value; x++)
                for (int y = 0; y < b.tilesHigh.Value; y++)
                    yield return new Point(b.tileX.Value + x, b.tileY.Value + y);
        }

        // ---------------- location graph ----------------

        public static List<Exit> GetExits(GameLocation loc)
        {
            // de-duplicate (some maps define several adjacent warp tiles to the same place)
            return AllExits(loc)
                .GroupBy(e => (e.To, e.Kind))
                .SelectMany(g => g.Key.Kind == "warp" ? new[] { g.OrderBy(e => Manhattan(new Point(e.X, e.Y), P.TilePoint)).First() } : g.ToArray())
                .ToList();
        }

        /// <summary>Every warp, door and building exit, including adjacent tiles that lead to the same place.</summary>
        public static List<Exit> AllExits(GameLocation loc)
        {
            var exits = new List<Exit>();
            foreach (var w in loc.warps)
                exits.Add(new Exit { To = w.TargetName, Kind = "warp", X = w.X, Y = w.Y, TargetX = w.TargetX, TargetY = w.TargetY });
            foreach (var pair in loc.doors.Pairs)
                exits.Add(new Exit { To = pair.Value, Kind = "door", X = pair.Key.X, Y = pair.Key.Y });
            foreach (var b in loc.buildings)
            {
                var indoors = b.GetIndoors();
                if (indoors == null || b.humanDoor.Value.X < 0)
                    continue;
                exits.Add(new Exit { To = indoors.NameOrUniqueName, Kind = "building", X = b.tileX.Value + b.humanDoor.Value.X, Y = b.tileY.Value + b.humanDoor.Value.Y });
            }
            return exits;
        }

        /// <summary>
        /// An exit to <paramref name="to"/> that can actually be walked to.
        /// Maps repeat a warp along a whole edge; the tile nearest the player is often a cliff,
        /// and Backwoods is two disconnected regions, so the nearest warp is not always the road.
        /// </summary>
        public static Exit ReachableExit(GameLocation loc, string to)
        {
            var exits = AllExits(loc).Where(e => string.Equals(e.To, to, StringComparison.OrdinalIgnoreCase)).ToList();
            if (exits.Count == 0)
                return null;
            var goal = new Dictionary<Point, Exit>();
            foreach (var exit in exits)
                foreach (var tile in ApproachTiles(loc, exit))
                    if (!goal.ContainsKey(tile))
                        goal[tile] = exit;
            if (goal.ContainsKey(P.TilePoint))
                return goal[P.TilePoint];
            var path = FindPath(loc, P.TilePoint, goal.ContainsKey);
            if (path == null || path.Count == 0)
                return null;
            return goal.TryGetValue(path[^1], out var found) ? found : null;
        }

        private static IEnumerable<Point> ApproachTiles(GameLocation loc, Exit exit)
        {
            if (exit.Kind == "warp")
            {
                int w = loc.Map.Layers[0].LayerWidth, h = loc.Map.Layers[0].LayerHeight;
                var tile = new Point(Math.Clamp(exit.X, 0, w - 1), Math.Clamp(exit.Y, 0, h - 1));
                for (int dy = -2; dy <= 2; dy++)
                    for (int dx = -2; dx <= 2; dx++)
                    {
                        if (Math.Abs(dx) + Math.Abs(dy) > 2)
                            continue;
                        int x = tile.X + dx, y = tile.Y + dy;
                        if (InBounds(loc, x, y))
                            yield return new Point(x, y);
                    }
                yield break;
            }
            var door = new Point(exit.X, exit.Y);
            var south = new Point(door.X, door.Y + 1);
            if (InBounds(loc, south.X, south.Y))
                yield return south;
            foreach (var p in new[] { new Point(door.X + 1, door.Y), new Point(door.X - 1, door.Y), new Point(door.X, door.Y - 1) })
                if (InBounds(loc, p.X, p.Y))
                    yield return p;
        }

        /// <summary>Find a sequence of location names from the current location to the target (inclusive of the target).</summary>
        /// <summary>Walking path to the tile from which an exit can be taken, or null if unreachable.</summary>
        public static List<Point> PathToExit(GameLocation loc, Exit exit)
        {
            if (exit.Kind == "warp")
            {
                int w = loc.Map.Layers[0].LayerWidth, h = loc.Map.Layers[0].LayerHeight;
                var tile = new Point(Math.Clamp(exit.X, 0, w - 1), Math.Clamp(exit.Y, 0, h - 1));
                return FindPath(loc, P.TilePoint, p => Manhattan(p, tile) <= 1)
                    ?? FindPath(loc, P.TilePoint, p => Manhattan(p, tile) <= 2);
            }
            var door = new Point(exit.X, exit.Y);
            return FindPath(loc, P.TilePoint, p => p.X == door.X && p.Y == door.Y + 1)
                ?? FindPath(loc, P.TilePoint, p => Manhattan(p, door) == 1);
        }

        public static List<string> FindRoute(string from, string to, HashSet<(string, string)> blocked = null)
        {
            if (string.Equals(from, to, StringComparison.OrdinalIgnoreCase))
                return new List<string>();
            var prev = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) { [from] = null };
            var queue = new Queue<string>();
            queue.Enqueue(from);
            while (queue.Count > 0 && prev.Count < 400)
            {
                string cur = queue.Dequeue();
                var loc = Game1.getLocationFromName(cur);
                if (loc == null)
                    continue;
                foreach (var exit in GetExitsRaw(loc))
                {
                    if (exit == null || prev.ContainsKey(exit) || blocked != null && blocked.Contains((cur.ToLowerInvariant(), exit.ToLowerInvariant())))
                        continue;
                    prev[exit] = cur;
                    if (string.Equals(exit, to, StringComparison.OrdinalIgnoreCase))
                    {
                        var route = new List<string>();
                        for (string n = exit; n != null && !string.Equals(n, from, StringComparison.OrdinalIgnoreCase); n = prev[n])
                            route.Add(n);
                        route.Reverse();
                        return route;
                    }
                    queue.Enqueue(exit);
                }
            }
            return null;
        }

        private static IEnumerable<string> GetExitsRaw(GameLocation loc)
        {
            foreach (var w in loc.warps)
                yield return w.TargetName;
            foreach (var pair in loc.doors.Pairs)
                yield return pair.Value;
            foreach (var b in loc.buildings)
            {
                var indoors = b.GetIndoors();
                if (indoors != null && b.humanDoor.Value.X >= 0)
                    yield return indoors.NameOrUniqueName;
            }
        }
    }
}
