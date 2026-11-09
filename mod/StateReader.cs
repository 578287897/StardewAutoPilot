using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Monsters;
using StardewValley.TerrainFeatures;
using StardewValley.Tools;
using SObject = StardewValley.Object;

namespace StardewAutoPilot
{
    internal static class StateReader
    {
        public static Dictionary<string, object> GetState(ModEntry mod)
        {
            // the date flips to tomorrow early in the night, before the save: not ready until SMAPI's DayStarted
            if (!Context.IsWorldReady || Game1.showingEndOfNightStuff || mod.DayStartedFor != Game1.Date.TotalDays)
            {
                return new Dictionary<string, object>
                {
                    ["ready"] = false,
                    ["reason"] = Game1.activeClickableMenu is TitleMenu ? "title_screen" : Context.IsWorldReady ? "night_in_progress" : "loading_or_saving",
                    ["menu"] = Game1.activeClickableMenu == null ? null : MenuAutomation.Describe(mod, Game1.activeClickableMenu)
                };
            }

            var p = Game1.player;
            var inventory = new List<object>();
            for (int i = 0; i < p.Items.Count; i++)
            {
                var item = p.Items[i];
                if (item == null)
                    continue;
                var entry = new Dictionary<string, object>
                {
                    ["slot"] = i,
                    ["id"] = item.QualifiedItemId,
                    ["name"] = item.DisplayName,
                    ["stack"] = item.Stack,
                    ["category"] = item.getCategoryName()
                };
                if (item is SObject obj)
                {
                    if (obj.Quality > 0) entry["quality"] = obj.Quality;
                    if (obj.Edibility > 0) entry["edible_energy"] = (int)Math.Ceiling(obj.Edibility * 2.5);
                    entry["sell_price"] = obj.sellToStorePrice();
                }
                if (item is Tool tool)
                {
                    entry["tool_level"] = tool.UpgradeLevel;
                    if (tool is WateringCan can)
                        entry["water"] = $"{can.WaterLeft}/{can.waterCanMax}";
                }
                inventory.Add(entry);
            }

            var loc = Game1.currentLocation;
            var state = new Dictionary<string, object>
            {
                ["ready"] = true,
                ["time"] = Game1.timeOfDay,
                ["time_str"] = Game1.getTimeOfDayString(Game1.timeOfDay),
                ["day"] = Game1.dayOfMonth,
                ["season"] = Game1.currentSeason,
                ["year"] = Game1.year,
                ["weekday"] = Game1.shortDayNameFromDayOfSeason(Game1.dayOfMonth),
                ["weather"] = Game1.isLightning ? "storm" : Game1.isRaining ? "rain" : Game1.isSnowing ? "snow" : Game1.isDebrisWeather ? "windy" : "sunny",
                ["weather_tomorrow"] = Game1.weatherForTomorrow,
                ["luck"] = Math.Round(p.DailyLuck, 3),
                ["location"] = loc.NameOrUniqueName,
                ["player"] = new Dictionary<string, object>
                {
                    ["x"] = p.TilePoint.X,
                    ["y"] = p.TilePoint.Y,
                    ["facing"] = new[] { "up", "right", "down", "left" }[p.FacingDirection],
                    ["health"] = p.health,
                    ["max_health"] = p.maxHealth,
                    ["stamina"] = (int)p.Stamina,
                    ["max_stamina"] = p.MaxStamina,
                    ["money"] = p.Money,
                    ["free"] = Context.IsPlayerFree,
                    ["current_slot"] = p.CurrentToolIndex
                },
                ["skills"] = new Dictionary<string, int>
                {
                    ["farming"] = p.FarmingLevel,
                    ["mining"] = p.MiningLevel,
                    ["foraging"] = p.ForagingLevel,
                    ["fishing"] = p.FishingLevel,
                    ["combat"] = p.CombatLevel
                },
                ["inventory"] = inventory,
                ["inventory_free_slots"] = p.Items.Count(i => i == null) + Math.Max(0, p.MaxItems - p.Items.Count),
                ["exits"] = World.GetExits(loc).Select(e => e.ToJson()).ToList(),
                ["event"] = Game1.eventUp,
                ["menu"] = Game1.activeClickableMenu == null ? null : MenuAutomation.Describe(mod, Game1.activeClickableMenu),
                ["quests"] = p.questLog.Where(qu => !qu.IsHidden()).Select(qu => new Dictionary<string, object>
                {
                    ["title"] = qu.GetName(),
                    ["description"] = qu.GetDescription(),
                    ["objectives"] = qu.GetObjectiveDescriptions(),
                    ["days_left"] = qu.GetDaysLeft(),
                    ["completed"] = qu.completed.Value
                }).ToList(),
                ["unread_mail"] = Game1.mailbox.Count,
                ["festivals"] = Social.Calendar(7),
                ["community_center"] = Bundles.Stage(),
                ["community_center_target"] = Bundles.CurrentTarget(),
                ["villagers_here"] = loc.characters.Where(c => c.IsVillager && c.CanSocialize).Select(Social.Describe).ToList(),
                ["birthdays_today"] = Utility.getAllVillagers().Where(n => n.isBirthday()).Select(n => n.Name).ToList(),
                ["save_name"] = Constants.SaveFolderName,
                ["busy_action"] = mod.Runner.CurrentType,
                ["machine_inputs"] = Machines.InputSnapshot(),
                ["farm_items"] = p.Items.Concat(Crafting.FarmChests().SelectMany(c => c.Items))
                    .Where(i => i != null && i is not Tool)
                    .Select(i => new { id = i.QualifiedItemId, name = i.Name, stack = i.Stack, category = i.Category }).ToList(),
                ["farm_revision"] = mod.Runner.FarmRevision,
                ["route_revision"] = mod.Runner.RouteRevision,
                ["farm_resources"] = p.Items.Concat(Crafting.FarmChests().SelectMany(c => c.Items))
                    .Where(i => i != null && i is not Tool)
                    .GroupBy(i => i.QualifiedItemId).ToDictionary(g => g.Key, g => g.Sum(i => i.Stack)),
                ["upgrading"] = p.toolBeingUpgraded.Value == null ? null : new Dictionary<string, object>
                {
                    ["name"] = p.toolBeingUpgraded.Value.Name,
                    ["level"] = p.toolBeingUpgraded.Value.UpgradeLevel,
                    ["days_left"] = p.daysLeftForToolUpgrade.Value
                },
                ["last_message_seq"] = mod.Log.LastSeq
            };

            if (loc is Farm farm && World.ShippingBin(farm) is { } bin)
                state["shipping_bin"] = new[] { bin.tileX.Value, bin.tileY.Value };
            state["points_of_interest"] = PointsOfInterest(loc);
            var machines = Machines.Status();
            if (machines.Count > 0)
                state["machines"] = machines;
            if (Mining.Describe(loc) is { } mine)
                state["mine"] = mine;
            return state;
        }

