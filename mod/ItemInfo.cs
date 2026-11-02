using System;
using System.Collections.Generic;
using System.Linq;
using StardewValley;
using SObject = StardewValley.Object;

namespace StardewAutoPilot
{
    /// <summary>Item knowledge read from the game's own data tables (descriptions, prices, food values, crop growth).</summary>
    internal static class ItemInfo
    {
        public static Dictionary<string, object> Describe(string qualifiedId, int? buyPrice = null)
        {
            var data = ItemRegistry.GetData(qualifiedId);
            if (data == null)
                return new Dictionary<string, object> { ["id"] = qualifiedId, ["error"] = "unknown item" };

            var info = new Dictionary<string, object>
            {
                ["id"] = data.QualifiedItemId,
                ["name"] = data.DisplayName,
                ["description"] = data.Description?.Replace("\n", " ").Replace("^", " "),
                ["category"] = ItemRegistry.Create(qualifiedId).getCategoryName()
            };

            if (ItemRegistry.Create(qualifiedId) is SObject obj)
            {
                info["sell_price"] = obj.sellToStorePrice();
                if (obj.Edibility > 0)
                {
                    info["energy"] = (int)Math.Ceiling(obj.Edibility * 2.5);
                    info["health"] = (int)(obj.Edibility * 1.125);
                }
            }

            if (Game1.cropData.TryGetValue(data.ItemId, out var crop))
            {
                int days = crop.DaysInPhase.Sum();
                var harvest = ItemRegistry.Create(crop.HarvestItemId) as SObject;
                int harvestPrice = harvest?.sellToStorePrice() ?? 0;
                info["crop"] = new Dictionary<string, object>
                {
                    ["seasons"] = crop.Seasons.Select(s => s.ToString()).ToList(),
                    ["days_to_grow"] = days,
                    ["regrow_days"] = crop.RegrowDays > 0 ? crop.RegrowDays : null,
                    ["harvest"] = harvest?.DisplayName,
                    ["harvest_sell_price"] = harvestPrice,
                    ["needs_trellis"] = crop.IsRaised ? true : null
                };
                if (buyPrice is > 0 && days > 0)
                    info["profit_per_day_first_harvest"] = Math.Round((harvestPrice - buyPrice.Value) / (double)days, 1);
            }
            return info;
        }
    }
}
