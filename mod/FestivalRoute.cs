using System;
using System.Collections.Generic;

namespace StardewAutoPilot
{
    /// <summary>Festival windows that replace a map. Pure data, so tests do not need the game.</summary>
    internal static class FestivalRoute
    {
        public readonly struct Window
        {
            public int InDays { get; init; }
            public string Name { get; init; }
            public string Location { get; init; }
            public int Start { get; init; }
            public int End { get; init; }
        }

        // These buildings are doors on the Town map. A Town festival removes that map.
        public static readonly string[] TownDoors =
        {
            "CommunityCenter", "Hospital", "SeedShop", "ArchaeologyHouse", "Blacksmith",
            "Saloon", "ManorHouse", "JoshHouse", "HaleyHouse", "SamHouse", "JojaMart"
        };

        public static List<Window> Windows(IEnumerable<Dictionary<string, object>> calendar)
        {
            var list = new List<Window>();
            if (calendar == null)
                return list;
            foreach (var entry in calendar)
            {
                list.Add(new Window
                {
                    InDays = Int(entry, "in_days", 99),
                    Name = Text(entry, "name"),
                    Location = Text(entry, "location"),
                    Start = Int(entry, "start", 0),
                    End = Int(entry, "end", 0)
                });
            }
            return list;
        }

        public static string Block(string destination, int time, IList<Window> windows)
        {
            if (string.IsNullOrEmpty(destination) || windows == null)
                return null;
            foreach (var festival in windows)
            {
                if (festival.InDays != 0 || string.IsNullOrEmpty(festival.Location))
                    continue;
                if (time < festival.Start || time >= festival.End)
                    continue;
                bool sameMap = destination.Equals(festival.Location, StringComparison.OrdinalIgnoreCase);
                bool townDoor = festival.Location.Equals("Town", StringComparison.OrdinalIgnoreCase)
                    && Array.Exists(TownDoors, door => door.Equals(destination, StringComparison.OrdinalIgnoreCase));
                if (!sameMap && !townDoor)
                    continue;
                return $"{festival.Name} occupies {festival.Location} from {festival.Start} until {festival.End}; {destination} has no door until that map returns";
            }
            return null;
        }

        /// <summary>Split a travel failure into a missing graph edge, a failed exit, or a festival map.</summary>
        public static string Explain(string message, string block)
        {
            if (!string.IsNullOrEmpty(block))
                return "festival_map_limit";
            if (string.IsNullOrEmpty(message))
                return "unknown";
            if (message.Contains("no reachable route", StringComparison.OrdinalIgnoreCase) && message.Contains("unreachable exits", StringComparison.OrdinalIgnoreCase))
                return "exit_failed";
            if (message.Contains("no reachable route", StringComparison.OrdinalIgnoreCase))
                return "real_unreachable";
            return "other";
        }

        private static string Text(Dictionary<string, object> entry, string key) =>
            entry != null && entry.TryGetValue(key, out var value) ? value?.ToString() ?? "" : "";

        private static int Int(Dictionary<string, object> entry, string key, int fallback)
        {
            if (entry == null || !entry.TryGetValue(key, out var value) || value == null)
                return fallback;
            return Convert.ToInt32(value);
        }
    }
}