        /// <summary>Things worth knowing about in the current location (gift boxes, chests, mailbox, bed, shipping bin).</summary>
        private static List<Dictionary<string, object>> PointsOfInterest(GameLocation loc)
        {
            var list = new List<Dictionary<string, object>>();
            void Add(string kind, int x, int y, string note) =>
                list.Add(new Dictionary<string, object> { ["kind"] = kind, ["x"] = x, ["y"] = y, ["note"] = note });

            foreach (var pair in loc.objects.Pairs)
            {
                if (pair.Value is not StardewValley.Objects.Chest chest)
                    continue;
                var items = chest.Items.Where(i => i != null).Select(i => $"{i.Stack}x {i.DisplayName}").ToList();
                if (chest.giftbox.Value)
                    Add("gift_box", (int)pair.Key.X, (int)pair.Key.Y, "unopened gift box, use interact to open: " + string.Join(", ", items));
                else
                    Add("chest", (int)pair.Key.X, (int)pair.Key.Y, items.Count == 0 ? "empty" : string.Join(", ", items.Take(10)));
            }
            switch (loc)
            {
                case Farm farm:
                    var box = farm.GetMainMailboxPosition();
                    Add("mailbox", box.X, box.Y, Game1.mailbox.Count > 0 ? $"{Game1.mailbox.Count} unread letters (check_mail)" : "no new mail");
                    if (World.ShippingBin(farm) is { } bin)
                        Add("shipping_bin", bin.tileX.Value, bin.tileY.Value, "ship_produce / ship sells items overnight");
                    break;
                case StardewValley.Locations.FarmHouse house:
                    var bed = house.GetPlayerBedSpot();
                    Add("bed", bed.X, bed.Y, "sleep ends the day and saves");
                    break;
            }
            return list;
        }

