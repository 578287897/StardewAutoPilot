using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using StardewValley;
using StardewValley.GameData.Objects;
using StardewValley.Network;
using StardewValley.GameData.SpecialOrders;
using StardewValley.GameData.Tools;
using StardewValley.Internal;
using StardewValley.Quests;
using StardewValley.SpecialOrders;
using StardewValley.Tools;

namespace StardewAutoPilot
{
    /// <summary>
    /// Achievements, collections, quests, special orders, and the tool upgrade ladder.
    /// Catalogs come from the loaded game data. Completion comes from the current player.
    /// Nothing here is a handwritten list of goals, prices, or a fixed max tier.
    /// </summary>
    internal static class Completion
    {
        public static Dictionary<string, object> Achievements()
        {
            var data = DataLoader.Achievements(Game1.content);
            var earned = new HashSet<int>(Game1.player.achievements);
            var entries = data.OrderBy(pair => pair.Key)
                .Select(pair => QueryRules.Achievement(pair.Key, pair.Value, earned.Contains(pair.Key)))
                .ToList();
            return new Dictionary<string, object>
            {
                ["ok"] = true,
                ["source"] = "Data/Achievements",
                ["completed"] = entries.Count(entry => (bool)entry["completed"]),
                ["total"] = entries.Count,
                ["entries"] = entries
            };
        }

        public static Dictionary<string, object> Collections()
        {
            var shipping = new List<Dictionary<string, object>>();
            var fish = new List<Dictionary<string, object>>();
            var artifacts = new List<Dictionary<string, object>>();
            var minerals = new List<Dictionary<string, object>>();
            var cooking = new List<Dictionary<string, object>>();
            var donated = MuseumDonated();
            foreach (string rawId in ItemRegistry.GetObjectTypeDefinition().GetAllIds())
            {
                var data = ItemRegistry.GetData(rawId);
                if (data == null)
                    continue;
                string id = data.ItemId;
                string type = data.ObjectType ?? "";
                var raw = data.RawData as ObjectData;
                if (type == "Arch")
                {
                    int count = ArrayCount(Game1.player.archaeologyFound, id);
                    artifacts.Add(ItemRow(data, count > 0, count, donated.Contains(id)));
                    continue;
                }
                if (type == "Fish")
                {
                    if (raw != null && raw.ExcludeFromFishingCollection)
                        continue;
                    int count = ArrayCount(Game1.player.fishCaught, data.QualifiedItemId);
                    int longest = ArrayField(Game1.player.fishCaught, data.QualifiedItemId, 1);
                    var row = ItemRow(data, count > 0, count, false);
                    row["longest"] = longest;
                    fish.Add(row);
                    continue;
                }
                if (type == "Minerals" || data.Category == -2)
                {
                    int count = DictCount(Game1.player.mineralsFound, id);
                    minerals.Add(ItemRow(data, count > 0, count, donated.Contains(id)));
                    continue;
                }
                if (type == "Cooking" || data.Category == -7)
                {
                    // Same ids the collections page skips; they are not a goal list.
                    if (id is "217" or "772" or "773" or "279" or "873")
                        continue;
                    int cooked = DictCount(Game1.player.recipesCooked, id);
                    string recipeName = CookingRecipeName(data.InternalName);
                    bool known = Game1.player.cookingRecipes.ContainsKey(recipeName);
                    var row = ItemRow(data, cooked > 0, cooked, false);
                    row["recipe_known"] = known;
                    cooking.Add(row);
                    continue;
                }
                if (!StardewValley.Object.isPotentialBasicShipped(id, data.Category, type))
                    continue;
                int shipped = DictCount(Game1.player.basicShipped, id);
                shipping.Add(ItemRow(data, shipped > 0, shipped, false));
            }
            var crafting = new List<Dictionary<string, object>>();
            foreach (var pair in DataLoader.CraftingRecipes(Game1.content).OrderBy(pair => pair.Key))
            {
                int times = Game1.player.craftingRecipes.ContainsKey(pair.Key) ? Game1.player.craftingRecipes[pair.Key] : 0;
                crafting.Add(new Dictionary<string, object>
                {
                    ["id"] = pair.Key,
                    ["name"] = pair.Key,
                    ["known"] = times > 0 || Game1.player.craftingRecipes.ContainsKey(pair.Key),
                    ["times_crafted"] = times,
                    ["definition"] = pair.Value
                });
            }
            return new Dictionary<string, object>
            {
                ["ok"] = true,
                ["source"] = "Data/Objects + Data/CraftingRecipes",
                ["shipping"] = Group(shipping),
                ["fish"] = Group(fish),
                ["artifacts"] = Group(artifacts),
                ["minerals"] = Group(minerals),
                ["cooking"] = Group(cooking),
                ["crafting"] = Group(crafting, "known"),
                ["museum"] = new Dictionary<string, object>
                {
                    ["donated"] = donated.Count,
                    ["catalog"] = artifacts.Count + minerals.Count,
                    ["missing"] = artifacts.Concat(minerals).Where(row => !(bool)row["donated"]).Select(row => row["id"]).ToList()
                }
            };
        }

