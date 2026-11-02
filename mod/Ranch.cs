using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Buildings;

namespace StardewAutoPilot
{
    /// <summary>Farm buildings (Robin) and animals (Marnie), read from the game's data.</summary>
    internal static class Ranch
    {
        public static Dictionary<string, object> Status()
        {
            var farm = Game1.getFarm();
            var buildings = farm.buildings.Where(b => b is not ShippingBin && b.buildingType.Value != "Farmhouse").Select(b =>
            {
                var info = new Dictionary<string, object>
                {
                    ["type"] = b.buildingType.Value,
                    ["x"] = b.tileX.Value,
                    ["y"] = b.tileY.Value,
                    ["w"] = b.tilesWide.Value,
                    ["h"] = b.tilesHigh.Value
                };
                if (b.daysOfConstructionLeft.Value > 0)
                    info["days_until_built"] = b.daysOfConstructionLeft.Value;
                if (b.GetIndoors() is AnimalHouse house)
                    info["animals"] = $"{house.animalsThatLiveHere.Count}/{house.animalLimit.Value}";
                return info;
            }).ToList();

            var blueprints = Game1.buildingData
                .Where(kv => kv.Value.Builder == "Robin" && GameStateQuery.CheckConditions(kv.Value.BuildCondition))
                .Select(kv => new Dictionary<string, object>
                {
                    ["type"] = kv.Key,
                    ["cost"] = kv.Value.BuildCost,
                    ["materials"] = (kv.Value.BuildMaterials ?? new()).Select(m => $"{ItemRegistry.GetDataOrErrorItem(m.ItemId).DisplayName} x{m.Amount}").ToList(),
                    ["size"] = $"{kv.Value.Size.X}x{kv.Value.Size.Y}",
                    ["days"] = kv.Value.BuildDays,
                    ["upgrade_from"] = kv.Value.BuildingToUpgrade
                }).ToList();

            List<object> animalsForSale = new();
            try
            {
                animalsForSale = Utility.getPurchaseAnimalStock(farm)
                    .Select(o => (object)new { type = o.Name, name = o.DisplayName, price = o.salePrice(), available = o.Type == null })
                    .ToList();
            }
            catch { }

            var animals = farm.getAllFarmAnimals().Select(a => new
            {
                name = a.displayName,
                type = a.type.Value,
                home = a.home?.buildingType.Value,
                pet_today = a.wasPet.Value,
                friendship = a.friendshipTowardFarmer.Value,
                has_produce = !string.IsNullOrEmpty(a.currentProduce.Value)
            }).ToList();

            return new Dictionary<string, object>
            {
                ["buildings"] = buildings,
                ["robin_busy"] = Game1.IsThereABuildingUnderConstruction("Robin"),
                ["can_build"] = blueprints,
                ["animals_for_sale"] = animalsForSale,
                ["animals"] = animals
            };
        }

        /// <summary>
        /// Same rules as GameLocation.isBuildable, but against the farm's own map (the game's version reads
        /// Game1.currentLocation, which is wrong unless the camera is on the farm). Clearable debris can be allowed.
        /// </summary>
        public static bool IsBuildable(Farm farm, int x, int y, bool allowDebris)
        {
            var v = new Vector2(x, y);
            var rect = farm.GetBuildableRectangle();
            if (rect != Rectangle.Empty && !rect.Contains(x, y))
                return false;
            if (farm.getBuildingAt(v) != null)
                return false;
            string buildable = farm.doesTileHavePropertyNoNull(x, y, "Buildable", "Back");
            bool allowedGround = buildable.Equals("t", StringComparison.OrdinalIgnoreCase) || buildable.Equals("true", StringComparison.OrdinalIgnoreCase)
                                 || farm.doesTileHaveProperty(x, y, "Diggable", "Back") != null && !buildable.Equals("f", StringComparison.OrdinalIgnoreCase);
            if (!allowedGround)
                return false;
            if (allowDebris && Plots.Classify(farm, x, y) == "debris")
                return true;
            return farm.CanItemBePlacedHere(v, false, StardewValley.CollisionMask.All, ~StardewValley.CollisionMask.Objects, useFarmerTile: true);
        }

        public static int DebrisIn(Farm farm, Rectangle r)
        {
            int n = 0;
            for (int x = r.X; x < r.Right; x++)
                for (int y = r.Y; y < r.Bottom; y++)
                    if (Plots.Classify(farm, x, y) == "debris")
                        n++;
            return n;
        }

        /// <summary>Tidy building sites: the whole footprint plus a 1-tile margin must be buildable.</summary>
        public static List<int[]> FindSites(string type, Point near, int max = 6)
        {
            var farm = Game1.getFarm();
            if (!Game1.buildingData.TryGetValue(type, out var data))
                return new List<int[]>();
            int w = data.Size.X, h = data.Size.Y;
            var found = new List<(int dist, int[] xy)>();
            for (int x = 1; x < farm.Map.Layers[0].LayerWidth - w - 1; x++)
                for (int y = 1; y < farm.Map.Layers[0].LayerHeight - h - 2; y++)
                {
                    bool ok = true;
                    // footprint + margin, plus two free rows below for the door and a path
                    for (int dx = -1; dx <= w && ok; dx++)
                        for (int dy = -1; dy <= h + 1 && ok; dy++)
                            ok = IsBuildable(farm, x + dx, y + dy, allowDebris: true);
                    if (ok)
                    {
                        int debris = DebrisIn(farm, new Rectangle(x, y, w, h + 1));
                        found.Add((Math.Abs(x + w / 2 - near.X) + Math.Abs(y + h / 2 - near.Y) + debris / 3, new[] { x, y, w, h, debris }));
                    }
                }
            var result = new List<int[]>();
            foreach (var (_, xy) in found.OrderBy(f => f.dist))
            {
                var r = new Rectangle(xy[0] - 1, xy[1] - 1, xy[2] + 2, xy[3] + 3);
                if (result.Any(o => new Rectangle(o[0] - 1, o[1] - 1, o[2] + 2, o[3] + 3).Intersects(r)))
                    continue;
                result.Add(xy);
                if (result.Count >= max)
                    break;
            }
            return result;
        }
    }
}
