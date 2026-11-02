using System;
using System.Collections.Generic;
using System.Linq;
using StardewValley;
using StardewValley.Locations;
using StardewValley.Objects;

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
            var result = new Dictionary<string, object> { ["stage"] = Stage() };
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
