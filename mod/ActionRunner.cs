using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Locations;
using StardewValley.Menus;
using StardewValley.Pathfinding;
using StardewValley.TerrainFeatures;
using StardewValley.Tools;
using SObject = StardewValley.Object;

namespace StardewAutoPilot
{
    internal class ActionFailed : Exception
    {
        public ActionFailed(string message) : base(message) { }
    }

    /// <summary>Runs one high-level action at a time as a coroutine, one step per game tick.</summary>
    internal class ActionRunner
    {
        private class Job
        {
            public string Type;
            public IEnumerator<object> Routine;
            public TaskCompletionSource<Dictionary<string, object>> Tcs;
            public string Message;
            public long StartSeq;
            public readonly Dictionary<string, object> Data = new();
        }

        public static readonly string[] ActionTypes =
        {
            "move_to", "goto_location", "use_tool", "interact", "place", "select", "eat", "ship", "ship_produce",
            "open_shop", "buy", "dialog_answer", "dialog_advance", "menu_click", "choose_profession", "close_menu",
            "wait", "sleep", "check_mail", "craft", "store", "take", "fish", "mine", "leave_mine", "fight", "donate", "build", "buy_animal", "care_animals", "clear_area", "load_machines", "collect_machines", "cook", "buy_backpack", "buy_weapon", "lay_path", "upgrade_tool", "festival", "water_crops", "harvest_crops", "clear_debris", "plant_seeds", "forage"
        };

        // categories sold by ship_produce: vegetable, fruit, flower, forage, fish, egg, milk, artisan, animal goods, mineral, gem, syrup, monster loot
        private static readonly HashSet<int> ProduceCategories = new() { -75, -79, -80, -81, -4, -5, -6, -26, -18, -12, -2, -27, -28 };

        private readonly ModEntry mod;
        private Job job;

        public ActionRunner(ModEntry mod) { this.mod = mod; }

        public bool Busy => this.job != null;
        public string CurrentType => this.job?.Type;
        private static Farmer P => Game1.player;
        private Job J => this.job;

        public static Dictionary<string, object> Fail(string message) => new() { ["ok"] = false, ["message"] = message };

        public Task<Dictionary<string, object>> Start(JsonElement args)
        {
            var tcs = new TaskCompletionSource<Dictionary<string, object>>(TaskCreationOptions.RunContinuationsAsynchronously);
            string type = Str(args, "type") ?? "";
            if (!Context.IsWorldReady)
                tcs.SetResult(Fail("world not ready"));
            else if (this.job != null)
                tcs.SetResult(Fail($"busy with '{this.job.Type}'"));
            else
            {
                try
                {
                    var routine = this.Build(type, args);
                    this.job = new Job { Type = type, Routine = routine.GetEnumerator(), Tcs = tcs, StartSeq = this.mod.Log.LastSeq };
                    this.mod.Monitor.Log($"Action: {args.GetRawText()}", LogLevel.Trace);
                }
                catch (ActionFailed ex)
                {
                    tcs.SetResult(Fail(ex.Message));
                }
            }
            return tcs.Task;
        }

        public void Tick()
        {
            if (this.job == null)
                return;
            try
            {
                if (!this.job.Routine.MoveNext())
                    this.Finish(true, this.job.Message ?? "done");
            }
            catch (ActionFailed ex)
            {
                this.Finish(false, ex.Message);
            }
            catch (Exception ex)
            {
                this.mod.Monitor.Log($"Action '{this.job.Type}' crashed: {ex}", LogLevel.Warn);
                this.Finish(false, $"{this.job.Type} crashed: {ex.GetType().Name}: {ex.Message}");
            }
        }

        public void Cancel(string reason)
        {
            if (this.job != null)
                this.Finish(false, "cancelled: " + reason);
        }

        private void Finish(bool ok, string message)
        {
            var job = this.job;
            this.job = null;
            try { P.Halt(); P.FarmerSprite.StopAnimation(); } catch { }

            var result = new Dictionary<string, object>(job.Data) { ["ok"] = ok, ["action"] = job.Type, ["message"] = message };
            // what the game said while this ran (NPC dialogue, HUD popups, letters), since dialogue is auto-advanced
            var said = this.mod.Log.Since(job.StartSeq, 40)
                .Where(m => (string)m["kind"] is "dialogue" or "question" or "hud" or "mail" or "event")
                .Select(m => $"[{m["kind"]}] {m["text"]}")
                .TakeLast(8)
                .ToList();
            if (said.Count > 0)
                result["game_messages"] = said;
            if (Context.IsWorldReady)
            {
                result["after"] = new Dictionary<string, object>
                {
                    ["location"] = Game1.currentLocation?.NameOrUniqueName,
                    ["x"] = P.TilePoint.X,
                    ["y"] = P.TilePoint.Y,
                    ["stamina"] = (int)P.Stamina,
                    ["money"] = P.Money,
                    ["time"] = Game1.timeOfDay,
                    ["menu"] = Game1.activeClickableMenu?.GetType().Name
                };
            }
            this.mod.Log.Add(ok ? "action_ok" : "action_fail", $"{job.Type}: {message}");
            job.Tcs.TrySetResult(result);
        }

        // =====================================================================
        // dispatch
        // =====================================================================

        private IEnumerable<object> Build(string type, JsonElement a)
        {
            switch (type)
            {
                case "move_to": return this.MoveTo(XY(a));
                case "goto_location": return this.GotoLocation(Req(a, "location"));
                case "use_tool": return this.UseTool(Req(a, "tool"), XY(a), Math.Clamp(Int(a, "times", 1), 1, 30), Bool(a, "until_cleared"));
                case "interact": return this.Interact(Str(a, "npc") == null ? XY(a) : (Point?)null, Str(a, "npc"), Str(a, "gift") ?? Str(a, "item"));
                case "place": return this.Place(Req(a, "item"), XY(a));
                case "select": return this.Select(Req(a, "item"));
                case "eat": return this.Eat(Req(a, "item"));
                case "ship": return this.Ship(Req(a, "item"), Int(a, "count", int.MaxValue));
                case "ship_produce": return this.ShipProduce(StrList(a, "except"));
                case "open_shop": return this.OpenShop(Req(a, "shop_id"));
                case "buy": return this.Buy(Req(a, "item"), Math.Max(1, Int(a, "count", 1)));
                case "dialog_answer": return this.DialogAnswer(Int(a, "index", -1));
                case "dialog_advance": return this.DialogAdvance();
                case "menu_click": return this.MenuClick(Int(a, "index", -1));
                case "choose_profession": return this.ChooseProfession(Req(a, "side"));
                case "close_menu": return this.CloseMenu();
                case "wait": return this.Wait(Math.Clamp(Int(a, "minutes", 10), 10, 600));
                case "sleep": return this.Sleep();
                case "check_mail": return this.CheckMail();
                case "fish": return this.Fish(Math.Clamp(Int(a, "casts", 5), 1, 30));
                case "mine": return this.Mine(Math.Clamp(Int(a, "floors", 3), 1, 20), Math.Clamp(Int(a, "max_floor", 120), 1, 120));
                case "leave_mine": return this.LeaveMine();
                case "donate": return this.Donate();
                case "build": return this.Build(Req(a, "building"), XY(a));
                case "buy_animal": return this.BuyAnimal(Req(a, "animal"));
                case "care_animals": return this.CareAnimals();
                case "load_machines": return this.LoadMachines(Str(a, "item"));
                case "collect_machines": return this.CollectMachines();
                case "buy_backpack": return this.BuyBackpack();
                case "cook": return this.Cook(Req(a, "item"), Math.Clamp(Int(a, "count", 1), 1, 30));
                case "clear_area": return this.ClearArea(RectArg(a, "area") ?? throw new ActionFailed("missing 'area' {x,y,w,h}"));
                case "fight": return this.Fight(Math.Clamp(Int(a, "range", 6), 1, 15));
                case "buy_weapon": return this.BuyWeapon();
                case "upgrade_tool": return this.UpgradeTool(Str(a, "tool"));
                case "festival": return this.Festival(Req(a, "activity"));
                case "lay_path": return this.LayPath(TilesArg(a, "tiles"), Req(a, "item"));
                case "craft": return this.CraftAction(Req(a, "item"), Math.Clamp(Int(a, "count", 1), 1, 99), OptXY(a));
                case "store": return this.Store(StrList(a, "items"), OptXY(a));
                case "take": return this.Take(Req(a, "item"), Math.Max(1, Int(a, "count", 999)), OptXY(a));
                case "water_crops": return this.WaterCrops(Int(a, "max", 200));
                case "harvest_crops": return this.HarvestCrops(Int(a, "max", 200));
                case "clear_debris": return this.ClearDebris(OptXY(a), Int(a, "radius", 8), Int(a, "max", 25), StrList(a, "kinds"));
                case "plant_seeds":
                    return RectArg(a, "plot") is { } plot
                        ? this.PlantInPlot(Req(a, "item"), Int(a, "count", 999), plot)
                        : this.PlantSeeds(Req(a, "item"), Int(a, "count", 999), OptXY(a) ?? P.TilePoint);
                case "forage": return this.Forage(Int(a, "max", 30));
                default:
                    throw new ActionFailed($"unknown action '{type}'. Available: {string.Join(", ", ActionTypes)}");
            }
        }

        // =====================================================================
        // movement
        // =====================================================================

        /// <summary>
        /// If a bad warp left the farmer inside a wall or off the walkable map (no path anywhere), step onto the
        /// nearest walkable tile. Only runs in that broken state; normal movement never teleports.
        /// </summary>
        private void Unstick()
        {
            var loc = Game1.currentLocation;
            var here = P.TilePoint;
            if (World.IsWalkable(loc, here.X, here.Y))
                return;
            for (int r = 1; r <= 12; r++)
                for (int dx = -r; dx <= r; dx++)
                    for (int dy = -r; dy <= r; dy++)
                    {
                        if (Math.Max(Math.Abs(dx), Math.Abs(dy)) != r)
                            continue;
                        var t = new Point(here.X + dx, here.Y + dy);
                        // must be walkable and actually connected to somewhere (not another sealed pocket)
                        if (!World.IsWalkable(loc, t.X, t.Y) || World.FindPath(loc, t, p => World.Manhattan(p, t) >= 4, 400) == null)
                            continue;
                        P.Position = World.PositionFor(t);
                        this.mod.Log.Add("hud", $"Unstuck: moved from ({here.X},{here.Y}) to ({t.X},{t.Y})");
                        this.mod.Monitor.Log($"Farmer was stuck at ({here.X},{here.Y}) in {loc.NameOrUniqueName}; moved to ({t.X},{t.Y}).", LogLevel.Warn);
                        return;
                    }
            // nothing nearby: fall back to the location's warp target from the farm side
            if (loc.Name != "Farm" && loc.Name != "FarmHouse")
            {
                this.mod.Monitor.Log($"Farmer stuck at ({here.X},{here.Y}) in {loc.NameOrUniqueName} with no walkable tile nearby; returning home.", LogLevel.Warn);
                Game1.warpFarmer("FarmHouse", 9, 9, 2);
            }
        }

        private IEnumerable<object> EnsureFree()
        {
            for (int i = 0; ; i++)
            {
                if (Context.IsPlayerFree && !P.UsingTool && !P.isEating && !Game1.isWarping && !Game1.fadeToBlack)
                {
                    this.Unstick();
                    yield break;
                }
                if (i == 240 && Game1.activeClickableMenu == null && !Game1.eventUp && !Game1.isWarping)
                {
                    // a tool swing or fade that never finished (seen after mining): reset it the way the game cancels an action
                    this.mod.Monitor.Log($"Player stuck (usingTool={P.UsingTool}, eating={P.isEating}, fade={Game1.fadeToBlack}, canMove={P.CanMove}); resetting.", LogLevel.Warn);
                    P.completelyStopAnimatingOrDoingAction();
                    P.UsingTool = false;
                    P.CanMove = true;
                    if (Game1.fadeToBlack && !Game1.isWarping)
                        Game1.fadeToBlack = false;
                }
                if (i > 360)
                {
                    var menu = Game1.activeClickableMenu;
                    throw new ActionFailed(menu != null
                        ? $"a menu is open ({menu.GetType().Name}); handle it first (dialog_answer / dialog_advance / menu_click / close_menu)"
                        : Game1.eventUp ? "a cutscene/event is running"
                        : $"player is busy (usingTool={P.UsingTool}, eating={P.isEating}, warping={Game1.isWarping}, fade={Game1.fadeToBlack})");
                }
                yield return null;
            }
        }

        private static float MoveSpeed()
        {
            try { return Math.Clamp(P.getMovementSpeed(), 2f, 10f); }
            catch { return 5f; }
        }

        private IEnumerable<object> WalkPath(List<Point> path)
        {
            if (path.Count == 0)
                yield break;
            var loc = Game1.currentLocation;
            var end = path[^1];
            try
            {
                for (int attempt = 0; attempt < 4; attempt++)
                {
                    // let the game's own pathfinding controller drive the farmer: real running animation, speed and collision
                    var stack = new Stack<Point>();
                    for (int i = path.Count - 1; i >= 0; i--)
                        stack.Push(path[i]);
                    P.controller = new PathFindController(stack, loc, P, end);
                    var lastTile = P.TilePoint;
                    int still = 0;
                    for (int guard = 0; guard < 60 * 120; guard++)
                    {
                        if (!ReferenceEquals(Game1.currentLocation, loc))
                            yield break; // walked into an automatic warp
                        if (P.controller == null)
                            break;
                        if (Game1.activeClickableMenu != null)
                        {
                            P.controller = null;
                            yield break; // a dialog/menu opened on the way; the caller decides what to do with it
                        }
                        P.setRunning(true, true);
                        still = P.TilePoint == lastTile ? still + 1 : 0;
                        lastTile = P.TilePoint;
                        if (still > 90 && Context.IsPlayerFree)
                            break; // blocked (usually by an NPC); re-plan below
                        yield return null;
                    }
                    P.controller = null;
                    if (P.TilePoint == end)
                        yield break;

                    for (int i = 0; i < 20; i++)
                        yield return null;
                    path = World.FindPath(loc, P.TilePoint, p => p == end);
                    if (path == null || path.Count == 0)
                        break;
                }
                if (P.TilePoint != end)
                    throw new ActionFailed($"could not reach ({end.X},{end.Y}); stopped at ({P.TilePoint.X},{P.TilePoint.Y})");
            }
            finally
            {
                if (P.controller != null)
                    P.controller = null;
                StopMoving();
            }
        }

