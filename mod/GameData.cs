using System;
using System.Collections.Generic;
using System.Linq;
using StardewValley;
using StardewValley.Internal;
using SObject = StardewValley.Object;

namespace StardewAutoPilot
{
    /// <summary>Planning facts read straight from the game's data: crops and prices, door hours, villager schedules and gift tastes.</summary>
    internal static class GameData
    {
        // ---------------- crops ----------------

        /// <summary>Every crop with a seed sold in Pierre's or Joja's shop: seasons, growth, regrowth, harvest price, seed price.</summary>
        public static List<Dictionary<string, object>> Crops()
        {
            var seedPrices = new Dictionary<string, (int price, string shop)>();
            foreach (string shop in new[] { "SeedShop", "Joja" })
            {
                try
                {
                    foreach (var kv in ShopBuilder.GetShopStock(shop))
                        if (kv.Key is Item item && kv.Value.TradeItem == null && (!seedPrices.TryGetValue(item.ItemId, out var have) || kv.Value.Price < have.price))
                            seedPrices[item.ItemId] = (kv.Value.Price, shop);
                }
                catch (Exception)
                {
                    // shop stock needs a loaded save
                }
            }
            var list = new List<Dictionary<string, object>>();
            // seeds Pierre sells in other seasons are not in today's stock: take them from the shop's data, at the game's sale price
            try
            {
                foreach (var entry in DataLoader.Shops(Game1.content)["SeedShop"].Items)
                {
                    string id = entry.ItemId?.Replace("(O)", "");
                    if (id != null && Game1.cropData.ContainsKey(id) && !seedPrices.ContainsKey(id))
                        seedPrices[id] = (entry.Price > 0 ? entry.Price : new SObject(id, 1).salePrice(), "SeedShop(当季才卖)");
                }
            }
            catch (Exception)
            {
                // shop data unavailable: today's stock only
            }
            foreach (var (seedId, crop) in Game1.cropData)
            {
                if (crop.HarvestItemId == null || !seedPrices.TryGetValue(seedId, out var seed))
                    continue;
                var harvest = new SObject(crop.HarvestItemId, 1);
                list.Add(new Dictionary<string, object>
                {
                    ["seed"] = ItemRegistry.GetDataOrErrorItem("(O)" + seedId).DisplayName,
                    ["seed_price"] = seed.price,
                    ["shop"] = seed.shop,
                    ["crop"] = harvest.DisplayName,
                    ["sell"] = harvest.sellToStorePrice(),
                    ["seasons"] = crop.Seasons.Select(s => s.ToString().ToLowerInvariant()).ToList(),
                    ["days"] = crop.DaysInPhase.Sum(),
                    ["regrow"] = crop.RegrowDays,
                    ["yield"] = (crop.HarvestMinStack + Math.Max(crop.HarvestMinStack, crop.HarvestMaxStack)) / 2.0 + crop.ExtraHarvestChance,
                    ["trellis"] = crop.IsRaised,
                    ["paddy"] = crop.IsPaddyCrop
                });
            }
            return list;
        }

        // ---------------- doors ----------------

        private static Dictionary<string, (int open, int close)> doorHours;

        /// <summary>Opening hours of buildings with a locked door (LockedDoorWarp map actions), by interior location name.</summary>
        public static Dictionary<string, (int open, int close)> DoorHours()
        {
            if (doorHours != null)
                return doorHours;
            var hours = new Dictionary<string, (int, int)>();
            foreach (string name in new[] { "Town", "Mountain", "Forest", "Beach", "BusStop", "Railroad", "Desert" })
            {
                var loc = Game1.getLocationFromName(name);
                var layer = loc?.Map?.GetLayer("Buildings");
                if (layer == null)
                    continue;
                for (int x = 0; x < layer.LayerWidth; x++)
                    for (int y = 0; y < layer.LayerHeight; y++)
                    {
                        string action = loc.doesTileHaveProperty(x, y, "Action", "Buildings");
                        if (action == null || !action.StartsWith("LockedDoorWarp"))
                            continue;
                        var parts = ArgUtility.SplitBySpace(action);
                        if (parts.Length >= 6 && int.TryParse(parts[4], out int open) && int.TryParse(parts[5], out int close))
                            hours[parts[3]] = (open, close);
                    }
            }
            return doorHours = hours;
        }

        /// <summary>True if the location is behind a door that is locked at this time of day.</summary>
        public static bool LockedNow(string location, out int opens)
        {
            opens = 0;
            if (!DoorHours().TryGetValue(location, out var h))
                return false;
            opens = h.open;
            return Game1.timeOfDay < h.open || Game1.timeOfDay >= h.close;
        }

        // ---------------- villagers ----------------

        /// <summary>Where a villager goes today (time -> location), from the game's schedule for today.</summary>
        public static List<string> ScheduleToday(NPC npc)
        {
            if (npc.Schedule == null)
                return new List<string>();
            return npc.Schedule.OrderBy(kv => kv.Key)
                .Select(kv => $"{kv.Key / 100}:{kv.Key % 100:00} {kv.Value.targetLocationName}")
                .ToList();
        }

        /// <summary>Loved and liked gifts from Data/NPCGiftTastes (specific items only, not whole categories).</summary>
        public static (List<string> loves, List<string> likes) GiftTastes(NPC npc)
        {
            var loves = new List<string>();
            var likes = new List<string>();
            if (Game1.NPCGiftTastes.TryGetValue(npc.Name, out string data))
            {
                var parts = data.Split('/');
                List<string> Names(int i) => parts.Length > i
                    ? ArgUtility.SplitBySpace(parts[i]).Where(id => !id.StartsWith("-"))
                        .Select(id => ItemRegistry.GetData(id)?.DisplayName).Where(n => n != null).Distinct().Take(8).ToList()
                    : new List<string>();
                loves = Names(1);
                likes = Names(3);
            }
            return (loves, likes);
        }
    }
}
