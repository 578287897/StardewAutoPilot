using System;
using System.Collections.Generic;
using System.Linq;

namespace StardewAutoPilot
{
    /// <summary>Scene facts the mod fills from the live world. The selection below does not read the game.</summary>
    internal sealed class SceneFacts
    {
        public bool WorldReady;
        public string Menu = "none";
        public bool Cutscene;
        public bool Festival;
        public bool CanFish;
        public bool InMine;
        public bool OnFarm;
        public bool CanDonate;
        public bool HasKitchen;
        public int UnreadMail;
        public bool ShopCounter;
    }

    /// <summary>
    /// Pure readings of game data strings and scene flags.
    /// Prices, achievement catalogs, and festival display names are not stored here.
    /// </summary>
    internal static class QueryRules
    {
        public static Dictionary<string, object> Achievement(int id, string raw, bool completed)
        {
            string[] parts = (raw ?? "").Split('^');
            string Field(int index) => index < parts.Length ? parts[index] : null;
            int prerequisite = -1;
            int.TryParse(Field(3), out prerequisite);
            return new Dictionary<string, object>
            {
                ["id"] = id,
                ["name"] = Field(0),
                ["description"] = Field(1),
                ["show_before_earned"] = string.Equals(Field(2), "true", StringComparison.OrdinalIgnoreCase),
                ["prerequisite"] = prerequisite,
                ["hat"] = Field(4),
                ["completed"] = completed
            };
        }

        /// <summary>
        /// Activity comes from the festival asset, not its display name.
        /// LuauSoup is a tile action stored in the festival data. Flower Dance and the Fair
        /// are the asset ids Event.isSpecificFestival handles; those scripts have no separate token.
        /// </summary>
        public static string FestivalActivity(string festivalId, IEnumerable<string> dataValues)
        {
            if (dataValues != null)
            {
                foreach (string value in dataValues)
                {
                    if (!string.IsNullOrEmpty(value) && value.Contains("LuauSoup"))
                        return "soup";
                }
            }
            if (festivalId == "spring24")
                return "dance";
            if (festivalId == "fall16")
                return "grange";
            return "start";
        }

        public static List<string> AvailableTypes(SceneFacts scene)
        {
            var list = new List<string>();
            void Add(string type)
            {
                if (!list.Contains(type))
                    list.Add(type);
            }
            if (scene == null || !scene.WorldReady || scene.Cutscene)
                return list;
            switch (scene.Menu)
            {
                case "question":
                    Add("dialog_answer");
                    Add("dialog_advance");
                    Add("close_menu");
                    return list;
                case "shop":
                    Add("buy");
                    Add("close_menu");
                    Add("dialog_answer");
                    return list;
                case "profession":
                    Add("choose_profession");
                    Add("close_menu");
                    return list;
                case "other":
                    Add("menu_click");
                    Add("close_menu");
                    Add("dialog_advance");
                    return list;
            }
            if (scene.Festival)
            {
                Add("festival");
                Add("interact");
                Add("dialog_advance");
                Add("move_to");
                Add("wait");
                return list;
            }
            if (scene.InMine)
            {
                foreach (string type in new[] { "move_to", "use_tool", "interact", "select", "eat", "fight", "mine", "leave_mine", "wait" })
                    Add(type);
                return list;
            }
            foreach (string type in new[]
            {
                "move_to", "goto_location", "use_tool", "interact", "place", "select", "eat", "wait", "sleep",
                "craft", "store", "take", "build", "buy_animal", "buy_backpack", "buy_weapon",
                "upgrade_tool", "upgrade_house", "care_animals", "fight", "mine"
            })
                Add(type);
            if (scene.OnFarm)
            {
                foreach (string type in new[]
                {
                    "water_crops", "harvest_crops", "plant_seeds", "clear_debris", "forage",
                    "ship", "ship_produce", "load_machines", "collect_machines", "clear_area",
                    "lay_path"
                })
                    Add(type);
            }
            if (scene.CanFish)
                Add("fish");
            if (scene.CanDonate)
                Add("donate");
            if (scene.HasKitchen)
                Add("cook");
            if (scene.UnreadMail > 0)
                Add("check_mail");
            if (scene.ShopCounter)
                Add("open_shop");
            return list;
        }
    }
}