        public static Dictionary<string, object> Quests()
        {
            var log = Game1.player.questLog.Where(quest => quest?.id.Value != null).ToDictionary(quest => quest.id.Value);
            var entries = new List<Dictionary<string, object>>();
            foreach (var pair in DataLoader.Quests(Game1.content).OrderBy(pair => pair.Key))
            {
                string[] fields = pair.Value.Split('/');
                string Field(int index) => index < fields.Length ? fields[index] : null;
                log.TryGetValue(pair.Key, out var live);
                var entry = new Dictionary<string, object>
                {
                    ["id"] = pair.Key,
                    ["type"] = Field(0),
                    ["title"] = Field(1),
                    ["description"] = Field(2),
                    ["objective"] = Field(3),
                    ["requirement"] = Field(4),
                    ["next"] = Field(5),
                    ["money"] = Field(6),
                    ["cancellable"] = Field(8),
                    ["in_log"] = live != null,
                    ["log_completed"] = live != null && live.completed.Value
                };
                if (live != null)
                {
                    entry["days_left"] = live.IsTimedQuest() ? live.GetDaysLeft() : null;
                    entry["current_objective"] = live.currentObjective;
                    entry["objectives"] = live.GetObjectiveDescriptions().ToList();
                    entry["completion_string"] = live.obsolete_completionString;
                    if (live is GoSomewhereQuest somewhere)
                        entry["where"] = somewhere.whereToGo.Value;
                }
                entries.Add(entry);
            }
            return new Dictionary<string, object>
            {
                ["ok"] = true,
                ["source"] = "Data/Quests",
                ["note"] = "The game removes a finished quest from the log and does not keep a completed-id list. in_log and log_completed are the live quest log only.",
                ["billboard_done"] = Game1.stats.Get("BillboardQuestsDone"),
                ["active"] = entries.Count(entry => (bool)entry["in_log"] && !(bool)entry["log_completed"]),
                ["entries"] = entries
            };
        }