        private static void StopMoving()
        {
            try
            {
                P.movementDirections.Clear();
                P.Halt();
            }
            catch { }
        }

        private IEnumerable<object> WalkTo(Point target, bool adjacent)
        {
            foreach (var o in this.EnsureFree()) yield return o;
            var loc = Game1.currentLocation;
            var start = P.TilePoint;
            List<Point> path = adjacent
                ? World.FindPath(loc, start, p => World.Manhattan(p, target) == 1)
                  ?? World.FindPath(loc, start, p => World.Chebyshev(p, target) == 1)
                : World.FindPath(loc, start, p => p == target)
                  ?? World.FindPath(loc, start, p => World.Manhattan(p, target) <= 1);
            if (path == null)
                throw new ActionFailed($"no walkable path from ({start.X},{start.Y}) to {(adjacent ? "next to " : "")}({target.X},{target.Y}) in {loc.NameOrUniqueName}");
            foreach (var o in this.WalkPath(path)) yield return o;
        }

        private IEnumerable<object> MoveTo(Point target)
        {
            foreach (var o in this.WalkTo(target, adjacent: false)) yield return o;
            J.Message = $"at ({P.TilePoint.X},{P.TilePoint.Y})";
        }

        /// <summary>Walk to whichever goal tile is nearest; returns the goal reached via <paramref name="reached"/>.</summary>
        private IEnumerable<object> WalkToNearest(Func<Point, bool> isGoal, Action<Point> reached)
        {
            var path = World.FindPath(Game1.currentLocation, P.TilePoint, isGoal);
            if (path == null)
            {
                reached(new Point(-1, -1));
                yield break;
            }
            foreach (var o in this.WalkPath(path)) yield return o;
            reached(P.TilePoint);
        }