        /// <summary>ASCII map around the player. One char per tile.</summary>
        public static Dictionary<string, object> GetMap(int radius)
        {
            if (!Context.IsWorldReady)
                return new Dictionary<string, object> { ["ready"] = false };

            var loc = Game1.currentLocation;
            var center = Game1.player.TilePoint;
            int x0 = center.X - radius, y0 = center.Y - radius;
            var grid = new char[radius * 2 + 1, radius * 2 + 1];
            for (int gy = 0; gy <= radius * 2; gy++)
                for (int gx = 0; gx <= radius * 2; gx++)
                    grid[gx, gy] = TileChar(loc, x0 + gx, y0 + gy);

            void Put(int x, int y, char c)
            {
                int gx = x - x0, gy = y - y0;
                if (gx >= 0 && gy >= 0 && gx <= radius * 2 && gy <= radius * 2)
                    grid[gx, gy] = c;
            }

            foreach (var exit in World.GetExits(loc))
                Put(exit.X, exit.Y, 'E');
            if (loc is Farm farm && World.ShippingBin(farm) is { } bin)
                foreach (var t in World.BuildingTiles(bin))
                    Put(t.X, t.Y, 'B');
            var npcs = new List<object>();
            var monsters = new List<object>();
            foreach (var c in loc.characters)
            {
                var t = c.TilePoint;
                if (Math.Abs(t.X - center.X) > radius || Math.Abs(t.Y - center.Y) > radius)
                    continue;
                if (c is Monster m)
                {
                    Put(t.X, t.Y, 'M');
                    monsters.Add(new { name = m.Name, x = t.X, y = t.Y, hp = m.Health });
                }
                else
                {
                    Put(t.X, t.Y, 'N');
                    npcs.Add(new { name = c.Name, x = t.X, y = t.Y });
                }
            }
            Put(center.X, center.Y, '@');

            var rows = new List<string>();
            for (int gy = 0; gy <= radius * 2; gy++)
            {
                var sb = new StringBuilder();
                for (int gx = 0; gx <= radius * 2; gx++)
                    sb.Append(grid[gx, gy]);
                rows.Add(sb.ToString());
            }

            return new Dictionary<string, object>
            {
                ["location"] = loc.NameOrUniqueName,
                ["origin"] = new[] { x0, y0 },
                ["player"] = new[] { center.X, center.Y },
                ["rows"] = rows,
                ["npcs"] = npcs,
                ["monsters"] = monsters,
                ["legend"] = "@=you .=walkable :=walkable tillable soil #=blocked ' '=off-map ~=water E=exit B=shipping bin N=npc M=monster "
                    + "H=tilled empty soil h=tilled+watered empty R=crop ready c=crop needs water w=crop watered x=dead crop "
                    + "T=tree t=young tree S=stone W=weed L=twig/branch O=boulder/stump(big) F=forage C=chest m=machine o=other object"
            };
        }

        /// <summary>Debug view of one tile in the current location.</summary>
        public static Dictionary<string, object> GetTile(int x, int y)
        {
            var loc = Game1.currentLocation;
            return new Dictionary<string, object>
            {
                ["char"] = TileChar(loc, x, y).ToString(),
                ["water"] = loc.isWaterTile(x, y),
                ["fishable"] = loc.isTileFishable(x, y),
                ["can_fish_here"] = loc.canFishHere(),
                ["colliding"] = loc.isCollidingPosition(World.FarmerBoxAt(new Point(x, y)), Game1.viewport, true, 0, false, Game1.player),
                ["passable"] = loc.isTilePassable(new xTile.Dimensions.Location(x, y), Game1.viewport),
                ["back_index"] = loc.getTileIndexAt(x, y, "Back"),
                ["buildings_index"] = loc.getTileIndexAt(x, y, "Buildings"),
                ["front_index"] = loc.getTileIndexAt(x, y, "Front"),
                ["water_prop"] = loc.doesTileHaveProperty(x, y, "Water", "Back"),
                ["passable_prop"] = loc.doesTileHaveProperty(x, y, "Passable", "Back")
            };
        }