        public static Dictionary<string, object> SpecialOrders()
        {
            var team = Game1.player.team;
            var completed = new HashSet<string>(team.completedSpecialOrders);
            var active = team.specialOrders.Where(order => order?.questKey.Value != null).ToDictionary(order => order.questKey.Value);
            var available = new HashSet<string>(team.availableSpecialOrders.Select(order => order.questKey.Value).Where(id => id != null));
            var entries = new List<Dictionary<string, object>>();
            foreach (var pair in DataLoader.SpecialOrders(Game1.content).OrderBy(pair => pair.Key))
            {
                SpecialOrderData data = pair.Value;
                active.TryGetValue(pair.Key, out var live);
                string state = completed.Contains(pair.Key) ? "completed"
                    : live != null ? "active"
                    : available.Contains(pair.Key) ? "available"
                    : "inactive";
                var entry = new Dictionary<string, object>
                {
                    ["id"] = pair.Key,
                    ["name"] = OrderText(data.Name),
                    ["requester"] = data.Requester,
                    ["duration"] = data.Duration.ToString(),
                    ["repeatable"] = data.Repeatable,
                    ["order_type"] = data.OrderType,
                    ["text"] = OrderText(data.Text),
                    ["state"] = state,
                    ["objectives"] = (data.Objectives ?? new List<SpecialOrderObjectiveData>()).Select(objective => new Dictionary<string, object>
                    {
                        ["type"] = objective.Type,
                        ["text"] = OrderText(objective.Text),
                        ["required_count"] = objective.RequiredCount
                    }).ToList(),
                    ["rewards"] = (data.Rewards ?? new List<SpecialOrderRewardData>()).Select(reward => reward.Type).ToList()
                };
                if (live != null)
                {
                    entry["quest_state"] = live.questState.Value.ToString();
                    entry["days_left"] = live.GetDaysLeft();
                    entry["progress"] = live.objectives.Select(objective => new Dictionary<string, object>
                    {
                        ["text"] = objective.GetDescription(),
                        ["count"] = objective.GetCount(),
                        ["max"] = objective.GetMaxCount(),
                        ["complete"] = objective.IsComplete()
                    }).ToList();
                }
                entries.Add(entry);
            }
            return new Dictionary<string, object>
            {
                ["ok"] = true,
                ["source"] = "Data/SpecialOrders",
                ["completed"] = entries.Count(entry => (string)entry["state"] == "completed"),
                ["active"] = entries.Count(entry => (string)entry["state"] == "active"),
                ["total"] = entries.Count,
                ["entries"] = entries
            };
        }

        public static Dictionary<string, object> ToolLadder()
        {
            var tools = Game1.toolData ?? DataLoader.Tools(Game1.content);
            int? conventionalAmount = null;
            var groups = new Dictionary<string, Dictionary<string, object>>();
            foreach (var pair in tools)
            {
                ToolData data = pair.Value;
                if (data == null || string.IsNullOrEmpty(data.ClassName))
                    continue;
                if (string.IsNullOrEmpty(data.ConventionalUpgradeFrom) && (data.UpgradeFrom == null || data.UpgradeFrom.Count == 0))
                    continue;
                string key = ToolKey(data.ClassName);
                if (!groups.TryGetValue(key, out var group))
                {
                    int level = HeldLevel(data.ClassName);
                    groups[key] = group = new Dictionary<string, object>
                    {
                        ["key"] = key,
                        ["class_name"] = data.ClassName,
                        ["held"] = level >= 0,
                        ["current_level"] = Math.Max(level, 0),
                        ["tiers"] = new List<Dictionary<string, object>>()
                    };
                }
                var tiers = (List<Dictionary<string, object>>)group["tiers"];
                var resolved = ShopBuilder.GetToolUpgradeData(data, Game1.player);
                if (resolved != null && data.ConventionalUpgradeFrom != null && resolved.RequireToolId == data.ConventionalUpgradeFrom)
                    conventionalAmount = resolved.TradeItemAmount;
                var requirements = Requirements(data, resolved).ToList();
                if (requirements.Count == 0)
                    continue;
                var first = requirements[0];
                var item = ItemRegistry.GetData("(T)" + pair.Key);
                tiers.Add(new Dictionary<string, object>
                {
                    ["item_id"] = pair.Key,
                    ["level"] = data.UpgradeLevel,
                    ["display_name"] = item?.DisplayName ?? data.DisplayName ?? pair.Key,
                    ["price"] = first["price"],
                    ["trade_item_id"] = first["trade_item_id"],
                    ["trade_item_name"] = first["trade_item_name"],
                    ["trade_item_display"] = first["trade_item_display"],
                    ["trade_item_amount"] = first["trade_item_amount"],
                    ["amount_source"] = first["amount_source"],
                    ["owned"] = first["owned"],
                    ["available_now"] = resolved != null,
                    ["requirements"] = requirements
                });
            }
            if (conventionalAmount != null)
            {
                foreach (var group in groups.Values)
                {
                    foreach (var tier in (List<Dictionary<string, object>>)group["tiers"])
                    {
                        if (tier["trade_item_amount"] == null && (string)tier["amount_source"] == "conventional_unresolved")
                        {
                            tier["trade_item_amount"] = conventionalAmount.Value;
                            tier["amount_source"] = "game_conventional";
                        }
                    }
                }
            }
            foreach (var group in groups.Values)
            {
                var tiers = (List<Dictionary<string, object>>)group["tiers"];
                tiers.Sort((a, b) => ((int)a["level"]).CompareTo((int)b["level"]));
                group["max_level"] = tiers.Count == 0 ? 0 : tiers.Max(tier => (int)tier["level"]);
            }
            var upgrading = Game1.player.toolBeingUpgraded.Value;
            return new Dictionary<string, object>
            {
                ["ok"] = true,
                ["source"] = "Data/Tools",
                ["money"] = Game1.player.Money,
                ["upgrading"] = upgrading == null ? null : new Dictionary<string, object>
                {
                    ["tool"] = ToolKey(upgrading.GetToolData()?.ClassName),
                    ["name"] = upgrading.DisplayName,
                    ["level"] = upgrading.UpgradeLevel,
                    ["days_left"] = Game1.player.daysLeftForToolUpgrade.Value
                },
                ["tools"] = groups.Values.OrderBy(group => (string)group["key"]).ToList()
            };
        }