        private IEnumerable<object> GotoLocation(string name)
        {
            if (Game1.currentLocation is MineShaft && !string.Equals(name, Game1.currentLocation.NameOrUniqueName, StringComparison.OrdinalIgnoreCase))
                foreach (var o in this.LeaveMine()) yield return o;
            var blocked = new HashSet<(string, string)>();
            for (int leg = 0; leg < 40; leg++)
            {
                foreach (var o in this.EnsureFree()) yield return o;
                var cur = Game1.currentLocation;
                if (string.Equals(cur.NameOrUniqueName, name, StringComparison.OrdinalIgnoreCase) || string.Equals(cur.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    J.Message = $"arrived at {cur.NameOrUniqueName} ({P.TilePoint.X},{P.TilePoint.Y})";
                    yield break;
                }
                var route = World.FindRoute(cur.NameOrUniqueName, name, blocked)
                    ?? throw new ActionFailed($"no reachable route from {cur.NameOrUniqueName} to {name}" + (blocked.Count > 0 ? $" (unreachable exits: {string.Join(", ", blocked.Select(b => b.Item1 + "->" + b.Item2))})" : ""));
                string next = route[0];
                var exit = World.GetExits(cur)
                    .Where(e => string.Equals(e.To, next, StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault(e => World.PathToExit(cur, e) != null);
                if (exit == null)
                {
                    blocked.Add((cur.NameOrUniqueName.ToLowerInvariant(), next.ToLowerInvariant()));
                    continue;
                }
                foreach (var o in this.TakeExit(cur, exit)) yield return o;
            }
            throw new ActionFailed("too many legs while travelling to " + name);
        }

        private IEnumerable<object> TakeExit(GameLocation loc, Exit exit)
        {
            if (exit.Kind == "warp")
            {
                var path = World.PathToExit(loc, exit) ?? throw new ActionFailed($"can't reach exit to {exit.To} at ({exit.X},{exit.Y})");
                foreach (var o in this.WalkPath(path)) yield return o;
                if (ReferenceEquals(Game1.currentLocation, loc))
                    Game1.warpFarmer(exit.To, exit.TargetX, exit.TargetY, P.FacingDirection);
            }
            else
            {
                var door = new Point(exit.X, exit.Y);
                var path = World.PathToExit(loc, exit) ?? throw new ActionFailed($"can't reach door to {exit.To} at ({door.X},{door.Y})");
                foreach (var o in this.WalkPath(path)) yield return o;
                P.faceDirection(World.DirectionTo(P.TilePoint, door));
                loc.checkAction(new xTile.Dimensions.Location(door.X, door.Y), Game1.viewport, P);
            }

            for (int i = 0; i < 300; i++)
            {
                if (!ReferenceEquals(Game1.currentLocation, loc) && !Game1.isWarping && !Game1.fadeToBlack)
                    yield break;
                yield return null;
            }
            var hud = this.mod.Log.Since(0, 20).Where(m => (string)m["kind"] is "hud" or "dialogue").TakeLast(2).Select(m => m["text"]);
            throw new ActionFailed($"exit to {exit.To} did not open (closed? locked? check opening hours). Recent messages: {string.Join(" | ", hud)}");
        }

        // =====================================================================
        // tools & interaction
        // =====================================================================

        private static void Face(Point target)
        {
            if (P.TilePoint != target)
                P.faceDirection(World.DirectionTo(P.TilePoint, target));
        }

        private static bool TileCleared(GameLocation loc, Point t)
        {
            var v = new Vector2(t.X, t.Y);
            if (loc.objects.ContainsKey(v))
                return false;
            if (loc.terrainFeatures.TryGetValue(v, out var tf) && (tf is Tree || tf is FruitTree))
                return false;
            return !loc.resourceClumps.Any(r => r.occupiesTile(t.X, t.Y));
        }

        /// <summary>Use a tool once on a tile; walks next to it first if needed.</summary>
        private IEnumerable<object> UseToolOnce(string kind, Point target)
        {
            int slot = World.FindToolSlot(kind);
            if (slot < 0)
                throw new ActionFailed($"no {kind} in inventory");
            if (World.Chebyshev(P.TilePoint, target) > 1)
                foreach (var o in this.WalkTo(target, adjacent: true)) yield return o;
            foreach (var o in this.EnsureFree()) yield return o;

            var tool = (Tool)P.Items[slot];
            if (P.Stamina <= 1 && tool is not MeleeWeapon)
                throw new ActionFailed("too exhausted to use tools (stamina <= 1); eat something or sleep");

            Face(target);
            P.CurrentToolIndex = slot;
            var loc = Game1.currentLocation;
            var v = new Vector2(target.X, target.Y);
            float oldStamina = P.Stamina;

            if (tool is MeleeWeapon)
            {
                if (loc.objects.TryGetValue(v, out var obj))
                {
                    if (obj.performToolAction(tool))
                        loc.objects.Remove(v);
                }
                else if (loc.terrainFeatures.TryGetValue(v, out var tf) && tf.performToolAction(tool, 0, v))
                    loc.terrainFeatures.Remove(v);
            }
            else
            {
                tool.DoFunction(loc, target.X * 64 + 32, target.Y * 64 + 32, 1, P);
                // weeds/twigs sometimes need the object's own handler
                if (tool is Axe or Pickaxe && loc.objects.TryGetValue(v, out var leftover) && World.ObjectKind(leftover) is "weed" or "twig")
                {
                    if (leftover.performToolAction(tool))
                        loc.objects.Remove(v);
                }
            }
            P.checkForExhaustion(oldStamina);
            for (int i = 0; i < 12; i++)
                yield return null;
        }

        private IEnumerable<object> UseTool(string kind, Point target, int times, bool untilCleared)
        {
            int max = untilCleared ? 40 : times;
            int used = 0;
            for (; used < max; used++)
            {
                if (untilCleared && TileCleared(Game1.currentLocation, target))
                    break;
                foreach (var o in this.UseToolOnce(kind, target)) yield return o;
            }
            J.Message = $"used {kind} {used}x at ({target.X},{target.Y})" + (untilCleared ? (TileCleared(Game1.currentLocation, target) ? ", tile cleared" : ", NOT cleared (tool too weak?)") : "");
        }

        private IEnumerable<object> RefillWateringCan()
        {
            var loc = Game1.currentLocation;
            Point water = new Point(-1, -1);
            bool IsRefillSpot(Point p)
            {
                foreach (var n in new[] { new Point(p.X, p.Y - 1), new Point(p.X + 1, p.Y), new Point(p.X, p.Y + 1), new Point(p.X - 1, p.Y) })
                    if (World.InBounds(loc, n.X, n.Y) && loc.CanRefillWateringCanOnTile(n.X, n.Y))
                    {
                        water = n;
                        return true;
                    }
                return false;
            }
            var path = World.FindPath(loc, P.TilePoint, IsRefillSpot, 60000)
                ?? throw new ActionFailed("watering can is empty and no water source is reachable here");
            foreach (var o in this.WalkPath(path)) yield return o;
            IsRefillSpot(P.TilePoint);
            foreach (var o in this.UseToolOnce("watering_can", water)) yield return o;
        }

        private IEnumerable<object> Interact(Point? tile, string npcName, string hold)
        {
            if (npcName != null && !Game1.currentLocation.characters.Any(c => string.Equals(c.Name, npcName, StringComparison.OrdinalIgnoreCase) || string.Equals(c.displayName, npcName, StringComparison.OrdinalIgnoreCase)))
            {
                // villagers follow schedules: go to wherever they are right now
                var where = Game1.getCharacterFromName(npcName)?.currentLocation
                            ?? Utility.getAllVillagers().FirstOrDefault(n => string.Equals(n.displayName, npcName, StringComparison.OrdinalIgnoreCase))?.currentLocation;
                if (where == null)
                    throw new ActionFailed($"can't find {npcName} anywhere right now");
                if (where is StardewValley.Locations.MineShaft || where.NameOrUniqueName == "Desert")
                    throw new ActionFailed($"{npcName} is in {where.NameOrUniqueName}, too far to go just to chat");
                if (GameData.LockedNow(where.NameOrUniqueName, out int opens))
                    throw new ActionFailed($"{npcName} is inside {where.NameOrUniqueName}, which is locked until {opens / 100}:{opens % 100:00}: skipped without walking there");
                foreach (var o in this.GotoLocation(where.NameOrUniqueName)) yield return o;
            }
            var loc = Game1.currentLocation;
            int holdSlot = hold != null ? this.RequireSlot(hold) : -1;
            for (int attempt = 0; attempt < 4; attempt++)
            {
                Point target;
                NPC npc = null;
                if (npcName != null)
                {
                    npc = loc.characters.FirstOrDefault(c => string.Equals(c.Name, npcName, StringComparison.OrdinalIgnoreCase) || string.Equals(c.displayName, npcName, StringComparison.OrdinalIgnoreCase))
                        ?? throw new ActionFailed($"{npcName} is not in {loc.NameOrUniqueName}");
                    target = npc.TilePoint;
                }
                else
                    target = tile.Value;

                if (World.Chebyshev(P.TilePoint, target) > 1)
                    foreach (var o in this.WalkTo(target, adjacent: true)) yield return o;
                if (npc != null && World.Chebyshev(P.TilePoint, npc.TilePoint) > 1)
                    continue; // npc moved away, chase again
                if (npc != null)
                    target = npc.TilePoint;

                foreach (var o in this.EnsureFree()) yield return o;
                Face(target);
                if (holdSlot >= 0)
                    P.CurrentToolIndex = holdSlot;
                else if (npc != null)
                {
                    // hold a tool (or nothing) so talking never gives the held item away as a gift
                    int safe = Enumerable.Range(0, P.Items.Count).FirstOrDefault(i => P.Items[i] is Tool || P.Items[i] == null, -1);
                    if (safe >= 0)
                        P.CurrentToolIndex = safe;
                }
                bool acted = loc.checkAction(new xTile.Dimensions.Location(target.X, target.Y), Game1.viewport, P);
                for (int i = 0; i < 15; i++)
                    yield return null;
                J.Message = acted ? $"interacted with ({target.X},{target.Y})" : $"nothing to interact with at ({target.X},{target.Y})";
                if (Game1.activeClickableMenu != null)
                    J.Data["menu"] = MenuAutomation.Describe(this.mod, Game1.activeClickableMenu);
                if (!acted)
                    throw new ActionFailed(J.Message);
                yield break;
            }
            throw new ActionFailed($"could not catch up with {npcName}");
        }

        private int RequireSlot(string item)
        {
            int slot = World.FindItemSlot(item);
            if (slot < 0)
                throw new ActionFailed($"'{item}' not found in inventory");
            return slot;
        }

        private IEnumerable<object> Select(string item)
        {
            int slot = this.RequireSlot(item);
            P.CurrentToolIndex = slot;
            J.Message = $"holding {P.Items[slot].DisplayName} (slot {slot})";
            yield break;
        }

        /// <summary>Place an item (seed, fertilizer, object) on a tile. Assumes the player is next to it.</summary>
        private bool PlaceHere(int slot, Point target)
        {
            if (P.Items[slot] is not SObject item)
                return false;
            Face(target);
            P.CurrentToolIndex = slot;
            int before = item.Stack;
            bool ok = Utility.tryToPlaceItem(Game1.currentLocation, item, target.X * 64 + 32, target.Y * 64 + 32);
            if (ok && ReferenceEquals(P.Items[slot], item) && item.Stack == before)
                P.reduceActiveItemByOne();
            return ok;
        }

        private IEnumerable<object> Place(string item, Point target)
        {
            int slot = this.RequireSlot(item);
            string name = P.Items[slot].DisplayName;
            if (World.Chebyshev(P.TilePoint, target) > 1)
                foreach (var o in this.WalkTo(target, adjacent: true)) yield return o;
            foreach (var o in this.EnsureFree()) yield return o;
            if (!this.PlaceHere(slot, target))
                throw new ActionFailed($"can't place {name} at ({target.X},{target.Y}) (needs tilled soil for seeds? wrong season? tile occupied?)");
            J.Message = $"placed {name} at ({target.X},{target.Y})";
        }

        private IEnumerable<object> Eat(string item)
        {
            int slot = this.RequireSlot(item);
            if (P.Items[slot] is not SObject obj || obj.Edibility <= 0)
                throw new ActionFailed($"{P.Items[slot].DisplayName} is not edible");
            foreach (var o in this.EnsureFree()) yield return o;
            float stamina = P.Stamina;
            P.CurrentToolIndex = slot;
            P.eatHeldObject();
            for (int i = 0; i < 400 && P.isEating; i++)
                yield return null;
            J.Message = $"ate {obj.DisplayName}: stamina {(int)stamina} -> {(int)P.Stamina}";
        }

        // =====================================================================
        // selling & shops
        // =====================================================================

        private IEnumerable<object> WalkToShippingBin()
        {
            if (Game1.currentLocation is not Farm)
                foreach (var o in this.GotoLocation("Farm")) yield return o;
            var farm = (Farm)Game1.currentLocation;
            var bin = World.ShippingBin(farm) ?? throw new ActionFailed("no shipping bin on the farm");
            var tiles = World.BuildingTiles(bin).ToList();
            if (tiles.Any(t => World.Chebyshev(t, P.TilePoint) <= 1))
                yield break;
            var path = World.FindPath(farm, P.TilePoint, p => tiles.Any(t => World.Manhattan(p, t) == 1))
                ?? throw new ActionFailed("can't reach the shipping bin");
            foreach (var o in this.WalkPath(path)) yield return o;
        }

        private int ShipItem(Item item, int count)
        {
            var farm = Game1.getFarm();
            Item toShip;
            if (count >= item.Stack)
            {
                toShip = item;
                P.removeItemFromInventory(item);
            }
            else
            {
                toShip = item.getOne();
                toShip.Stack = count;
                item.Stack -= count;
            }
            farm.getShippingBin(P).Add(toShip);
            farm.lastItemShipped = toShip;
            return toShip is SObject o ? o.sellToStorePrice() * toShip.Stack : 0;
        }

        private IEnumerable<object> Ship(string item, int count)
        {
            int slot = this.RequireSlot(item);
            var it = P.Items[slot];
            if (!it.canBeShipped())
                throw new ActionFailed($"{it.DisplayName} can't be shipped");
            foreach (var o in this.WalkToShippingBin()) yield return o;
            int n = Math.Min(count, it.Stack);
            int value = this.ShipItem(it, n);
            J.Message = $"shipped {n}x {it.DisplayName} (~{value}g, paid overnight)";
        }

        private IEnumerable<object> ShipProduce(List<string> except)
        {
            var items = P.Items.Where(i => i != null && ProduceCategories.Contains(i.Category) && i.canBeShipped()
                                           && !except.Any(e => i.DisplayName.Contains(e, StringComparison.OrdinalIgnoreCase) || i.Name.Contains(e, StringComparison.OrdinalIgnoreCase)))
                .ToList();
            if (items.Count == 0)
            {
                J.Message = "nothing to ship";
                yield break;
            }
            foreach (var o in this.WalkToShippingBin()) yield return o;
            int total = 0;
            var names = new List<string>();
            foreach (var item in items)
            {
                names.Add($"{item.Stack}x {item.DisplayName}");
                total += this.ShipItem(item, item.Stack);
            }
            J.Data["shipped"] = names;
            J.Data["value"] = total;
            J.Message = $"shipped {names.Count} stacks worth ~{total}g (paid overnight)";
        }

        private IEnumerable<object> OpenShop(string shopId)
        {
            foreach (var o in this.EnsureFree()) yield return o;
            if (!Utility.TryOpenShopMenu(shopId, Game1.currentLocation, null, null, false, true, null))
                throw new ActionFailed($"can't open shop '{shopId}' here (wrong location, closed, or shopkeeper absent)");
            for (int i = 0; i < 10; i++)
                yield return null;
            J.Message = "shop opened";
            if (Game1.activeClickableMenu != null)
                J.Data["menu"] = MenuAutomation.Describe(this.mod, Game1.activeClickableMenu);
        }

        /// <summary>Pierre's backpack upgrade (a counter question in the game, not a shop item): same effect as GameLocation's "Backpack_Purchase".</summary>
        private IEnumerable<object> BuyBackpack()
        {
            int size = P.maxItems.Value;
            int cost = size == 12 ? 2000 : size < 36 ? 10000 : 0;
            if (cost == 0)
                throw new ActionFailed("the backpack is already at the largest size (36)");
            if (P.Money < cost)
                throw new ActionFailed($"the next backpack upgrade costs {cost}g, you have {P.Money}g");
            if (Game1.currentLocation.Name != "SeedShop")
                foreach (var o in this.GotoLocation("SeedShop")) yield return o;
            if (Game1.timeOfDay < 900 || Game1.timeOfDay >= 1700 || !ShopkeeperHere("Pierre"))
                throw new ActionFailed("Pierre isn't at the counter (open 9:00-17:00)");
            P.Money -= cost;
            if (size == 12)
                P.increaseBackpackSize(12);
            else
            {
                P.maxItems.Value += 12;
                while (P.Items.Count < P.maxItems.Value)
                    P.Items.Add(null);
            }
            J.Message = $"bought the backpack upgrade for {cost}g: now {P.maxItems.Value} slots";
        }

        private IEnumerable<object> Buy(string query, int count)
        {
            if (Game1.activeClickableMenu is not ShopMenu shop)
                throw new ActionFailed("no shop is open; use open_shop first");
            if (shop.currency != 0)
                throw new ActionFailed("this shop doesn't take gold");
            string q = query.ToLowerInvariant();
            var match = shop.itemPriceAndStock
                .Where(kv => kv.Key is Item { IsRecipe: false } && kv.Value.TradeItem == null)
                .OrderBy(kv => ((Item)kv.Key).QualifiedItemId.ToLowerInvariant() == q || kv.Key.DisplayName.ToLowerInvariant() == q ? 0 : 1)
                .FirstOrDefault(kv => ((Item)kv.Key).QualifiedItemId.ToLowerInvariant() == q || kv.Key.DisplayName.ToLowerInvariant().Contains(q) || kv.Key.Name.ToLowerInvariant().Contains(q));
            if (match.Key == null)
                throw new ActionFailed($"'{query}' is not sold here");
            var item = (Item)match.Key;
            var info = match.Value;
            if (info.Stock != int.MaxValue && info.Stock < count)
                throw new ActionFailed($"only {info.Stock} in stock");
            int price = info.Price * count;
            if (P.Money < price)
                throw new ActionFailed($"not enough money: {count}x {item.DisplayName} costs {price}g, you have {P.Money}g");
            var bought = ItemRegistry.Create(item.QualifiedItemId, count);
            if (!P.couldInventoryAcceptThisItem(bought))
                throw new ActionFailed("inventory full");
            P.addItemToInventoryBool(bought);
            P.Money -= price;
            if (info.Stock != int.MaxValue)
            {
                info.Stock -= count;
                shop.itemPriceAndStock[match.Key] = info;
            }
            J.Message = $"bought {count}x {item.DisplayName} for {price}g";
            yield break;
        }

        // =====================================================================
        // menus & dialogue
        // =====================================================================

        private IEnumerable<object> DialogAnswer(int index)
        {
            if (Game1.activeClickableMenu is not DialogueBox db || !db.isQuestion)
                throw new ActionFailed("no question dialog is open");
            if (index < 0 || db.responses == null || index >= db.responses.Count())
                throw new ActionFailed($"index out of range (0..{(db.responses?.Count() ?? 0) - 1})");
            string text = db.getCurrentString();
            string answer = db.responses.ElementAt(index).responseText;
            for (int i = 0; i < 180; i++)
            {
                if (!ReferenceEquals(Game1.activeClickableMenu, db) || db.getCurrentString() != text)
                    break;
                db.selectedResponse = index;
                db.receiveLeftClick(0, 0);
                yield return null;
            }
            for (int i = 0; i < 15; i++)
                yield return null;
            J.Message = $"answered '{answer}'";
            if (Game1.activeClickableMenu != null)
                J.Data["menu"] = MenuAutomation.Describe(this.mod, Game1.activeClickableMenu);
        }

        private IEnumerable<object> DialogAdvance()
        {
            if (Game1.activeClickableMenu is not DialogueBox db)
                throw new ActionFailed("no dialog is open");
            string text = db.getCurrentString();
            for (int i = 0; i < 240; i++)
            {
                if (!ReferenceEquals(Game1.activeClickableMenu, db) || db.getCurrentString() != text)
                    break;
                if (i % 10 == 0)
                    db.receiveLeftClick(0, 0);
                yield return null;
            }
            J.Message = "dialog advanced";
            if (Game1.activeClickableMenu != null)
                J.Data["menu"] = MenuAutomation.Describe(this.mod, Game1.activeClickableMenu);
        }

        private IEnumerable<object> MenuClick(int index)
        {
            var menu = Game1.activeClickableMenu ?? throw new ActionFailed("no menu is open");
            var comps = MenuAutomation.Components(menu);
            if (index < 0 || index >= comps.Count)
                throw new ActionFailed($"index out of range (0..{comps.Count - 1})");
            var c = comps[index];
            menu.receiveLeftClick(c.bounds.Center.X, c.bounds.Center.Y);
            for (int i = 0; i < 15; i++)
                yield return null;
            J.Message = $"clicked '{c.name}'";
            if (Game1.activeClickableMenu != null)
                J.Data["menu"] = MenuAutomation.Describe(this.mod, Game1.activeClickableMenu);
        }

        private IEnumerable<object> ChooseProfession(string side)
        {
            var menu = Game1.activeClickableMenu as LevelUpMenu ?? throw new ActionFailed("no level-up menu is open");
            // same steps the menu runs when a profession is clicked (it reads the real mouse, so clicks can't be simulated)
            var reflection = this.mod.Helper.Reflection;
            var choices = reflection.GetField<List<int>>(menu, "professionsToChoose").GetValue();
            if (choices.Count < 2)
                throw new ActionFailed("this level-up has no profession choice");
            int profession = choices[side.ToLowerInvariant().StartsWith("r") ? 1 : 0];
            P.professions.Add(profession);
            menu.getImmediateProfessionPerk(profession);
            menu.isActive = false;
            menu.informationUp = false;
            reflection.GetField<bool>(menu, "isProfessionChooser").SetValue(false);
            menu.RemoveLevelFromLevelList();
            for (int i = 0; i < 120 && ReferenceEquals(Game1.activeClickableMenu, menu); i++)
                yield return null;
            J.Message = $"chose profession {LevelUpMenu.getProfessionTitleFromNumber(profession)}";
        }

        private IEnumerable<object> CloseMenu()
        {
            var menu = Game1.activeClickableMenu ?? throw new ActionFailed("no menu is open");
            if (menu is DialogueBox { isQuestion: true })
                throw new ActionFailed("a question can't be closed; answer it with dialog_answer");
            if (menu is ShippingMenu or SaveGameMenu or LevelUpMenu || Game1.showingEndOfNightStuff)
                throw new ActionFailed("this is an end-of-night screen that saves the game; it closes by itself, just wait");
            menu.exitThisMenu();
            for (int i = 0; i < 10; i++)
                yield return null;
            J.Message = "menu closed";
        }

        // =====================================================================
        // time
        // =====================================================================

        private static int ToMinutes(int time) => time / 100 * 60 + time % 100;

        private IEnumerable<object> Wait(int minutes)
        {
            int start = ToMinutes(Game1.timeOfDay);
            for (int i = 0; i < 60 * 60 * 5; i++)
            {
                if (ToMinutes(Game1.timeOfDay) - start >= minutes)
                    break;
                yield return null;
            }
            J.Message = $"waited until {Game1.getTimeOfDayString(Game1.timeOfDay)}";
        }

        private IEnumerable<object> Sleep()
        {
            if (Game1.currentLocation is not FarmHouse)
                foreach (var o in this.GotoLocation("FarmHouse")) yield return o;
            foreach (var o in this.EnsureFree()) yield return o;
            var house = (FarmHouse)Game1.currentLocation;
            var bed = house.GetPlayerBedSpot();
            // walking can be interrupted by a popup; close it and keep going until we're at the bed
            for (int attempt = 0; attempt < 3 && World.Manhattan(P.TilePoint, bed) > 0; attempt++)
            {
                if (Game1.activeClickableMenu is DialogueBox { isQuestion: true } q && q.getCurrentString()?.Contains("sleep", StringComparison.OrdinalIgnoreCase) == true)
                    break;
                if (Game1.activeClickableMenu != null && Game1.activeClickableMenu is not DialogueBox { isQuestion: true })
                {
                    Game1.activeClickableMenu.exitThisMenu(false);
                    for (int i = 0; i < 10; i++) yield return null;
                }
                var path = World.FindPath(house, P.TilePoint, p => p == bed) ?? World.FindPath(house, P.TilePoint, p => World.Manhattan(p, bed) <= 1);
                if (path == null)
                    break;
                foreach (var o in this.WalkPath(path)) yield return o;
            }
            if (World.Manhattan(P.TilePoint, bed) > 1 && Game1.activeClickableMenu is not DialogueBox { isQuestion: true })
                throw new ActionFailed($"couldn't get to the bed at ({bed.X},{bed.Y}); stuck at ({P.TilePoint.X},{P.TilePoint.Y})");

            // stepping onto the bed makes the game ask "Go to sleep for the night?"; answer Yes like a player would
            for (int i = 0; i < 30 && Game1.activeClickableMenu == null; i++)
                yield return null;
            if (Game1.activeClickableMenu is DialogueBox box && box.isQuestion && box.responses != null)
            {
                int yes = box.responses.ToList().FindIndex(r => r.responseKey == "Yes");
                foreach (var o in this.DialogAnswer(Math.Max(0, yes))) yield return o;
            }
            else if (Game1.activeClickableMenu == null)
                house.answerDialogueAction("Sleep_Yes", Array.Empty<string>());

            for (int i = 0; i < 300; i++)
            {
                // a screen fade alone isn't proof (entering the house fades too): wait for the real night transition
                if (!Context.IsWorldReady || Game1.newDay || Game1.player.isInBed.Value && Game1.fadeToBlack && Game1.activeClickableMenu == null && i > 30)
                {
                    J.Message = "went to sleep; poll /state until the new day is ready";
                    yield break;
                }
                yield return null;
            }
            throw new ActionFailed("tried to sleep but the night didn't start" + (Game1.activeClickableMenu != null ? $" (menu open: {Game1.activeClickableMenu.GetType().Name})" : ""));
        }

        private IEnumerable<object> CraftAction(string query, int count, Point? placeAt)
        {
            var recipe = Crafting.Find(query) ?? throw new ActionFailed($"no known crafting recipe '{query}' (see /recipes)");
            if (placeAt is { } at)
            {
                // craft straight onto the ground (works with a full backpack), e.g. the first chest
                if (World.Chebyshev(P.TilePoint, at) > 1)
                    foreach (var o in this.WalkTo(at, adjacent: true)) yield return o;
                foreach (var o in this.EnsureFree()) yield return o;
                Face(at);
                string err = Crafting.CraftAndPlace(recipe, Game1.currentLocation, at);
                if (err != null)
                    throw new ActionFailed($"can't craft {recipe.DisplayName} at ({at.X},{at.Y}): {err}");
                J.Message = $"crafted {recipe.DisplayName} and placed it at ({at.X},{at.Y})";
                yield break;
            }
            int made = Crafting.Craft(recipe, count, out string problem);
            if (made == 0)
                throw new ActionFailed($"can't craft {recipe.DisplayName}: {problem}");
            J.Message = $"crafted {made}x {recipe.DisplayName}" + (problem != null ? $" (stopped: {problem})" : "");
            yield break;
        }

        private IEnumerable<object> WalkToChest(Point? at, Action<StardewValley.Objects.Chest, Point> found)
        {
            var loc = Game1.currentLocation;
            var chest = Crafting.NearestChest(loc, P.TilePoint, at)
                        ?? throw new ActionFailed(at != null ? $"no chest at ({at.Value.X},{at.Value.Y})" : $"no chest in {loc.NameOrUniqueName}; craft one (craft Chest = 50 wood) and place it");
            var tile = new Point((int)chest.TileLocation.X, (int)chest.TileLocation.Y);
            if (World.Chebyshev(P.TilePoint, tile) > 1)
                foreach (var o in this.WalkTo(tile, adjacent: true)) yield return o;
            foreach (var o in this.EnsureFree()) yield return o;
            Face(tile);
            found(chest, tile);
        }

        private IEnumerable<object> Store(List<string> names, Point? at)
        {
            StardewValley.Objects.Chest chest = null;
            Point tile = default;
            foreach (var o in this.WalkToChest(at, (c, t) => { chest = c; tile = t; })) yield return o;
            var stored = new List<string>();
            foreach (var item in P.Items.Where(i => i != null).ToList())
            {
                bool wanted = names.Count == 0
                    ? Crafting.IsStorable(item)
                    : names.Any(n => item.DisplayName.Contains(n, StringComparison.OrdinalIgnoreCase) || item.Name.Contains(n, StringComparison.OrdinalIgnoreCase) || item.QualifiedItemId == n);
                if (!wanted || item is Tool)
                    continue;
                int before = item.Stack;
                var left = chest.addItem(item);
                if (left == null)
                    P.removeItemFromInventory(item);
                else
                    item.Stack = left.Stack;
                int moved = before - (left?.Stack ?? 0);
                if (moved > 0)
                    stored.Add($"{moved}x {item.DisplayName}");
            }
            J.Data["stored"] = stored;
            J.Message = stored.Count == 0 ? "nothing to store" : $"stored in chest at ({tile.X},{tile.Y}): {string.Join(", ", stored)}";
        }

        private IEnumerable<object> Take(string query, int count, Point? at)
        {
            StardewValley.Objects.Chest chest = null;
            Point tile = default;
            foreach (var o in this.WalkToChest(at, (c, t) => { chest = c; tile = t; })) yield return o;
            string q = query.ToLowerInvariant();
            var item = chest.Items.FirstOrDefault(i => i != null && (i.DisplayName.ToLowerInvariant().Contains(q) || i.Name.ToLowerInvariant().Contains(q) || i.QualifiedItemId.ToLowerInvariant() == q))
                       ?? throw new ActionFailed($"'{query}' is not in the chest at ({tile.X},{tile.Y})");
            int n = Math.Min(count, item.Stack);
            var part = item.getOne();
            part.Stack = n;
            if (!P.couldInventoryAcceptThisItem(part))
                throw new ActionFailed("inventory full");
            P.addItemToInventoryBool(part);
            if (n >= item.Stack)
                chest.Items.Remove(item);
            else
                item.Stack -= n;
            J.Message = $"took {n}x {part.DisplayName} from chest at ({tile.X},{tile.Y})";
        }

        private IEnumerable<object> Fish(int casts)
        {
            var loc = Game1.currentLocation;
            int slot = World.FindToolSlot("rod");
            if (slot < 0)
                throw new ActionFailed("no fishing rod in inventory (Willy gives one at the beach)");
            if (!loc.canFishHere())
                throw new ActionFailed($"can't fish in {loc.NameOrUniqueName}");
            int added = Fishing.AddedDistance(P);
            var badSpots = new HashSet<Point>();
            if (!Fishing.FindSpot(loc, P.TilePoint, added, out var path, out int dir, out float spotPower, badSpots))
                throw new ActionFailed($"no reachable fishing spot in {loc.NameOrUniqueName}");
            foreach (var o in this.WalkPath(path)) yield return o;
            var misses = new List<string>();

            AttachTackle((FishingRod)P.Items[slot]);
            var caught = new List<string>();
            int escaped = 0, noBite = 0;
            Fishing.Active = true;
            try
            {
                for (int c = 0; c < casts; c++)
                {
                    if (P.Stamina < 10)
                    {
                        J.Data["stopped"] = "low stamina";
                        break;
                    }
                    foreach (var o in this.EnsureFree()) yield return o;
                    var rod = (FishingRod)P.Items[slot];
                    P.CurrentToolIndex = slot;
                    P.faceDirection(dir);
                    // recompute from where the player actually stands (sub-tile offsets shift the landing spot)
                    float power = Fishing.PickPower(loc, P.StandingPixel, dir, added);
                    if (power < 0)
                        power = spotPower;

                    // cast: begin "holding" the button, then release at a fixed, decent power
                    P.BeginUsingTool();
                    yield return null;
                    rod.castingTimerSpeed = 0f;
                    rod.castingPower = power;
                    int t = 0;
                    for (; t < 600 && !rod.isFishing; t++)
                    {
                        if (!rod.isTimingCast && !rod.isCasting && !rod.castedButBobberStillInAir && !P.UsingTool)
                            break; // the cast ended without fishing (landed on land, no stamina, ...)
                        yield return null;
                    }
                    if (!rod.isFishing)
                    {
                        P.completelyStopAnimatingOrDoingAction();
                        var stand = P.TilePoint;
                        var aim = Fishing.Landing(P.StandingPixel, dir, power, added);
                        misses.Add($"stood ({stand.X},{stand.Y}) facing {dir}, power {power:0.00}, aimed at ({aim.X},{aim.Y})");
                        // try another spot instead of giving up on the whole action (this cast doesn't count)
                        badSpots.Add(stand);
                        if (misses.Count >= 3 || !Fishing.FindSpot(loc, stand, added, out path, out dir, out spotPower, badSpots))
                            throw new ActionFailed("the cast did not land in fishable water: " + string.Join("; ", misses));
                        for (int k = 0; k < 20; k++) yield return null;
                        foreach (var o in this.WalkPath(path)) yield return o;
                        c--;
                        continue;
                    }

                    // wait for a bite (game time passes), then hook it
                    for (t = 0; t < 60 * 90 && !rod.isNibbling && rod.isFishing; t++)
                        yield return null;
                    if (!rod.isNibbling)
                    {
                        noBite++;
                        rod.doneFishing(P);
                        P.completelyStopAnimatingOrDoingAction();
                        continue;
                    }
                    rod.DoFunction(loc, (int)P.Position.X, (int)P.Position.Y, 1, P);

                    // the reel minigame (controlled by Fishing.Tick each frame)
                    for (t = 0; t < 600 && Game1.activeClickableMenu is not BobberBar && !rod.fishCaught && !rod.pullingOutOfWater; t++)
                        yield return null;
                    for (t = 0; t < 60 * 120 && Game1.activeClickableMenu is BobberBar; t++)
                        yield return null;

                    // reeling out / showing the catch / treasure
                    for (t = 0; t < 600 && !rod.fishCaught && (rod.pullingOutOfWater || rod.isReeling); t++)
                        yield return null;
                    if (rod.fishCaught)
                    {
                        string name = rod.whichFish != null ? ItemRegistry.GetDataOrErrorItem(rod.whichFish.QualifiedItemId).DisplayName : "fish";
                        for (t = 0; t < 40; t++) yield return null;
                        rod.doneHoldingFish(P);
                        caught.Add(name);
                    }
                    else
                        escaped++;
                    for (t = 0; t < 120 && (rod.showingTreasure || Game1.activeClickableMenu is ItemGrabMenu); t++)
                    {
                        if (Game1.activeClickableMenu is ItemGrabMenu grab)
                        {
                            foreach (var item in grab.ItemsToGrabMenu.actualInventory)
                                if (item != null && P.addItemToInventoryBool(item))
                                    caught.Add("treasure: " + item.DisplayName);
                            grab.exitThisMenu(false);
                        }
                        yield return null;
                    }
                    for (t = 0; t < 120 && (P.UsingTool || !P.CanMove); t++)
                        yield return null;
                }
            }
            finally
            {
                Fishing.Active = false;
            }
            J.Data["caught"] = caught;
            J.Message = $"fished: caught {caught.Count} ({string.Join(", ", caught)})" + (escaped > 0 ? $", {escaped} got away" : "") + (noBite > 0 ? $", {noBite} casts without a bite" : "");
        }

        private int WeaponSlot() => Gear.BestWeaponSlot(P);

        /// <summary>Put bait (and tackle) from the backpack on the rod if it has empty slots (the Bamboo Pole has none).</summary>
        private void AttachTackle(FishingRod rod)
        {
            for (int a = 0; a < rod.AttachmentSlotsCount; a++)
            {
                if (rod.attachments[a] != null)
                    continue;
                int category = a == 0 ? SObject.baitCategory : SObject.tackleCategory;
                int i = Enumerable.Range(0, P.Items.Count).FirstOrDefault(k => P.Items[k] is SObject o && o.Category == category, -1);
                if (i < 0)
                    continue;
                rod.attachments[a] = (SObject)P.Items[i];
                P.Items[i] = null;
                J.Data["attached"] = rod.attachments[a].DisplayName;
            }
        }

        /// <summary>Eat the food that restores the most health; returns false if there is none.</summary>
        private bool EatForHealth()
        {
            int best = -1, bestValue = 0;
            for (int i = 0; i < P.Items.Count; i++)
                if (P.Items[i] is SObject o && o.Edibility > 0 && o.Edibility > bestValue)
                {
                    best = i;
                    bestValue = o.Edibility;
                }
            if (best < 0)
                return false;
            P.CurrentToolIndex = best;
            P.eatHeldObject();
            return true;
        }

        /// <summary>Fight monsters near the player until none are within range (real-time, one decision per tick).</summary>
        private IEnumerable<object> FightNearby(int range)
        {
            var loc = Game1.currentLocation;
            int weapon = this.WeaponSlot();
            if (weapon < 0)
                yield break;
            for (int t = 0; t < 60 * 60; t++)
            {
                if (!ReferenceEquals(Game1.currentLocation, loc))
                    yield break;
                var target = Mining.Monsters(loc).OrderBy(m => Vector2.Distance(m.Position, P.Position)).FirstOrDefault();
                if (target == null || World.Chebyshev(target.TilePoint, P.TilePoint) > range)
                    yield break;
                if (P.health < P.maxHealth * EatBelow)
                {
                    if (!this.EatForHealth())
                    {
                        this.mustRetreat = true;
                        yield break;
                    }
                    for (int i = 0; i < 150 && (P.isEating || Game1.activeClickableMenu != null); i++) yield return null;
                    continue;
                }
                if (P.UsingTool || !P.CanMove)
                {
                    yield return null;
                    continue;
                }
                var d = target.GetBoundingBox().Center - P.GetBoundingBox().Center;
                int dir = Math.Abs(d.X) > Math.Abs(d.Y) ? (d.X > 0 ? 1 : 3) : (d.Y > 0 ? 2 : 0);
                P.faceDirection(dir);
                P.CurrentToolIndex = weapon;
                if (Math.Abs(d.X) <= 80 && Math.Abs(d.Y) <= 80)
                {
                    P.BeginUsingTool(); // swing at the monster in front
                    J.Data["swings"] = (J.Data.TryGetValue("swings", out var s) ? (int)s : 0) + 1;
                }
                else
                {
                    var step = World.FindPath(loc, P.TilePoint, p => World.Chebyshev(p, target.TilePoint) <= 1, 4000);
                    if (step != null && step.Count > 0)
                        foreach (var o in this.WalkPath(step.Take(1).ToList())) yield return o;
                }
                yield return null;
            }
        }

        /// <summary>Set by FightNearby when health is low and there is nothing to eat: callers retreat.</summary>
        private bool mustRetreat;

        private const float EatBelow = 0.4f;

        private IEnumerable<object> Mine(int floors, int maxFloor)
        {
            var (safe, why) = Gear.SafeDepth(P);
            int cap = Math.Min(safe, maxFloor);
            string capReason = maxFloor < safe ? $"floor cap {maxFloor} (knocked out recently)" : why;
            this.mustRetreat = false;
            if (Game1.currentLocation is not MineShaft)
            {
                if (Game1.currentLocation.Name != "Mine")
                    foreach (var o in this.GotoLocation("Mine")) yield return o;
                foreach (var o in this.EnsureFree()) yield return o;
                // like the elevator: the deepest multiple of 5 reached, but never past what the gear can handle
                int start = Math.Max(1, Math.Min(P.deepestMineLevel, cap) / 5 * 5);
                Game1.enterMine(start);
                for (int i = 0; i < 300 && (Game1.currentLocation is not MineShaft || Game1.isWarping || Game1.fadeToBlack); i++)
                    yield return null;
            }
            int descended = 0, broken = 0;
            int firstLevel = ((MineShaft)Game1.currentLocation).mineLevel;
            string stop = null;
            bool retreat = false;
            while (descended < floors)
            {
                if (P.health <= 0 || Game1.killScreen)
                    break;
                var loc = Game1.currentLocation as MineShaft ?? throw new ActionFailed("left the mine unexpectedly");
                if (P.Stamina < 15)
                {
                    stop = "low stamina";
                    break;
                }
                if (loc.mineLevel >= cap)
                {
                    stop = $"stopped at floor {loc.mineLevel}: {capReason}";
                    break;
                }
                if (P.health < P.maxHealth * EatBelow || this.mustRetreat)
                {
                    if (!this.mustRetreat && this.EatForHealth())
                    {
                        for (int i = 0; i < 150 && (P.isEating || Game1.activeClickableMenu != null); i++)
                            yield return null; // health rises when the eating animation ends
                        continue;
                    }
                    retreat = true;
                    stop = $"retreated: health {P.health}/{P.maxHealth} and {Gear.FoodCount(P)} healing food left";
                    break;
                }
                foreach (var o in this.EnsureFree()) yield return o;
                foreach (var o in this.FightNearby(3)) yield return o;
                if (this.mustRetreat)
                    continue;

                // take a ladder if one is reachable
                var ladder = Mining.FindTiles(loc, Mining.LadderDown).FirstOrDefault(l => World.FindPath(loc, P.TilePoint, p => World.Manhattan(p, l) == 1, 20000) != null);
                if (ladder != default)
                {
                    foreach (var o in this.WalkTo(ladder, adjacent: true)) yield return o;
                    foreach (var o in this.EnsureFree()) yield return o;
                    Face(ladder);
                    loc.checkAction(new xTile.Dimensions.Location(ladder.X, ladder.Y), Game1.viewport, P);
                    for (int i = 0; i < 300 && (ReferenceEquals(Game1.currentLocation, loc) || Game1.isWarping || Game1.fadeToBlack); i++)
                        yield return null;
                    descended++;
                    continue;
                }

                // otherwise break the nearest stone (it may hide the ladder)
                var stones = loc.objects.Pairs.Where(kv => World.ObjectKind(kv.Value) == "stone")
                    .Select(kv => new Point((int)kv.Key.X, (int)kv.Key.Y)).ToHashSet();
                if (stones.Count == 0)
                    throw new ActionFailed($"floor {loc.mineLevel}: no stones left and no ladder found (kill remaining monsters?)");
                Point? stone = null;
                foreach (var o in this.ApproachNearest(stones, s => stone = s, canStandOn: false)) yield return o;
                if (stone == null)
                    throw new ActionFailed($"floor {loc.mineLevel}: no reachable stone or ladder");
                foreach (var o in this.FightNearby(2)) yield return o;
                if (this.mustRetreat)
                    continue;
                for (int hit = 0; hit < 6 && loc.objects.ContainsKey(new Vector2(stone.Value.X, stone.Value.Y)); hit++)
                    foreach (var o in this.UseToolOnce("pickaxe", stone.Value)) yield return o;
                broken++;
            }
            int level = (Game1.currentLocation as MineShaft)?.mineLevel ?? 0;
            if (P.health <= 0 || Game1.killScreen)
            {
                J.Data["knocked_out"] = true;
                throw new ActionFailed($"knocked out in the mine on floor {Math.Max(level, firstLevel)}");
            }
            J.Data["floor"] = level;
            J.Data["stones_broken"] = broken;
            J.Data["safe_depth"] = cap;
            J.Message = $"mined from floor {firstLevel} to {level} ({descended} floors down, {broken} stones broken)" + (stop != null ? "; " + stop : "");
            if (retreat)
            {
                string msg = J.Message;
                foreach (var o in this.LeaveMine()) yield return o;
                J.Data["retreated"] = true;
                J.Message = msg + "; left the mine to recover";
            }
        }

        private IEnumerable<object> Fight(int range)
        {
            this.mustRetreat = false;
            foreach (var o in this.FightNearby(range)) yield return o;
            if (this.mustRetreat)
                throw new ActionFailed($"health low ({P.health}/{P.maxHealth}) and no food: stopped fighting; leave_mine");
        }

        /// <summary>
        /// Clint's tool upgrade, done like the game's "ClintUpgrade" shop: pay gold + bars (backpack first, then farm chests),
        /// then Tool.actionWhenPurchased takes the old tool and starts the 2-day timer. Also collects a finished upgrade.
        /// </summary>
        private IEnumerable<object> UpgradeTool(string query)
        {
            if (Game1.currentLocation.Name != "Blacksmith")
                foreach (var o in this.GotoLocation("Blacksmith")) yield return o;
            if (!ShopkeeperHere("Clint"))
                throw new ActionFailed("Clint isn't at the counter (open 9:00-16:00)");
            var collected = new List<string>();
            if (P.toolBeingUpgraded.Value != null && P.daysLeftForToolUpgrade.Value <= 0)
            {
                if (P.freeSpotsInInventory() <= 0)
                    throw new ActionFailed("backpack full: free a slot to collect the upgraded tool");
                var done = P.toolBeingUpgraded.Value;
                P.toolBeingUpgraded.Value = null;
                P.hasReceivedToolUpgradeMessageYet = false;
                P.addItemToInventoryBool(done);
                collected.Add(done.DisplayName);
            }
            if (string.IsNullOrWhiteSpace(query))
            {
                if (collected.Count == 0)
                    throw new ActionFailed(P.toolBeingUpgraded.Value != null
                        ? $"Clint is still working on {P.toolBeingUpgraded.Value.DisplayName} ({P.daysLeftForToolUpgrade.Value} days)"
                        : "nothing to collect; give 'tool' (axe/pickaxe/hoe/watering can) to start an upgrade");
                J.Message = "collected " + string.Join(", ", collected);
                yield break;
            }
            if (P.toolBeingUpgraded.Value != null)
                throw new ActionFailed($"Clint is still working on {P.toolBeingUpgraded.Value.DisplayName} ({P.daysLeftForToolUpgrade.Value} days); one upgrade at a time");
            string q = query.ToLowerInvariant().Replace(" ", "");
            var stock = StardewValley.Internal.ShopBuilder.GetShopStock("ClintUpgrade");
            var match = stock.FirstOrDefault(kv => kv.Key is Tool t && (t.Name.ToLowerInvariant().Replace(" ", "").Contains(q)
                                                   || q.Contains("axe") && t is Axe || q.Contains("pick") && t is Pickaxe
                                                   || q.Contains("hoe") && t is Hoe || q.Contains("water") && t is WateringCan));
            if (match.Key is not Tool upgrade)
                throw new ActionFailed($"Clint has no upgrade for '{query}' right now (already the best, or you don't have that tool)");
            var info = match.Value;
            if (P.Money < info.Price)
                throw new ActionFailed($"{upgrade.DisplayName} costs {info.Price}g, you have {P.Money}g");
            int barsNeeded = info.TradeItem != null ? info.TradeItemCount ?? 1 : 0;
            string barName = info.TradeItem != null ? ItemRegistry.GetDataOrErrorItem(info.TradeItem).DisplayName : null;
            if (barsNeeded > 0)
            {
                int have = P.Items.CountId(info.TradeItem) + Crafting.FarmChests().Sum(c => c.Items.CountId(info.TradeItem));
                if (have < barsNeeded)
                    throw new ActionFailed($"{upgrade.DisplayName} needs {barsNeeded}x {barName}, you have {have} (backpack + chests)");
                int left = barsNeeded - P.Items.ReduceId(info.TradeItem, barsNeeded);
                foreach (var chest in Crafting.FarmChests())
                    if (left > 0)
                        left -= chest.Items.ReduceId(info.TradeItem, left);
            }
            P.Money -= info.Price;
            upgrade.actionWhenPurchased("ClintUpgrade");
            for (int i = 0; i < 60; i++) yield return null;
            J.Message = (collected.Count > 0 ? "collected " + string.Join(", ", collected) + "; " : "")
                        + $"Clint is upgrading to {upgrade.DisplayName} for {info.Price}g" + (barsNeeded > 0 ? $" + {barsNeeded}x {barName}" : "")
                        + ": ready in 2 days (come back with upgrade_tool to collect)";
        }

        /// <summary>
        /// Festival activities, through the event's own methods: "soup" (Luau: the best ingredient in the backpack),
        /// "grange" (Fair: up to 9 good items of different kinds), "dance" (Flower Dance: ask the best friend at 4+ hearts),
        /// "start" (tell Lewis you're ready: the main event starts).
        /// </summary>
        private IEnumerable<object> Festival(string activity)
        {
            var ev = Game1.CurrentEvent;
            if (ev == null || !ev.isFestival)
                throw new ActionFailed("not at a festival right now (goto_location the festival map during its hours first)");
            int Value(Item i) => i is SObject o ? o.sellToStorePrice() * (1 + o.Quality) : 0;
            switch (activity)
            {
                case "soup":
                    if (!ev.isSpecificFestival("summer11"))
                        throw new ActionFailed("the soup is only at the Luau (summer 11)");
                    var best = P.Items.Where(i => i != null && Utility.highlightLuauSoupItems(i)).OrderByDescending(Value).FirstOrDefault()
                               ?? throw new ActionFailed("nothing in the backpack can go in the soup (bring a good crop, fish or dish)");
                    ev.addItemToLuauSoup(best, P);
                    P.Items.ReduceId(best.QualifiedItemId, 1);
                    J.Message = $"added {best.DisplayName} to the Luau soup";
                    break;
                case "grange":
                    if (!ev.isSpecificFestival("fall16"))
                        throw new ActionFailed("the grange display is only at the Stardew Valley Fair (fall 16)");
                    var picks = P.Items.OfType<SObject>().Where(o => !o.bigCraftable.Value && o.sellToStorePrice() > 0)
                        .GroupBy(o => o.Category).Select(g => g.OrderByDescending(Value).First())
                        .OrderByDescending(Value).Take(9).ToList();
                    if (picks.Count == 0)
                        throw new ActionFailed("nothing to display (bring crops, fish, artisan goods, minerals of different kinds)");
                    for (int k = 0; k < picks.Count; k++)
                    {
                        ev.addItemToGrangeDisplay(picks[k].getOne(), k, true);
                        P.Items.ReduceId(picks[k].QualifiedItemId, 1);
                    }
                    J.Message = "grange display: " + string.Join(", ", picks.Select(o => o.DisplayName));
                    break;
                case "dance":
                    if (!ev.isSpecificFestival("spring24"))
                        throw new ActionFailed("dancing is only at the Flower Dance (spring 24)");
                    var partner = ev.actors.Where(n => n.IsVillager && n.datable.Value && !n.isMarried() && !n.HasPartnerForDance
                                                       && P.getFriendshipLevelForNPC(n.Name) >= 1000)
                        .OrderByDescending(n => P.getFriendshipLevelForNPC(n.Name)).FirstOrDefault()
                        ?? throw new ActionFailed("nobody to dance with: a bachelor(ette) needs 4+ hearts");
                    ev.answerDialogueQuestion(partner, "danceAsk");
                    J.Message = P.dancePartner.Value != null ? $"{partner.displayName} will dance with you" : $"asked {partner.displayName} to dance";
                    break;
                case "start":
                    ev.answerDialogueQuestion(null, "yes");
                    for (int i = 0; i < 60; i++) yield return null;
                    J.Message = "told Lewis you're ready: the festival's main event starts";
                    break;
                default:
                    throw new ActionFailed("activity must be soup, grange, dance or start");
            }
            yield return null;
        }

        /// <summary>Buy the strongest weapon Marlon sells that is better than the current one and affordable.</summary>
        private IEnumerable<object> BuyWeapon()
        {
            if (Game1.currentLocation.Name != "AdventureGuild")
                foreach (var o in this.GotoLocation("AdventureGuild")) yield return o;
            if (!ShopkeeperHere("Marlon"))
                throw new ActionFailed("Marlon isn't at the Adventurer's Guild counter right now");
            float have = Gear.WeaponPower(P);
            var stock = Gear.GuildWeapons();
            var pick = stock.FirstOrDefault(x => Gear.Power(x.weapon) > have && x.price <= P.Money);
            if (pick.weapon == null)
            {
                var better = stock.Where(x => Gear.Power(x.weapon) > have).Select(x => $"{x.weapon.DisplayName} {x.price}g").ToList();
                throw new ActionFailed(better.Count == 0
                    ? "Marlon sells nothing stronger than your weapon yet (more stock unlocks deeper in the mine)"
                    : $"not enough money ({P.Money}g) for a better weapon: {string.Join(", ", better)}");
            }
            var item = (MeleeWeapon)pick.weapon.getOne();
            if (!P.couldInventoryAcceptThisItem(item))
                throw new ActionFailed("inventory full");
            P.Money -= pick.price;
            P.addItemToInventoryBool(item);
            J.Message = $"bought {item.DisplayName} ({item.minDamage.Value}-{item.maxDamage.Value} damage) for {pick.price}g";
        }

        private IEnumerable<object> LeaveMine()
        {
            var loc = Game1.currentLocation as MineShaft ?? throw new ActionFailed("not in the mine");
            var up = Mining.FindTiles(loc, Mining.LadderUp).FirstOrDefault();
            if (up == default)
                throw new ActionFailed("can't find the ladder up on this floor");
            foreach (var o in this.WalkTo(up, adjacent: true)) yield return o;
            foreach (var o in this.EnsureFree()) yield return o;
            Face(up);
            loc.checkAction(new xTile.Dimensions.Location(up.X, up.Y), Game1.viewport, P);
            for (int i = 0; i < 30 && Game1.activeClickableMenu is not DialogueBox; i++) yield return null;
            if (Game1.activeClickableMenu is DialogueBox { isQuestion: true })
                foreach (var o in this.DialogAnswer(0)) yield return o; // "Leave the mine"
            for (int i = 0; i < 300 && (Game1.currentLocation is MineShaft || Game1.isWarping || Game1.fadeToBlack); i++)
                yield return null;
            J.Message = $"left the mine, now in {Game1.currentLocation.NameOrUniqueName}";
        }

        private IEnumerable<object> Donate()
        {
            if (!Bundles.CanDonate)
                throw new ActionFailed("can't donate yet: " + Bundles.Stage());
            var usable = P.Items.Where(i => i is SObject o && Game1.RequireLocation<CommunityCenter>("CommunityCenter").couldThisIngredienteBeUsedInABundle(o)).ToList();
            if (usable.Count == 0)
            {
                J.Message = "nothing in the backpack is needed by an open bundle (see bundles in /state); take items out of chests first";
                yield break;
            }
            if (Game1.currentLocation is not CommunityCenter)
                foreach (var o in this.GotoLocation("CommunityCenter")) yield return o;
            var cc = (CommunityCenter)Game1.currentLocation;
            var donated = new List<string>();
            var reflection = this.mod.Helper.Reflection;

            for (int area = 0; area < 7; area++)
            {
                if (!cc.shouldNoteAppearInArea(area) || cc.areasComplete.Count > area && cc.areasComplete[area])
                    continue;
                var note = reflection.GetMethod(cc, "getNotePosition").Invoke<Point>(area);
                foreach (var o in this.EnsureFree()) yield return o;
                if (World.Chebyshev(P.TilePoint, note) > 1)
                    foreach (var o in this.WalkTo(note, adjacent: true)) yield return o;
                foreach (var o in this.EnsureFree()) yield return o;
                Face(note);
                cc.checkAction(new xTile.Dimensions.Location(note.X, note.Y), Game1.viewport, P);
                for (int i = 0; i < 30 && Game1.activeClickableMenu is not JunimoNoteMenu; i++) yield return null;
                if (Game1.activeClickableMenu is not JunimoNoteMenu menu)
                    continue;

                foreach (var bundle in menu.bundles.ToList())
                {
                    if (bundle.complete || !ReferenceEquals(Game1.activeClickableMenu, menu))
                        continue;
                    bool Fits(Item item) => item is SObject && bundle.ingredients.Any(ing => !ing.completed && bundle.IsValidItemForThisIngredientDescription(item, ing));
                    if (!P.Items.Any(Fits))
                        continue;
                    reflection.GetMethod(menu, "setUpBundleSpecificPage").Invoke(bundle);
                    yield return null;
                    foreach (var slot in menu.ingredientSlots.ToList())
                    {
                        if (slot.item != null)
                            continue;
                        var item = P.Items.FirstOrDefault(i => i != null && Fits(i) && bundle.canAcceptThisItem(i, slot));
                        if (item == null)
                            break;
                        int index = P.Items.IndexOf(item);
                        string name = item.DisplayName;
                        int before = item.Stack;
                        var left = bundle.tryToDepositThisItem(item, slot, JunimoNoteMenu.noteTextureName, menu);
                        P.Items[index] = left != null && left.Stack > 0 ? left : null;
                        int used = before - (left?.Stack ?? 0);
                        if (used > 0)
                            donated.Add($"{used}x {name} -> {bundle.label}");
                        yield return null;
                    }
                    reflection.GetMethod(menu, "checkIfBundleIsComplete").Invoke();
                    for (int i = 0; i < 120 && ReferenceEquals(Game1.activeClickableMenu, menu) && menu.specificBundlePage; i++)
                        yield return null;
                    if (ReferenceEquals(Game1.activeClickableMenu, menu) && menu.specificBundlePage)
                        menu.takeDownBundleSpecificPage();
                    yield return null;
                }

                // collect finished-bundle rewards (the present button), then close
                if (Game1.activeClickableMenu is JunimoNoteMenu open && reflection.GetField<ClickableTextureComponent>(open, "presentButton", false)?.GetValue() != null)
                {
                    reflection.GetMethod(open, "openRewardsMenu").Invoke();
                    for (int i = 0; i < 90 && Game1.activeClickableMenu is ItemGrabMenu; i++) yield return null;
                }
                for (int i = 0; i < 60 && Game1.activeClickableMenu != null; i++)
                {
                    if (i % 15 == 0)
                        Game1.activeClickableMenu?.exitThisMenu(false);
                    yield return null;
                }
            }
            J.Data["donated"] = donated;
            J.Message = donated.Count == 0 ? "opened the bundles but nothing could be deposited" : $"donated: {string.Join("; ", donated)}";
        }

        private static bool ShopkeeperHere(string npc) =>
            Game1.currentLocation.characters.Any(c => c.Name == npc);

        private IEnumerable<object> Build(string type, Point at)
        {
            var key = Game1.buildingData.Keys.FirstOrDefault(k => string.Equals(k, type, StringComparison.OrdinalIgnoreCase))
                      ?? throw new ActionFailed($"unknown building '{type}'");
            var data = Game1.buildingData[key];
            if (data.Builder != "Robin" || !GameStateQuery.CheckConditions(data.BuildCondition))
                throw new ActionFailed($"Robin can't build {key} yet");
            if (!string.IsNullOrEmpty(data.BuildingToUpgrade))
                throw new ActionFailed($"{key} is an upgrade of {data.BuildingToUpgrade}; upgrades aren't supported yet");
            if (Game1.currentLocation.Name != "ScienceHouse")
                foreach (var o in this.GotoLocation("ScienceHouse")) yield return o;
            if (!ShopkeeperHere("Robin") || Game1.timeOfDay >= 1700)
                throw new ActionFailed("Robin isn't at her shop right now (open 9:00-17:00, not Tuesday)");
            if (Game1.IsThereABuildingUnderConstruction("Robin"))
                throw new ActionFailed("Robin is already building something");
            if (P.Money < data.BuildCost)
                throw new ActionFailed($"{key} costs {data.BuildCost}g, you have {P.Money}g");
            foreach (var m in data.BuildMaterials ?? new())
            {
                string qid = ItemRegistry.QualifyItemId(m.ItemId) ?? m.ItemId;
                if (!P.Items.ContainsId(qid, m.Amount))
                    throw new ActionFailed($"need {m.Amount}x {ItemRegistry.GetDataOrErrorItem(qid).DisplayName} in the backpack (take it from a chest first)");
            }
            var farm = Game1.getFarm();
            for (int x = at.X; x < at.X + data.Size.X; x++)
                for (int y = at.Y; y < at.Y + data.Size.Y; y++)
                    if (!Ranch.IsBuildable(farm, x, y, allowDebris: false))
                        throw new ActionFailed($"can't build {key} at ({at.X},{at.Y}): tile ({x},{y}) is blocked (clear_area the site first)");
            if (!farm.buildStructure(key, new Vector2(at.X, at.Y), P, out var building, skipSafetyChecks: true))
                throw new ActionFailed($"can't place {key} at ({at.X},{at.Y})");
            if (building.isUnderConstruction())
                Game1.netWorldState.Value.MarkUnderConstruction("Robin", building);
            P.Money -= data.BuildCost;
            foreach (var m in data.BuildMaterials ?? new())
                P.Items.ReduceId(ItemRegistry.QualifyItemId(m.ItemId) ?? m.ItemId, m.Amount);
            J.Message = $"Robin will build a {key} at ({at.X},{at.Y}); ready in {building.daysOfConstructionLeft.Value} days ({data.BuildCost}g paid)";
            yield break;
        }

        /// <summary>Clear weeds/stones/twigs/grass in a rectangle (e.g. a building site).</summary>
        /// <summary>Lay flooring (paths) on the given farm tiles in order, clearing weeds/stones/twigs/grass on the way.</summary>
        private IEnumerable<object> LayPath(List<Point> tiles, string item)
        {
            if (Game1.currentLocation is not Farm)
                foreach (var o in this.GotoLocation("Farm")) yield return o;
            var farm = (Farm)Game1.currentLocation;
            int laid = 0, already = 0, skipped = 0;
            string stop = null;
            foreach (var t in tiles)
            {
                char c = FarmGrid.Tile(farm, t.X, t.Y);
                if (c == 'p')
                {
                    already++;
                    continue;
                }
                if (c != '.' && c != 'd' && c != 't')
                {
                    skipped++; // big stumps/boulders, crops, objects, buildings: left for later
                    continue;
                }
                int slot = World.FindItemSlot(item);
                if (slot < 0)
                {
                    stop = $"no {item} left";
                    break;
                }
                if (P.Stamina < 4)
                {
                    stop = "too tired";
                    break;
                }
                if (World.Chebyshev(P.TilePoint, t) > 1 || P.TilePoint == t)
                {
                    // a tile walled in by the house, a cliff or a fence is left for later instead of ending the whole run
                    if (World.FindPath(farm, P.TilePoint, p => World.Chebyshev(p, t) == 1, 20000) == null)
                    {
                        skipped++;
                        continue;
                    }
                    foreach (var o in this.WalkTo(t, adjacent: true)) yield return o;
                }
                foreach (var o in this.EnsureFree()) yield return o;
                if (c == 't')
                {
                    // a tree on the planned road: chop it down and clear the stump (any axe can)
                    for (int hit = 0; hit < 40 && FarmGrid.Tile(farm, t.X, t.Y) == 't' && P.Stamina >= 4; hit++)
                        foreach (var o in this.UseToolOnce("axe", t)) yield return o;
                    for (int k = 0; k < 30; k++) yield return null; // the falling tree
                    c = FarmGrid.Tile(farm, t.X, t.Y);
                    if (c != '.' && c != 'd')
                    {
                        skipped++;
                        continue;
                    }
                }
                if (c == 'd')
                {
                    string tool = "scythe";
                    if (farm.objects.TryGetValue(new Vector2(t.X, t.Y), out var obj))
                    {
                        string kind = World.ObjectKind(obj);
                        tool = kind == "stone" ? "pickaxe" : kind == "twig" ? "axe" : "scythe";
                    }
                    if (World.FindToolSlot(tool) < 0)
                        tool = "hoe";
                    for (int hit = 0; hit < 4 && FarmGrid.Tile(farm, t.X, t.Y) == 'd'; hit++)
                        foreach (var o in this.UseToolOnce(tool, t)) yield return o;
                    if (FarmGrid.Tile(farm, t.X, t.Y) != '.')
                    {
                        skipped++;
                        continue;
                    }
                }
                slot = World.FindItemSlot(item);
                if (slot >= 0 && this.PlaceHere(slot, t))
                    laid++;
                else
                    skipped++;
                yield return null;
            }
            J.Data["laid"] = laid;
            J.Message = $"laid {laid} {item} tiles ({already} already done, {skipped} skipped: blocked by trees/crops/objects)" + (stop != null ? "; stopped: " + stop : "");
            if (laid == 0 && already == 0)
                throw new ActionFailed(J.Message);
        }

        private IEnumerable<object> ClearArea(Rectangle r)
        {
            if (Game1.currentLocation is not Farm)
                foreach (var o in this.GotoLocation("Farm")) yield return o;
            var loc = Game1.currentLocation;
            int cleared = 0, skipped = 0;
            for (int y = r.Y; y < r.Bottom; y++)
                for (int x = r.X; x < r.Right; x++)
                {
                    if (Plots.Classify(loc, x, y) != "debris")
                        continue;
                    if (P.Stamina < 4)
                        throw new ActionFailed($"too tired; cleared {cleared} so far");
                    var t = new Point(x, y);
                    string tool = "scythe";
                    if (loc.objects.TryGetValue(new Vector2(x, y), out var obj))
                    {
                        string kind = World.ObjectKind(obj);
                        tool = kind == "stone" ? "pickaxe" : kind == "twig" ? "axe" : World.FindToolSlot("scythe") >= 0 ? "scythe" : "axe";
                    }
                    if (World.FindToolSlot(tool) < 0)
                    {
                        skipped++;
                        continue;
                    }
                    for (int hit = 0; hit < 4 && Plots.Classify(loc, x, y) == "debris"; hit++)
                        foreach (var o in this.UseToolOnce(tool, t)) yield return o;
                    if (Plots.Classify(loc, x, y) == "debris")
                        skipped++;
                    else
                        cleared++;
                }
            J.Message = $"cleared {cleared} debris in ({r.X},{r.Y}) {r.Width}x{r.Height}" + (skipped > 0 ? $", {skipped} could not be cleared" : "");
        }

        private IEnumerable<object> BuyAnimal(string type)
        {
            if (Game1.currentLocation.Name != "AnimalShop")
                foreach (var o in this.GotoLocation("AnimalShop")) yield return o;
            if (!ShopkeeperHere("Marnie"))
                throw new ActionFailed("Marnie isn't at the ranch counter right now (open 9:00-16:00, closed Mon/Tue)");
            var farm = Game1.getFarm();
            string q = type.ToLowerInvariant();
            var entry = Utility.getPurchaseAnimalStock(farm)
                .FirstOrDefault(o => o.Name.ToLowerInvariant() == q || o.DisplayName.ToLowerInvariant() == q || o.Name.ToLowerInvariant().Contains(q))
                ?? throw new ActionFailed($"Marnie doesn't sell '{type}'");
            int price = entry.salePrice();
            if (P.Money < price)
                throw new ActionFailed($"{entry.DisplayName} costs {price}g, you have {P.Money}g");
            var animal = new FarmAnimal(entry.Name, this.mod.Helper.Multiplayer.GetNewID(), P.UniqueMultiplayerID);
            var home = farm.buildings.FirstOrDefault(b => !b.isUnderConstruction() && b.GetIndoors() is AnimalHouse h && !h.isFull() && animal.CanLiveIn(b))
                       ?? throw new ActionFailed($"no finished building with room for a {entry.DisplayName} (build a coop/barn first)");
            string name;
            int n = 1;
            do
                name = $"{entry.DisplayName} {n++}";
            while (Utility.areThereAnyOtherAnimalsWithThisName(name));
            animal.Name = name;
            animal.displayName = name;
            ((AnimalHouse)home.GetIndoors()).adoptAnimal(animal);
            P.Money -= price;
            J.Message = $"bought {name} for {price}g; it lives in the {home.buildingType.Value}";
        }

        /// <summary>Backpack slot of the tool (milk pail, shears) that harvests this animal's produce now, or -1.</summary>
        private int ToolFor(FarmAnimal animal)
        {
            if (animal.currentProduce.Value == null || !animal.isAdult() || animal.GetHarvestType() != StardewValley.GameData.FarmAnimals.FarmAnimalHarvestType.HarvestWithTool)
                return -1;
            return Enumerable.Range(0, P.Items.Count).FirstOrDefault(i => P.Items[i] is Tool t && animal.CanGetProduceWithTool(t), -1);
        }

        /// <summary>Milk or shear an adjacent animal: the same effect as MilkPail/Shears.DoFunction. Returns the item name or null.</summary>
        private string HarvestWithTool(FarmAnimal animal)
        {
            if (this.ToolFor(animal) < 0 || P.Stamina < 4)
                return null;
            var item = ItemRegistry.Create<SObject>("(O)" + animal.currentProduce.Value);
            item.CanBeSetDown = false;
            item.Quality = animal.produceQuality.Value;
            if (animal.hasEatenAnimalCracker.Value)
                item.Stack = 2;
            if (!P.addItemToInventoryBool(item))
                return null;
            P.Stamina -= 4f;
            animal.HandleStatsOnProduceCollected(item, (uint)item.Stack);
            animal.currentProduce.Value = null;
            animal.friendshipTowardFarmer.Value = Math.Min(1000, animal.friendshipTowardFarmer.Value + 5);
            animal.ReloadTextureIfNeeded();
            P.gainExperience(0, 5);
            return item.DisplayName;
        }

        private IEnumerable<object> CareAnimals()
        {
            var farm = Game1.getFarm();
            var houses = farm.buildings.Where(b => !b.isUnderConstruction() && b.GetIndoors() is AnimalHouse h && h.animalsThatLiveHere.Count > 0).ToList();
            if (houses.Count == 0)
            {
                J.Message = "no animals yet";
                yield break;
            }
            int petted = 0, fed = 0;
            var collected = new List<string>();
            foreach (var b in houses)
            {
                var house = (AnimalHouse)b.GetIndoors();
                if (!ReferenceEquals(Game1.currentLocation, house))
                    foreach (var o in this.GotoLocation(house.NameOrUniqueName)) yield return o;
                foreach (var o in this.EnsureFree()) yield return o;

                int before = house.objects.Values.Count(o => o.QualifiedItemId == "(O)178");
                house.feedAllAnimals();
                fed += house.objects.Values.Count(o => o.QualifiedItemId == "(O)178") - before;

                foreach (var animal in house.animals.Values.ToList())
                {
                    if (animal.wasPet.Value)
                        continue;
                    var t = animal.TilePoint;
                    if (World.Chebyshev(P.TilePoint, t) > 1)
                    {
                        var path = World.FindPath(house, P.TilePoint, p => World.Chebyshev(p, animal.TilePoint) <= 1, 5000);
                        if (path != null)
                            foreach (var o in this.WalkPath(path)) yield return o;
                    }
                    Face(animal.TilePoint);
                    animal.pet(P);
                    petted++;
                    for (int i = 0; i < 20; i++) yield return null;
                    if (this.HarvestWithTool(animal) is { } got)
                        collected.Add(got);
                }

                // pick up eggs and other animal products lying on the floor
                var products = house.objects.Pairs
                    .Where(kv => kv.Value.QualifiedItemId != "(O)178" && kv.Value.Category is SObject.EggCategory or SObject.MilkCategory or SObject.sellAtPierresAndMarnies)
                    .Select(kv => new Point((int)kv.Key.X, (int)kv.Key.Y)).ToHashSet();
                while (products.Count > 0)
                {
                    Point? target = null;
                    foreach (var o in this.ApproachNearest(products, x => target = x, canStandOn: false)) yield return o;
                    if (target == null)
                        break;
                    string name = house.objects[new Vector2(target.Value.X, target.Value.Y)].DisplayName;
                    Face(target.Value);
                    house.checkAction(new xTile.Dimensions.Location(target.Value.X, target.Value.Y), Game1.viewport, P);
                    for (int i = 0; i < 10; i++) yield return null;
                    products.Remove(target.Value);
                    if (!house.objects.ContainsKey(new Vector2(target.Value.X, target.Value.Y)))
                        collected.Add(name);
                }
            }
            // animals grazing outside: pet them and milk/shear them on the farm
            var outside = farm.animals.Values.Where(a => houses.Contains(a.home) && (!a.wasPet.Value || this.ToolFor(a) >= 0)).ToList();
            if (outside.Count > 0 && !ReferenceEquals(Game1.currentLocation, farm))
                foreach (var o in this.GotoLocation("Farm")) yield return o;
            foreach (var animal in outside)
            {
                var path = World.FindPath(farm, P.TilePoint, p => World.Chebyshev(p, animal.TilePoint) <= 1, 20000);
                if (path == null)
                    continue;
                foreach (var o in this.WalkPath(path)) yield return o;
                Face(animal.TilePoint);
                if (!animal.wasPet.Value)
                {
                    animal.pet(P);
                    petted++;
                    for (int i = 0; i < 20; i++) yield return null;
                }
                if (this.HarvestWithTool(animal) is { } got)
                    collected.Add(got);
            }

            J.Data["collected"] = collected;
            J.Message = $"animals: petted {petted}, filled {fed} troughs with hay" + (collected.Count > 0 ? $", collected {string.Join(", ", collected)}" : "");
        }

        /// <summary>Hold a tool so interacting with a machine collects instead of inserting the held item.</summary>
        private void HoldTool()
        {
            int safe = Enumerable.Range(0, P.Items.Count).FirstOrDefault(i => P.Items[i] is Tool || P.Items[i] == null, -1);
            if (safe >= 0)
                P.CurrentToolIndex = safe;
        }

        private IEnumerable<object> CollectMachines()
        {
            var collected = new List<string>();
            foreach (var group in Machines.All().Where(m => m.machine.readyForHarvest.Value && m.machine.heldObject.Value != null).GroupBy(m => m.loc).ToList())
            {
                if (!ReferenceEquals(Game1.currentLocation, group.Key))
                    foreach (var o in this.GotoLocation(group.Key.NameOrUniqueName)) yield return o;
                foreach (var (loc, tile, machine) in group)
                {
                    if (P.Items.All(i => i != null) && P.Items.Count >= P.MaxItems)
                    {
                        J.Data["stopped"] = "inventory full";
                        break;
                    }
                    if (World.Chebyshev(P.TilePoint, tile) > 1)
                        foreach (var o in this.WalkTo(tile, adjacent: true)) yield return o;
                    foreach (var o in this.EnsureFree()) yield return o;
                    Face(tile);
                    HoldTool();
                    string name = machine.heldObject.Value?.DisplayName;
                    loc.checkAction(new xTile.Dimensions.Location(tile.X, tile.Y), Game1.viewport, P);
                    for (int i = 0; i < 10; i++) yield return null;
                    if (!machine.readyForHarvest.Value)
                        collected.Add($"{name} from {machine.DisplayName}");
                }
            }
            J.Data["collected"] = collected;
            J.Message = collected.Count == 0 ? "no machine has finished output" : $"collected: {string.Join(", ", collected)}";
        }

        private IEnumerable<object> LoadMachines(string only)
        {
            var loaded = new List<string>();
            foreach (var group in Machines.All().Where(m => m.machine.heldObject.Value == null).GroupBy(m => m.loc).ToList())
            {
                foreach (var (loc, tile, machine) in group)
                {
                    int slot = Machines.AcceptedSlot(machine, P, only);
                    if (slot < 0)
                        slot = Machines.StockFromChests(machine, P, only);  // ore and coal usually sit in the chest
                    if (slot < 0)
                        continue;
                    if (!ReferenceEquals(Game1.currentLocation, loc))
                        foreach (var o in this.GotoLocation(loc.NameOrUniqueName)) yield return o;
                    if (World.Chebyshev(P.TilePoint, tile) > 1)
                        foreach (var o in this.WalkTo(tile, adjacent: true)) yield return o;
                    foreach (var o in this.EnsureFree()) yield return o;
                    slot = Machines.AcceptedSlot(machine, P, only);
                    if (slot < 0)
                        continue;
                    string name = P.Items[slot].DisplayName;
                    Face(tile);
                    P.CurrentToolIndex = slot;
                    loc.checkAction(new xTile.Dimensions.Location(tile.X, tile.Y), Game1.viewport, P);
                    for (int i = 0; i < 10; i++) yield return null;
                    if (machine.heldObject.Value != null)
                        loaded.Add($"{name} -> {machine.DisplayName} (ready in {machine.MinutesUntilReady} min)");
                }
            }
            J.Data["loaded"] = loaded;
            J.Message = loaded.Count == 0 ? "no empty machine accepts anything in the backpack or the farm chests" : $"loaded: {string.Join(", ", loaded)}";
        }

        private IEnumerable<object> Cook(string query, int count)
        {
            if (Game1.currentLocation is not FarmHouse)
                foreach (var o in this.GotoLocation("FarmHouse")) yield return o;
            var house = (FarmHouse)Game1.currentLocation;
            if (house.upgradeLevel < 1)
                throw new ActionFailed("no kitchen yet: Robin's first house upgrade (10000g + 450 wood) adds one");
            var recipe = Crafting.Find(query, cooking: true) ?? throw new ActionFailed($"no known cooking recipe '{query}' (recipes come from TV 'Queen of Sauce' on Sundays and from friends' letters)");
            int made = Crafting.Craft(recipe, count, out string problem, extraChests: new[] { house.fridge.Value });
            if (made == 0)
                throw new ActionFailed($"can't cook {recipe.DisplayName}: {problem}");
            J.Message = $"cooked {made}x {recipe.DisplayName}" + (problem != null ? $" (stopped: {problem})" : "");
        }

        private IEnumerable<object> CheckMail()
        {
            if (Game1.mailbox.Count == 0)
            {
                J.Message = "mailbox is empty";
                yield break;
            }
            if (Game1.currentLocation is not Farm)
                foreach (var o in this.GotoLocation("Farm")) yield return o;
            var farm = (Farm)Game1.currentLocation;
            var box = farm.GetMainMailboxPosition();
            if (World.Chebyshev(P.TilePoint, box) > 1)
                foreach (var o in this.WalkTo(box, adjacent: true)) yield return o;

            var letters = new List<string>();
            var items = new List<string>();
            for (int n = 0; n < 20 && Game1.mailbox.Count > 0; n++)
            {
                foreach (var o in this.EnsureFree()) yield return o;
                Face(box);
                farm.mailbox();
                for (int i = 0; i < 20; i++) yield return null;
                if (Game1.activeClickableMenu is not LetterViewerMenu letter)
                    continue;

                string text = string.Join(" ", letter.mailMessage).Replace("^", " ").Trim();
                if (text.Length > 500)
                    text = text.Substring(0, 500) + "...";
                foreach (var c in letter.itemsToGrab)
                {
                    if (c.item != null && P.addItemToInventoryBool(c.item))
                        items.Add($"{c.item.Stack}x {c.item.DisplayName}");
                    c.item = null;
                }
                if (!string.IsNullOrEmpty(letter.learnedRecipe))
                    text += $" [learned recipe: {letter.learnedRecipe}]";
                if (!string.IsNullOrEmpty(letter.questID))
                {
                    this.mod.Helper.Reflection.GetMethod(letter, "AcceptQuest", required: false)?.Invoke();
                    text += " [quest accepted]";
                }
                letters.Add(text);
                this.mod.Log.Add("mail", text);
                letter.exitThisMenu(false);
                for (int i = 0; i < 10; i++) yield return null;
            }
            J.Data["letters"] = letters;
            J.Data["items"] = items;
            J.Message = $"read {letters.Count} letters" + (items.Count > 0 ? $", got {string.Join(", ", items)}" : "");
        }

        // =====================================================================
        // macros
        // =====================================================================

        private static IEnumerable<Point> Around(Point p)
        {
            yield return p;
            yield return new Point(p.X, p.Y - 1);
            yield return new Point(p.X + 1, p.Y);
            yield return new Point(p.X, p.Y + 1);
            yield return new Point(p.X - 1, p.Y);
        }

        /// <summary>Walk to the nearest tile from which some target is reachable (on it or 4-adjacent). Returns the chosen target or null.</summary>
        private IEnumerable<object> ApproachNearest(HashSet<Point> targets, Action<Point?> chosen, bool canStandOn)
        {
            var loc = Game1.currentLocation;
            bool Goal(Point p) => Around(p).Skip(canStandOn ? 0 : 1).Any(targets.Contains);
            var path = World.FindPath(loc, P.TilePoint, Goal, 60000);
            if (path == null)
            {
                chosen(null);
                yield break;
            }
            foreach (var o in this.WalkPath(path)) yield return o;
            var here = P.TilePoint;
            var pick = Around(here).Skip(canStandOn ? 0 : 1).Where(targets.Contains).Select(p => (Point?)p).FirstOrDefault();
            chosen(pick);
        }

        private IEnumerable<object> WaterCrops(int max)
        {
            var loc = Game1.currentLocation;
            if (loc.IsRainingHere())
            {
                J.Message = "it's raining here, crops are watered automatically";
                yield break;
            }
            int watered = 0;
            var skip = new HashSet<Point>();
            while (watered < max)
            {
                if (P.Stamina < 4)
                {
                    J.Message = $"stopped for low stamina after watering {watered}";
                    yield break;
                }
                var targets = loc.terrainFeatures.Pairs
                    .Where(kv => kv.Value is HoeDirt d && d.crop != null && !d.crop.dead.Value && d.state.Value != 1 && !d.readyForHarvest())
                    .Select(kv => new Point((int)kv.Key.X, (int)kv.Key.Y))
                    .Where(p => !skip.Contains(p))
                    .ToHashSet();
                if (targets.Count == 0)
                    break;

                int canSlot = World.FindToolSlot("watering_can");
                if (canSlot < 0)
                    throw new ActionFailed("no watering can");
                if (((WateringCan)P.Items[canSlot]).WaterLeft <= 0)
                {
                    foreach (var o in this.RefillWateringCan()) yield return o;
                    continue;
                }

                Point? target = null;
                foreach (var o in this.ApproachNearest(targets, t => target = t, canStandOn: true)) yield return o;
                if (target == null)
                {
                    J.Data["unreachable"] = targets.Count;
                    break;
                }
                foreach (var o in this.UseToolOnce("watering_can", target.Value)) yield return o;
                if (loc.terrainFeatures.TryGetValue(new Vector2(target.Value.X, target.Value.Y), out var tf) && tf is HoeDirt dirt && dirt.state.Value == 1)
                    watered++;
                else
                    skip.Add(target.Value);
            }
            J.Data["watered"] = watered;
            J.Message = $"watered {watered} crops";
        }

        private IEnumerable<object> HarvestCrops(int max)
        {
            var loc = Game1.currentLocation;
            int harvested = 0;
            var skip = new HashSet<Point>();
            while (harvested < max)
            {
                var targets = loc.terrainFeatures.Pairs
                    .Where(kv => kv.Value is HoeDirt d && d.crop != null && d.readyForHarvest())
                    .Select(kv => new Point((int)kv.Key.X, (int)kv.Key.Y))
                    .Where(p => !skip.Contains(p))
                    .ToHashSet();
                if (targets.Count == 0)
                    break;
                Point? target = null;
                foreach (var o in this.ApproachNearest(targets, t => target = t, canStandOn: true)) yield return o;
                if (target == null)
                {
                    J.Data["unreachable"] = targets.Count;
                    break;
                }
                var t = target.Value;
                var v = new Vector2(t.X, t.Y);
                foreach (var o in this.EnsureFree()) yield return o;
                Face(t);
                loc.checkAction(new xTile.Dimensions.Location(t.X, t.Y), Game1.viewport, P);
                for (int i = 0; i < 10; i++) yield return null;
                if (loc.terrainFeatures.TryGetValue(v, out var tf) && tf is HoeDirt dirt && dirt.crop != null && dirt.readyForHarvest() && World.FindToolSlot("scythe") >= 0)
                    foreach (var o in this.UseToolOnce("scythe", t)) yield return o;

                if (loc.terrainFeatures.TryGetValue(v, out tf) && tf is HoeDirt after && after.crop != null && after.readyForHarvest())
                {
                    skip.Add(t);
                    if (P.Items.All(i => i != null) && P.Items.Count >= P.MaxItems)
                    {
                        J.Message = $"inventory full after harvesting {harvested}";
                        J.Data["harvested"] = harvested;
                        yield break;
                    }
                }
                else
                    harvested++;
            }
            J.Data["harvested"] = harvested;
            J.Message = $"harvested {harvested} crops" + (skip.Count > 0 ? $", {skip.Count} could not be harvested" : "");
        }

        private IEnumerable<object> ClearDebris(Point? at, int radius, int max, List<string> kinds)
        {
            var loc = Game1.currentLocation;
            var wanted = kinds.Count > 0 ? kinds.Select(k => k.ToLowerInvariant()).ToHashSet() : new HashSet<string> { "weed", "stone", "twig" };
            Point center = at ?? P.TilePoint;
            if (at == null)
            {
                // no target given: work around the nearest reachable debris we have a tool for
                var clearable = wanted.Where(k => World.FindToolSlot(k == "stone" ? "pickaxe" : "axe") >= 0 || k == "weed" && World.FindToolSlot("scythe") >= 0).ToHashSet();
                var all = loc.objects.Pairs.Where(kv => clearable.Contains(World.ObjectKind(kv.Value)))
                    .Select(kv => new Point((int)kv.Key.X, (int)kv.Key.Y)).ToHashSet();
                var near = World.FindPath(loc, P.TilePoint, p => Around(p).Skip(1).Any(all.Contains), 60000);
                if (near != null)
                    center = near.Count > 0 ? near[^1] : P.TilePoint;
            }
            int cleared = 0;
            var skip = new HashSet<Point>();
            while (cleared < max)
            {
                if (P.Stamina < 4)
                {
                    J.Message = $"stopped for low stamina after clearing {cleared}";
                    J.Data["cleared"] = cleared;
                    yield break;
                }
                var targets = loc.objects.Pairs
                    .Where(kv => wanted.Contains(World.ObjectKind(kv.Value)))
                    .Select(kv => new Point((int)kv.Key.X, (int)kv.Key.Y))
                    .Where(p => World.Chebyshev(p, center) <= radius && !skip.Contains(p))
                    .ToHashSet();
                if (targets.Count == 0)
                    break;
                Point? target = null;
                foreach (var o in this.ApproachNearest(targets, t => target = t, canStandOn: false)) yield return o;
                if (target == null)
                {
                    J.Data["unreachable"] = targets.Count;
                    break;
                }
                var t = target.Value;
                string kind = World.ObjectKind(loc.objects[new Vector2(t.X, t.Y)]);
                string tool = kind switch
                {
                    "stone" => "pickaxe",
                    "twig" => "axe",
                    _ => World.FindToolSlot("scythe") >= 0 ? "scythe" : "axe"
                };
                if (World.FindToolSlot(tool) < 0)
                {
                    // can't clear this kind without the tool; skip it instead of failing the whole sweep
                    skip.Add(t);
                    J.Data["missing_tool"] = tool;
                    continue;
                }
                for (int hit = 0; hit < 4 && !TileCleared(loc, t); hit++)
                    foreach (var o in this.UseToolOnce(tool, t)) yield return o;
                if (TileCleared(loc, t))
                    cleared++;
                else
                    skip.Add(t);
            }
            J.Data["cleared"] = cleared;
            J.Message = $"cleared {cleared} debris within {radius} tiles of ({center.X},{center.Y})";
            if (cleared == 0)
            {
                // tell the agent where reachable debris actually is
                var clearable = wanted.Where(k => World.FindToolSlot(k == "stone" ? "pickaxe" : "axe") >= 0 || k == "weed" && World.FindToolSlot("scythe") >= 0).ToHashSet();
                var all = loc.objects.Pairs.Where(kv => clearable.Contains(World.ObjectKind(kv.Value)))
                    .Select(kv => new Point((int)kv.Key.X, (int)kv.Key.Y)).ToHashSet();
                var path = World.FindPath(loc, P.TilePoint, p => Around(p).Skip(1).Any(all.Contains), 60000);
                J.Message += path == null
                    ? $"; none of the {all.Count} {string.Join("/", wanted)} in {loc.NameOrUniqueName} is reachable"
                    : $"; nearest reachable debris is next to ({(path.Count > 0 ? path[^1] : P.TilePoint).X},{(path.Count > 0 ? path[^1] : P.TilePoint).Y}), call clear_debris with that x,y";
            }
            var unknown = wanted.Where(k => k is not ("weed" or "stone" or "twig")).ToList();
            if (unknown.Count > 0)
                J.Message += $"; unsupported kinds ignored: {string.Join(",", unknown)} (use use_tool axe/pickaxe with until_cleared for trees/boulders)";
        }

        /// <summary>Till, clear and plant a rectangular plot row by row (snake order), so beds stay tidy.</summary>
        private IEnumerable<object> PlantInPlot(string seed, int count, Rectangle plot)
        {
            var loc = Game1.currentLocation;
            int slot = this.RequireSlot(seed);
            var seedItem = P.Items[slot];
            if (seedItem.Category != SObject.SeedsCategory)
                throw new ActionFailed($"{seedItem.DisplayName} is not a seed");
            string seedName = seedItem.DisplayName;
            int planted = 0, skipped = 0;
            string stop = null;

            for (int row = 0; row < plot.Height && planted < count && stop == null; row++)
            {
                int y = plot.Y + row;
                for (int i = 0; i < plot.Width && planted < count; i++)
                {
                    int x = row % 2 == 0 ? plot.X + i : plot.Right - 1 - i;
                    var t = new Point(x, y);
                    var v = new Vector2(x, y);
                    if (World.FindItemSlot(seedItem.QualifiedItemId) < 0)
                    {
                        stop = "out of seeds";
                        break;
                    }
                    if (P.Stamina < 4)
                    {
                        stop = "low stamina";
                        break;
                    }

                    string kind = Plots.Classify(loc, x, y);
                    if (kind is "planted" or "blocked")
                    {
                        if (kind == "blocked")
                            skipped++;
                        continue;
                    }
                    if (kind == "debris")
                    {
                        string tool = "scythe";
                        if (loc.objects.TryGetValue(v, out var obj))
                        {
                            string objKind = World.ObjectKind(obj);
                            tool = objKind == "stone" ? "pickaxe" : objKind == "twig" ? "axe" : World.FindToolSlot("scythe") >= 0 ? "scythe" : "axe";
                        }
                        if (World.FindToolSlot(tool) < 0)
                        {
                            skipped++;
                            continue;
                        }
                        for (int hit = 0; hit < 4 && Plots.Classify(loc, x, y) == "debris"; hit++)
                            foreach (var o in this.UseToolOnce(tool, t)) yield return o;
                        if (Plots.Classify(loc, x, y) != "usable")
                        {
                            skipped++;
                            continue;
                        }
                    }
                    if (Plots.Classify(loc, x, y) == "usable")
                        foreach (var o in this.UseToolOnce("hoe", t)) yield return o;
                    if (Plots.Classify(loc, x, y) != "tilled")
                    {
                        skipped++;
                        continue;
                    }

                    if (World.Chebyshev(P.TilePoint, t) > 1)
                        foreach (var o in this.WalkTo(t, adjacent: true)) yield return o;
                    foreach (var o in this.EnsureFree()) yield return o;
                    slot = World.FindItemSlot(seedItem.QualifiedItemId);
                    if (!this.PlaceHere(slot, t))
                    {
                        if (planted == 0 && ++skipped > 3)
                            throw new ActionFailed($"can't plant {seedName} here (wrong season?)");
                        continue;
                    }
                    planted++;
                    int canSlot = World.FindToolSlot("watering_can");
                    if (!loc.IsRainingHere() && canSlot >= 0 && ((WateringCan)P.Items[canSlot]).WaterLeft > 0)
                        foreach (var o in this.UseToolOnce("watering_can", t)) yield return o;
                }
            }
            J.Data["planted"] = planted;
            J.Data["plot"] = Plots.Check(loc, plot);
            J.Message = $"planted {planted}x {seedName} in plot ({plot.X},{plot.Y}) {plot.Width}x{plot.Height}"
                        + (skipped > 0 ? $", {skipped} tiles unusable" : "") + (stop != null ? $"; stopped: {stop}" : "");
        }

        private IEnumerable<object> PlantSeeds(string seed, int count, Point anchor)
        {
            var loc = Game1.currentLocation;
            int slot = this.RequireSlot(seed);
            var seedItem = P.Items[slot];
            if (seedItem.Category != SObject.SeedsCategory)
                throw new ActionFailed($"{seedItem.DisplayName} is not a seed");
            string seedName = seedItem.DisplayName;
            int planted = 0;
            var skip = new HashSet<Point>();
            while (planted < count)
            {
                slot = World.FindItemSlot(seedItem.QualifiedItemId);
                if (slot < 0)
                    break; // out of seeds
                if (P.Stamina < 4)
                {
                    J.Message = $"stopped for low stamina after planting {planted}";
                    break;
                }

                // prefer empty tilled soil, then clear tillable ground, closest to the anchor
                var candidates = loc.terrainFeatures.Pairs
                    .Where(kv => kv.Value is HoeDirt d && d.crop == null)
                    .Select(kv => new Point((int)kv.Key.X, (int)kv.Key.Y))
                    .Where(p => !skip.Contains(p) && !loc.objects.ContainsKey(new Vector2(p.X, p.Y)))
                    .OrderBy(p => World.Manhattan(p, anchor))
                    .Take(1)
                    .ToList();
                if (candidates.Count == 0)
                {
                    for (int r = 0; r <= 12 && candidates.Count == 0; r++)
                        for (int x = anchor.X - r; x <= anchor.X + r; x++)
                            for (int y = anchor.Y - r; y <= anchor.Y + r; y++)
                            {
                                var p = new Point(x, y);
                                var v = new Vector2(x, y);
                                if (World.Chebyshev(p, anchor) != r || skip.Contains(p))
                                    continue;
                                if (loc.doesTileHaveProperty(x, y, "Diggable", "Back") == null || loc.objects.ContainsKey(v)
                                    || loc.terrainFeatures.ContainsKey(v) || !World.IsWalkable(loc, x, y))
                                    continue;
                                candidates.Add(p);
                            }
                }
                if (candidates.Count == 0)
                {
                    J.Message = "no free soil near the anchor; clear debris or pick another spot";
                    break;
                }
                var target = candidates[0];
                var tv = new Vector2(target.X, target.Y);

                foreach (var o in this.WalkTo(target, adjacent: true)) yield return o;
                if (!loc.terrainFeatures.ContainsKey(tv))
                    foreach (var o in this.UseToolOnce("hoe", target)) yield return o;
                if (!(loc.terrainFeatures.TryGetValue(tv, out var tf) && tf is HoeDirt))
                {
                    skip.Add(target);
                    continue;
                }
                foreach (var o in this.EnsureFree()) yield return o;
                if (!this.PlaceHere(slot, target))
                {
                    if (planted == 0 && skip.Count > 3)
                        throw new ActionFailed($"can't plant {seedName} (wrong season?)");
                    skip.Add(target);
                    continue;
                }
                planted++;
                int canSlot = World.FindToolSlot("watering_can");
                if (!loc.IsRainingHere() && canSlot >= 0 && ((WateringCan)P.Items[canSlot]).WaterLeft > 0)
                    foreach (var o in this.UseToolOnce("watering_can", target)) yield return o;
            }
            J.Data["planted"] = planted;
            J.Message ??= $"planted {planted}x {seedName}";
        }

        private IEnumerable<object> Forage(int max)
        {
            var loc = Game1.currentLocation;
            int picked = 0;
            var skip = new HashSet<Point>();
            var names = new List<string>();
            while (picked < max)
            {
                var targets = loc.objects.Pairs
                    .Where(kv => kv.Value.IsSpawnedObject)
                    .Select(kv => new Point((int)kv.Key.X, (int)kv.Key.Y))
                    .Where(p => !skip.Contains(p))
                    .ToHashSet();
                if (targets.Count == 0)
                    break;
                Point? target = null;
                foreach (var o in this.ApproachNearest(targets, t => target = t, canStandOn: false)) yield return o;
                if (target == null)
                    break;
                var v = new Vector2(target.Value.X, target.Value.Y);
                string name = loc.objects[v].DisplayName;
                foreach (var o in this.EnsureFree()) yield return o;
                Face(target.Value);
                loc.checkAction(new xTile.Dimensions.Location(target.Value.X, target.Value.Y), Game1.viewport, P);
                for (int i = 0; i < 10; i++) yield return null;
                if (loc.objects.ContainsKey(v))
                    skip.Add(target.Value);
                else
                {
                    picked++;
                    names.Add(name);
                }
            }
            J.Data["picked"] = names;
            J.Message = $"picked up {picked} forage items";
        }

        // =====================================================================
        // argument helpers
        // =====================================================================

        private static string Str(JsonElement a, string key)
        {
            if (a.ValueKind != JsonValueKind.Object || !a.TryGetProperty(key, out var v) || v.ValueKind == JsonValueKind.Null)
                return null;
            return v.ValueKind == JsonValueKind.String ? v.GetString() : v.GetRawText();
        }

        private static string Req(JsonElement a, string key) => Str(a, key) ?? throw new ActionFailed($"missing argument '{key}'");

        private static int Int(JsonElement a, string key, int def)
        {
            string s = Str(a, key);
            return s != null && double.TryParse(s, out double d) ? (int)d : def;
        }

        private static bool Bool(JsonElement a, string key) => Str(a, key)?.ToLowerInvariant() is "true" or "1";

        private static List<string> StrList(JsonElement a, string key)
        {
            if (a.ValueKind == JsonValueKind.Object && a.TryGetProperty(key, out var v))
            {
                if (v.ValueKind == JsonValueKind.Array)
                    return v.EnumerateArray().Select(e => e.ToString()).ToList();
                if (v.ValueKind == JsonValueKind.String)
                    return v.GetString().Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
            }
            return new List<string>();
        }

        private static Point? OptXY(JsonElement a)
        {
            if (Str(a, "x") == null || Str(a, "y") == null)
                return null;
            return new Point(Int(a, "x", 0), Int(a, "y", 0));
        }

        private static List<Point> TilesArg(JsonElement a, string key)
        {
            var list = new List<Point>();
            if (a.TryGetProperty(key, out var arr) && arr.ValueKind == JsonValueKind.Array)
                foreach (var t in arr.EnumerateArray())
                    if (t.ValueKind == JsonValueKind.Array && t.GetArrayLength() >= 2)
                        list.Add(new Point(t[0].GetInt32(), t[1].GetInt32()));
            if (list.Count == 0)
                throw new ActionFailed($"missing '{key}' [[x,y],...]");
            return list;
        }

        private static Rectangle? RectArg(JsonElement a, string key)
        {
            if (a.ValueKind != JsonValueKind.Object || !a.TryGetProperty(key, out var r) || r.ValueKind != JsonValueKind.Object)
                return null;
            int w = Int(r, "w", 0), h = Int(r, "h", 0);
            return w > 0 && h > 0 ? new Rectangle(Int(r, "x", 0), Int(r, "y", 0), w, h) : null;
        }

        private static Point XY(JsonElement a) => OptXY(a) ?? throw new ActionFailed("missing arguments 'x' and 'y'");
    }
}
