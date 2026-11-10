using System;

namespace StardewAutoPilot
{
    /// <summary>What the player is inside. A stuck Temp map is not a festival and not a reason to restart.</summary>
    internal static class Presence
    {
        public const int StuckTicks = 45;

        public static string Classify(bool eventUp, bool festivalEvent, bool warping, string location, string menu, int tempAge)
        {
            if (menu is "DialogueBox" or "dialogue" or "question")
                return "waiting_dialogue";
            if (warping)
                return "temporary_map";
            if (eventUp && festivalEvent)
                return "legal_festival";
            if (string.Equals(location, "Temp", StringComparison.OrdinalIgnoreCase) && eventUp && tempAge >= StuckTicks)
                return "stuck";
            if (string.Equals(location, "Temp", StringComparison.OrdinalIgnoreCase))
                return "temporary_map";
            if (eventUp)
                return "legal_cutscene";
            return "playing";
        }

        public static bool ShouldWarpHome(string kind) => kind == "stuck";
    }
}