        private static IEnumerable<Dictionary<string, object>> Requirements(ToolData data, ToolUpgradeData resolved)
        {
            if (!string.IsNullOrEmpty(data.ConventionalUpgradeFrom))
            {
                string tradeId = ConventionalTradeItem(data.UpgradeLevel);
                int? amount = resolved != null && resolved.RequireToolId == data.ConventionalUpgradeFrom ? resolved.TradeItemAmount : null;
                yield return Requirement(data.ConventionalUpgradeFrom, ShopBuilder.GetToolUpgradeConventionalPrice(data.UpgradeLevel), tradeId, amount,
                    amount == null ? "conventional_unresolved" : "game");
            }
            if (data.UpgradeFrom == null)
                yield break;
            foreach (var row in data.UpgradeFrom)
            {
                int price = row.Price >= 0 ? row.Price : data.SalePrice;
                yield return Requirement(row.RequireToolId, price, row.TradeItemId, row.TradeItemAmount, "upgrade_from");
            }
        }

        private static Dictionary<string, object> Requirement(string requireToolId, int price, string tradeId, int? amount, string amountSource)
        {
            TradeNames(tradeId, out string internalName, out string display);
            return new Dictionary<string, object>
            {
                ["require_tool_id"] = requireToolId,
                ["price"] = price,
                ["trade_item_id"] = tradeId,
                ["trade_item_name"] = internalName,
                ["trade_item_display"] = display,
                ["trade_item_amount"] = amount,
                ["amount_source"] = amountSource,
                ["owned"] = string.IsNullOrEmpty(tradeId) ? 0 : CountOwned(tradeId)
            };
        }

        private static string ConventionalTradeItem(int level)
        {
            MethodInfo method = typeof(ShopBuilder).GetMethod("GetToolUpgradeConventionalTradeItem", BindingFlags.NonPublic | BindingFlags.Static);
            return method?.Invoke(null, new object[] { level }) as string;
        }

        private static void TradeNames(string id, out string internalName, out string display)
        {
            internalName = null;
            display = null;
            if (string.IsNullOrEmpty(id))
                return;
            string qualified = ItemRegistry.QualifyItemId(id) ?? id;
            var data = ItemRegistry.GetData(qualified);
            if (data == null)
                return;
            internalName = data.InternalName;
            display = data.DisplayName;
        }

