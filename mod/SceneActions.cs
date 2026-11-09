using System.Collections.Generic;
using System.Linq;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Locations;
using StardewValley.Menus;

namespace StardewAutoPilot
{
    /// <summary>Actions the current scene can start. The catalog of primitives is ActionRunner.ActionTypes.</summary>
    internal static class SceneActions
    {
        public static Dictionary<string, object> Current()
        {
            if (!Context.IsWorldReady)
            {
                return new Dictionary<string, object>
                {
                    ["ok"] = false,
                    ["message"] = "world not ready",
                    ["primitives"] = ActionRunner.ActionTypes,
                    ["available"] = new List<string>()
                };
            }
            var loc = Game1.currentLocation;
            var ev = Game1.CurrentEvent;
            var facts = new SceneFacts
            {
                WorldReady = true,
                Menu = MenuKind(Game1.activeClickableMenu),
                Cutscene = Game1.eventUp && (ev == null || !ev.isFestival),
                Festival = ev != null && ev.isFestival,
                InMine = loc is MineShaft,
                OnFarm = loc is Farm || loc?.Name == "Greenhouse",
                CanDonate = Bundles.CanDonate,
                UnreadMail = Game1.mailbox.Count,
                CanFish = loc != null && loc.canFishHere(),
                HasKitchen = Utility.getHomeOfFarmer(Game1.player) is FarmHouse home && home.upgradeLevel >= 1,
                ShopCounter = loc != null && ShopLocations.ShopAt(loc.Name) != null && !GameData.LockedNow(loc.Name, out _)
            };
            var available = QueryRules.AvailableTypes(facts).Select(type =>
            {
                var row = new Dictionary<string, object> { ["type"] = type };
                if (type == "festival" && facts.Festival)
                    row["activity"] = FestivalActivity(ev);
                if (type == "open_shop" && loc != null)
                    row["shop_id"] = ShopLocations.ShopAt(loc.Name);
                return row;
            }).ToList();
            return new Dictionary<string, object>
            {
                ["ok"] = true,
                ["scene"] = new Dictionary<string, object>
                {
                    ["location"] = loc?.NameOrUniqueName,
                    ["menu"] = facts.Menu,
                    ["cutscene"] = facts.Cutscene,
                    ["festival"] = facts.Festival,
                    ["in_mine"] = facts.InMine,
                    ["time"] = Game1.timeOfDay
                },
                ["primitives"] = ActionRunner.ActionTypes,
                ["available"] = available
            };
        }

        private static string MenuKind(IClickableMenu menu)
        {
            if (menu == null)
                return "none";
            if (menu is DialogueBox { isQuestion: true })
                return "question";
            if (menu is ShopMenu)
                return "shop";
            if (menu is LevelUpMenu)
                return "profession";
            return "other";
        }

        private static string FestivalActivity(Event ev)
        {
            string id = ev?.id ?? "";
            const string prefix = "festival_";
            if (id.StartsWith(prefix))
                id = id.Substring(prefix.Length);
            if (Event.tryToLoadFestivalData(id, out _, out var data, out _, out _, out _))
                return QueryRules.FestivalActivity(id, data?.Values);
            return QueryRules.FestivalActivity(id, null);
        }
    }
}
