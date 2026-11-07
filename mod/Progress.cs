using System.Collections.Generic;
using System.Linq;
using StardewValley;
using StardewValley.Objects;
using SObject = StardewValley.Object;

namespace StardewAutoPilot
{
    /// <summary>Facts the long-term roadmap is checked against: materials (backpack + chests), placed machines, recipes, buildings.</summary>
    internal static class Progress
    {
        private static readonly string[] Materials =
        {
            "Wood", "Stone", "Fiber", "Coal", "Copper Ore", "Iron Ore", "Gold Ore", "Iridium Ore",
            "Copper Bar", "Iron Bar", "Gold Bar", "Iridium Bar",
            "Refined Quartz", "Quartz", "Hardwood", "Sap"
        };

        private static readonly string[] Machines =
        {
            "Chest", "Scarecrow", "Furnace", "Sprinkler", "Quality Sprinkler", "Iridium Sprinkler", "Preserves Jar", "Keg",
            "Bee House", "Cask", "Cheese Press", "Mayonnaise Machine"
        };

        public static Dictionary<string, object> Status()
        {
            var counts = Materials.ToDictionary(m => m, _ => 0);
            void Count(IEnumerable<Item> items)
            {
                foreach (var item in items)
                    if (item is SObject { bigCraftable.Value: false } && counts.ContainsKey(item.Name))
                        counts[item.Name] += item.Stack;
            }
            Count(Game1.player.Items.Where(i => i != null));
            foreach (var chest in Crafting.FarmChests())
                Count(chest.Items.Where(i => i != null));

            var placed = Machines.ToDictionary(m => m, _ => 0);
            foreach (var loc in Machines_Locations())
                foreach (var obj in loc.objects.Values)
                    if (placed.ContainsKey(obj.Name) && (obj.bigCraftable.Value || obj.Name.Contains("Sprinkler")))
                        placed[obj.Name]++;

            var farm = Game1.getFarm();
            var home = Utility.getHomeOfFarmer(Game1.player);
            return new Dictionary<string, object>
            {
                ["money"] = Game1.player.Money,
                ["backpack"] = Game1.player.maxItems.Value,
                ["deepest_mine"] = Game1.player.deepestMineLevel,
                ["skills"] = new Dictionary<string, int>
                {
                    ["farming"] = Game1.player.FarmingLevel, ["mining"] = Game1.player.MiningLevel,
                    ["foraging"] = Game1.player.ForagingLevel, ["fishing"] = Game1.player.FishingLevel,
                    ["combat"] = Game1.player.CombatLevel
                },
                ["materials"] = counts,
                ["placed"] = placed,
                ["recipes"] = Game1.player.craftingRecipes.Keys.Where(k => Machines.Contains(k)).ToList(),
                ["buildings"] = farm.buildings.Select(b => b.buildingType.Value).Where(t => t != "Farmhouse" && t != "Shipping Bin" && t != "Pet Bowl").ToList(),
                ["house_level"] = home?.upgradeLevel ?? 0,
                ["house_upgrade_days"] = Game1.player.daysUntilHouseUpgrade.Value,
                ["gear"] = Gear.Status(Game1.player),
                ["tools"] = Game1.player.Items.OfType<Tool>().Where(t => t is StardewValley.Tools.Axe || t is StardewValley.Tools.Pickaxe || t is StardewValley.Tools.Hoe || t is StardewValley.Tools.WateringCan)
                    .GroupBy(t => t is StardewValley.Tools.Axe ? "axe" : t is StardewValley.Tools.Pickaxe ? "pickaxe" : t is StardewValley.Tools.Hoe ? "hoe" : "watering_can")
                    .ToDictionary(g => g.Key, g => g.Max(t => t.UpgradeLevel)),
                ["rod"] = Game1.player.Items.OfType<StardewValley.Tools.FishingRod>().OrderByDescending(r => r.UpgradeLevel).FirstOrDefault()?.Name,
                ["bait"] = Game1.player.Items.OfType<SObject>().Where(o => o.Category == SObject.baitCategory).Sum(o => o.Stack)
                           + Game1.player.Items.OfType<StardewValley.Tools.FishingRod>().Sum(r => r.attachments.Count > 0 && r.attachments[0] != null ? r.attachments[0].Stack : 0),
                ["upgrading"] = Game1.player.toolBeingUpgraded.Value == null ? null : new Dictionary<string, object>
                {
                    ["tool"] = Game1.player.toolBeingUpgraded.Value is StardewValley.Tools.Axe ? "axe" : Game1.player.toolBeingUpgraded.Value is StardewValley.Tools.Pickaxe ? "pickaxe"
                        : Game1.player.toolBeingUpgraded.Value is StardewValley.Tools.Hoe ? "hoe" : "watering_can",
                    ["level"] = Game1.player.toolBeingUpgraded.Value.UpgradeLevel,
                    ["days_left"] = Game1.player.daysLeftForToolUpgrade.Value
                }
            };
        }

        private static IEnumerable<GameLocation> Machines_Locations()
        {
            yield return Game1.getFarm();
            if (Utility.getHomeOfFarmer(Game1.player) is { } home)
                yield return home;
        }
    }
}
