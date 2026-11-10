using System.Collections.Generic;

namespace StardewAutoPilot
{
    /// <summary>Junimo scroll visibility. Matches CommunityCenter.shouldNoteAppearInArea.</summary>
    internal static class BundleLock
    {
        public static bool ScrollUnlocked(int area, int completeBundles, bool jojaSeen)
        {
            if (area == 1)
                return true;
            if (area == 0 || area == 2)
                return completeBundles > 0;
            if (area == 3)
                return completeBundles > 1;
            if (area == 5)
                return completeBundles > 2;
            if (area == 4)
                return completeBundles > 3;
            if (area == 6)
                return jojaSeen;
            return false;
        }

        public static string Missing(int area, int completeBundles)
        {
            if (area == 6)
                return "see the abandoned Joja Mart event before that scroll appears";
            int need = area == 0 || area == 2 ? 1 : area == 3 ? 2 : area == 5 ? 3 : area == 4 ? 4 : 0;
            if (need == 0)
                return "";
            return $"complete {need} other bundle(s) first (now {completeBundles})";
        }

        public static Dictionary<string, object> Locked(string bundle, string areaName, int area, int completeBundles, string heldItem, string nextGoal)
        {
            string missing = Missing(area, completeBundles);
            return new Dictionary<string, object>
            {
                ["reason_code"] = "BUNDLE_LOCKED",
                ["bundle"] = bundle,
                ["area"] = areaName,
                ["unlock"] = "locked",
                ["holds_item"] = true,
                ["item_belongs"] = true,
                ["area_enterable"] = true,
                ["missing"] = missing,
                ["next_goal"] = nextGoal ?? "",
                ["message"] = bundle + " scroll is locked (" + missing + "). " + heldItem
                    + " stays in the backpack. Next visible bundle: " + (nextGoal ?? "") + "."
            };
        }
    }
}