        private static char TileChar(GameLocation loc, int x, int y)
        {
            if (!World.InBounds(loc, x, y))
                return ' ';
            var v = new Vector2(x, y);
            if (loc.objects.TryGetValue(v, out var obj))
            {
                return World.ObjectKind(obj) switch
                {
                    "chest" => 'C',
                    "forage" => 'F',
                    "weed" => 'W',
                    "stone" => 'S',
                    "twig" => 'L',
                    "machine" => 'm',
                    _ => 'o'
                };
            }
            if (loc.resourceClumps.Any(r => r.occupiesTile(x, y)))
                return 'O';
            if (loc.terrainFeatures.TryGetValue(v, out var tf))
            {
                switch (tf)
                {
                    case HoeDirt dirt when dirt.crop != null:
                        if (dirt.crop.dead.Value) return 'x';
                        if (dirt.readyForHarvest()) return 'R';
                        return dirt.state.Value == 1 ? 'w' : 'c';
                    case HoeDirt dirt:
                        return dirt.state.Value == 1 ? 'h' : 'H';
                    case Tree tree:
                        return tree.growthStage.Value >= 5 ? 'T' : 't';
                    case FruitTree:
                        return 'T';
                }
            }
            if (loc.isWaterTile(x, y))
                return '~';
            if (!World.IsWalkable(loc, x, y))
                return '#';
            return loc.doesTileHaveProperty(x, y, "Diggable", "Back") != null ? ':' : '.';
        }

        /// <summary>Crop/soil summary for a location (default: current location, or Farm if current has no soil).</summary>
        public static Dictionary<string, object> GetCrops(string locationName)
        {
            if (!Context.IsWorldReady)
                return new Dictionary<string, object> { ["ready"] = false };

            var loc = string.IsNullOrEmpty(locationName) ? Game1.currentLocation : Game1.getLocationFromName(locationName);
            if (loc == null)
                return new Dictionary<string, object> { ["ok"] = false, ["message"] = "unknown location " + locationName };

            var needsWater = new List<int[]>();
            var ready = new List<int[]>();
            var dead = new List<int[]>();
            var emptySoil = new List<int[]>();
            var growing = new Dictionary<string, int>();
            foreach (var pair in loc.terrainFeatures.Pairs)
            {
                if (pair.Value is not HoeDirt dirt)
                    continue;
                var xy = new[] { (int)pair.Key.X, (int)pair.Key.Y };
                if (dirt.crop == null)
                {
                    emptySoil.Add(xy);
                    continue;
                }
                if (dirt.crop.dead.Value) { dead.Add(xy); continue; }
                if (dirt.readyForHarvest()) { ready.Add(xy); continue; }
                string name = World.CropName(dirt.crop);
                growing[name] = growing.TryGetValue(name, out int n) ? n + 1 : 1;
                if (dirt.state.Value != 1 && !loc.IsRainingHere())
                    needsWater.Add(xy);
            }

            int weeds = 0, stones = 0, twigs = 0, forage = 0;
            foreach (var obj in loc.objects.Values)
            {
                switch (World.ObjectKind(obj))
                {
                    case "weed": weeds++; break;
                    case "stone": stones++; break;
                    case "twig": twigs++; break;
                    case "forage": forage++; break;
                }
            }

            return new Dictionary<string, object>
            {
                ["location"] = loc.NameOrUniqueName,
                ["raining"] = loc.IsRainingHere(),
                ["growing"] = growing,
                ["needs_water"] = needsWater,
                ["ready_to_harvest"] = ready,
                ["dead"] = dead,
                ["empty_tilled_soil"] = emptySoil.Count,
                ["debris"] = new { weeds, stones, twigs, forage, trees = loc.terrainFeatures.Values.Count(t => t is Tree), big = loc.resourceClumps.Count }
            };
        }
    }
}