        private static int CountOwned(string id)
        {
            string qualified = ItemRegistry.QualifyItemId(id) ?? id;
            int count = Game1.player.Items.CountId(qualified);
            foreach (var chest in Crafting.FarmChests())
                count += chest.Items.CountId(qualified);
            return count;
        }

        private static int HeldLevel(string className)
        {
            int level = -1;
            foreach (var tool in Game1.player.Items.OfType<Tool>())
            {
                if (tool.GetToolData()?.ClassName == className)
                    level = Math.Max(level, tool.UpgradeLevel);
            }
            return level;
        }

        private static string ToolKey(string className)
        {
            if (string.IsNullOrEmpty(className))
                return null;
            var chars = new System.Text.StringBuilder();
            foreach (char c in className)
            {
                if (char.IsUpper(c) && chars.Length > 0)
                    chars.Append('_');
                chars.Append(char.ToLowerInvariant(c));
            }
            return chars.ToString();
        }

        private static Dictionary<string, object> ItemRow(StardewValley.ItemTypeDefinitions.ParsedItemData data, bool done, int count, bool donated)
        {
            return new Dictionary<string, object>
            {
                ["id"] = data.ItemId,
                ["name"] = data.DisplayName,
                ["internal_name"] = data.InternalName,
                ["done"] = done,
                ["count"] = count,
                ["donated"] = donated
            };
        }

        private static Dictionary<string, object> Group(List<Dictionary<string, object>> items, string doneField = "done")
        {
            return new Dictionary<string, object>
            {
                ["total"] = items.Count,
                ["completed"] = items.Count(item => item.TryGetValue(doneField, out var flag) && flag is true),
                ["items"] = items
            };
        }

        private static HashSet<string> MuseumDonated()
        {
            var donated = new HashSet<string>();
            var pieces = Game1.netWorldState.Value.MuseumPieces;
            if (pieces == null)
                return donated;
            foreach (string itemId in pieces.Values)
            {
                if (!string.IsNullOrEmpty(itemId))
                    donated.Add(itemId);
            }
            return donated;
        }

        private static int DictCount(NetStringDictionary<int, Netcode.NetInt> dict, string key)
        {
            if (dict == null || !dict.ContainsKey(key))
                return 0;
            return dict[key];
        }

        private static int ArrayCount(StardewValley.NetStringIntArrayDictionary dict, string key) => ArrayField(dict, key, 0);

        private static int ArrayField(StardewValley.NetStringIntArrayDictionary dict, string key, int index)
        {
            if (dict != null && dict.TryGetValue(key, out int[] fields) && fields != null && fields.Length > index)
                return fields[index];
            return 0;
        }

        /// <summary>Collections page still looks recipes up under the 1.5 display name for a few dishes.</summary>
        private static string CookingRecipeName(string name)
        {
            switch (name)
            {
                case "Cheese Cauli.": return "Cheese Cauliflower";
                case "Cheese Cauliflower": return "Cheese Cauli.";
                case "Vegetable Medley": return "Vegetable Stew";
                case "Cookie": return "Cookies";
                case "Eggplant Parmesan": return "Eggplant Parm.";
                case "Cranberry Sauce": return "Cran. Sauce";
                case "Dish O' The Sea": return "Dish o' The Sea";
                default: return name;
            }
        }

        private static string OrderText(string raw)
        {
            if (string.IsNullOrEmpty(raw) || raw.Length < 3 || raw[0] != '[' || raw[raw.Length - 1] != ']')
                return raw;
            string key = raw.Substring(1, raw.Length - 2);
            try
            {
                return Game1.content.LoadString("Strings\\SpecialOrderStrings:" + key);
            }
            catch (Exception)
            {
                return raw;
            }
        }
    }
}
