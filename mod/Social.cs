using System;
using System.Collections.Generic;
using System.Linq;
using StardewValley;

namespace StardewAutoPilot
{
    /// <summary>Friendship, gift tastes, birthdays and the festival calendar, read from the game's data.</summary>
    internal static class Social
    {
        private static readonly string[] TasteNames = { "love", "?", "like", "?", "dislike", "?", "hate", "?", "neutral" };

        public static string Taste(NPC npc, Item item)
        {
            try
            {
                int t = npc.getGiftTasteForThisItem(item);
                return t >= 0 && t < TasteNames.Length ? TasteNames[t] : "neutral";
            }
            catch { return "neutral"; }
        }

        /// <summary>One villager: hearts, today's talk/gift status, birthday and the best gifts in the backpack.</summary>
        public static Dictionary<string, object> Describe(NPC npc)
        {
            var p = Game1.player;
            p.friendshipData.TryGetValue(npc.Name, out var f);
            var info = new Dictionary<string, object>
            {
                ["name"] = npc.Name,
                ["hearts"] = f == null ? 0 : f.Points / 250,
                ["points"] = f?.Points ?? 0,
                ["met"] = f != null,
                ["talked_today"] = f?.TalkedToToday ?? false,
                ["gifts_this_week"] = f?.GiftsThisWeek ?? 0,
                ["gifted_today"] = (f?.GiftsToday ?? 0) > 0,
                ["birthday"] = npc.Birthday_Season != null ? $"{npc.Birthday_Season} {npc.Birthday_Day}" : null,
                ["birthday_today"] = npc.isBirthday()
            };
            string where = npc.currentLocation?.NameOrUniqueName;
            info["location"] = where;
            if (where != null && GameData.LockedNow(where, out int opens))
                info["locked_until"] = $"{opens / 100}:{opens % 100:00}";
            var schedule = GameData.ScheduleToday(npc);
            if (schedule.Count > 0)
                info["schedule_today"] = schedule;
            if (npc.CanReceiveGifts())
            {
                var gifts = p.Items.Where(i => i != null && i is not Tool && i.canBeGivenAsGift())
                    .Select(i => (item: i, taste: Taste(npc, i)))
                    .Where(g => g.taste is "love" or "like")
                    .OrderBy(g => g.taste == "love" ? 0 : 1)
                    .Select(g => $"{g.item.DisplayName}({g.taste})")
                    .Distinct()
                    .Take(5)
                    .ToList();
                if (gifts.Count > 0)
                    info["good_gifts_in_backpack"] = gifts;
                var (loves, likes) = GameData.GiftTastes(npc);
                info["loves"] = loves;
                info["likes"] = likes;
            }
            return info;
        }

        /// <summary>Villagers in the current location plus everyone the player has met.</summary>
        public static Dictionary<string, object> Overview()
        {
            var here = Game1.currentLocation.characters.Where(c => c.IsVillager && c.CanSocialize).Select(Describe).ToList();
            var met = new List<Dictionary<string, object>>();
            foreach (string name in Game1.player.friendshipData.Keys)
            {
                var npc = Game1.getCharacterFromName(name);
                if (npc != null)
                    met.Add(Describe(npc));
            }
            return new Dictionary<string, object>
            {
                ["here"] = here,
                ["met"] = met.OrderByDescending(m => (int)m["points"]).ToList(),
                ["birthdays_today"] = Utility.getAllVillagers().Where(n => n.isBirthday()).Select(n => n.Name).ToList()
            };
        }

        /// <summary>Festivals in the next <paramref name="days"/> days (today included).</summary>
        public static List<Dictionary<string, object>> Calendar(int days = 7)
        {
            var list = new List<Dictionary<string, object>>();
            var dates = DataLoader.Festivals_FestivalDates(Game1.temporaryContent);
            Season season = Game1.season;
            int day = Game1.dayOfMonth;
            for (int i = 0; i < days; i++)
            {
                string key = $"{Utility.getSeasonKey(season)}{day}";
                if (dates.TryGetValue(key, out string name))
                {
                    var entry = new Dictionary<string, object> { ["in_days"] = i, ["name"] = name, ["season"] = Utility.getSeasonKey(season), ["day"] = day };
                    if (Event.tryToLoadFestivalData(key, out _, out _, out string location, out int start, out int end))
                    {
                        entry["location"] = location;
                        entry["start"] = start;
                        entry["end"] = end;
                    }
                    list.Add(entry);
                }
                if (++day > 28)
                {
                    day = 1;
                    season = (Season)(((int)season + 1) % 4);
                }
            }
            return list;
        }
    }
}
