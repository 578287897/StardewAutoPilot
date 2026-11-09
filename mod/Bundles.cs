using System;
using System.Collections.Generic;
using System.Linq;
using StardewValley;
using StardewValley.Locations;
using StardewValley.Objects;
using StardewValley.Quests;

namespace StardewAutoPilot
{
    /// <summary>Community Center bundles, read from the world state (what's needed, what's done, what we already own).</summary>
    internal static class Bundles
    {
        public static bool CanDonate => Game1.player.hasOrWillReceiveMail("canReadJunimoText") && !Game1.player.mailReceived.Contains("JojaMember");

        /// <summary>Where the player is in the Community Center unlock chain, as a hint for the agent.</summary>
        public static string Stage()
        {
            var p = Game1.player;
            if (p.mailReceived.Contains("JojaMember"))
                return "joja: the player joined Joja, bundles are not used";
            if (p.hasCompletedCommunityCenter())
                return "complete: all bundles done";
            if (CanDonate)
                return "donate: can donate items at the Community Center (donate action)";
            if (p.hasOrWillReceiveMail("wizardJunimoNote"))
                return "visit_wizard: read the Wizard's letter; go to WizardHouse (south-west of Forest) to learn the Junimo language";
            if (p.eventsSeen.Contains("611439"))
                return "wait_letter: saw the Junimos; the Wizard will send a letter soon";
            return "enter_cc: walk into the Community Center (north of Town square, open after Spring 5) to start the bundles";
        }

        /// <summary>The one community-center step the live mail, event, and quest log are asking for.</summary>
        public static Dictionary<string, object> CurrentTarget()
        {
            var player = Game1.player;
            if (player.mailReceived.Contains("JojaMember") || player.hasCompletedCommunityCenter())
                return null;
            foreach (var quest in player.questLog)
            {
                if (quest.completed.Value || quest is not GoSomewhereQuest somewhere || string.IsNullOrEmpty(somewhere.whereToGo.Value))
                    continue;
                if (somewhere.whereToGo.Value is "WizardHouse" or "CommunityCenter")
                    return Target(quest.GetName(), somewhere.whereToGo.Value, "quest:" + quest.id.Value);
            }
            if (CanDonate)
                return null;
            // Event 611439 only unlocks the door and adds quest 26. It does not send
            // wizardJunimoNote. The letter is referenced by JunimoNoteMenu.setUpMenu,
            // which runs when a bundle note is opened. Don't swallow that step.
            if (player.eventsSeen.Contains("611439") && !player.hasOrWillReceiveMail("wizardJunimoNote"))
            {
                var step = Target("打开社区中心的祝尼魔卷轴", "CommunityCenter", "event:611439");
                ((List<Dictionary<string, object>>)step["step"]).Add(new Dictionary<string, object> { ["type"] = "donate" });
                return step;
            }
            if (player.hasOrWillReceiveMail("wizardJunimoNote"))
            {
                if (LocationQuest("WizardHouse", out string title, out string where))
                    return Target(title, where, "mail:wizardJunimoNote");
                return Target("Meet the Wizard", "WizardHouse", "mail:wizardJunimoNote");
            }
            if (Game1.getLocationFromName("CommunityCenter") != null)
                return Target("进入社区中心", "CommunityCenter", "not_started");
            return null;
        }

        private static bool LocationQuest(string location, out string title, out string where)
        {
            title = null;
            where = null;
            foreach (var pair in DataLoader.Quests(Game1.content))
            {
                string[] fields = pair.Value.Split('/');
                if (fields.Length < 5 || fields[0] != "Location")
                    continue;
                string candidate = fields[4].Split(' ')[0];
                if (candidate != location || Game1.getLocationFromName(candidate) == null)
                    continue;
                title = fields[1];
                where = candidate;
                return true;
            }
            return false;
        }

        private static Dictionary<string, object> Target(string name, string location, string source)
        {
            return new Dictionary<string, object>
            {
                ["name"] = name,
                ["step"] = new List<Dictionary<string, object>>
                {
                    new() { ["type"] = "goto_location", ["location"] = location }
                },
                ["advances"] = new List<string> { "goto_location" },
                ["at"] = "start",
                ["source"] = source
            };
        }

        private static int CountOwned(string qualifiedId, int quality)
        {
            int count = 0;
            var sources = Game1.player.Items.Concat(Crafting.FarmChests().SelectMany(c => c.Items));
            foreach (var item in sources)
                if (item is StardewValley.Object o && o.QualifiedItemId == qualifiedId && o.Quality >= quality)
                    count += o.Stack;
            return count;
        }

        public static Dictionary<string, object> Status()
        {
            var result = new Dictionary<string, object> { ["stage"] = Stage(), ["current_target"] = CurrentTarget() };
            var cc = Game1.getLocationFromName("CommunityCenter") as CommunityCenter;
            if (cc == null)
                return result;
            var done = cc.bundlesDict();
            var areas = new Dictionary<string, List<Dictionary<string, object>>>();
            foreach (var pair in Game1.netWorldState.Value.BundleData)
            {
                // key: "Pantry/0", value: name/reward/items(id count quality ...)/color/slots/texture/label
                string[] key = pair.Key.Split('/');
                string areaName = key[0];
                int index = Convert.ToInt32(key[1]);
                string[] f = pair.Value.Split('/');
                string[] items = ArgUtility.SplitBySpace(f[2]);
                bool[] completed = done.TryGetValue(index, out var c) ? c : new bool[items.Length / 3];
                int slots = f.Length > 4 && int.TryParse(f[4], out int s) && s > 0 ? s : items.Length / 3;
                int filled = completed.Take(items.Length / 3).Count(x => x);
                var needs = new List<object>();
                for (int i = 0; i + 2 < items.Length; i += 3)
                {
                    if (completed.Length > i / 3 && completed[i / 3])
                        continue;
                    string id = items[i];
                    int count = Convert.ToInt32(items[i + 1]), quality = Convert.ToInt32(items[i + 2]);
                    if (id == "-1")
                    {
                        needs.Add(new { item = $"{count}g", count, quality, owned = Game1.player.Money });
                        continue;
                    }
                    string qid = ItemRegistry.QualifyItemId(id) ?? id;
                    needs.Add(new { item = ItemRegistry.GetDataOrErrorItem(qid).DisplayName, count, quality, owned = CountOwned(qid, quality) });
                }
                var bundle = new Dictionary<string, object>
                {
                    ["index"] = index,
                    ["name"] = f.Length > 6 && !string.IsNullOrEmpty(f[6]) ? f[6] : f[0],
                    ["complete"] = filled >= slots,
                    ["slots"] = $"{Math.Min(filled, slots)}/{slots}",
                    ["reward"] = f[1],
                    ["still_needed"] = filled >= slots ? new List<object>() : needs
                };
                if (!areas.TryGetValue(areaName, out var list))
                    areas[areaName] = list = new List<Dictionary<string, object>>();
                list.Add(bundle);
            }
            result["areas"] = areas.Select(a => new Dictionary<string, object>
            {
                ["area"] = a.Key,
                ["complete"] = cc.areasComplete.Count > CommunityCenter.getAreaNumberFromName(a.Key) && CommunityCenter.getAreaNumberFromName(a.Key) >= 0 && cc.areasComplete[CommunityCenter.getAreaNumberFromName(a.Key)],
                ["bundles"] = a.Value
            }).ToList();
            return result;
        }
    }
}
