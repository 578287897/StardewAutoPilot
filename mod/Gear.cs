using System;
using System.Collections.Generic;
using System.Linq;
using StardewValley;
using StardewValley.Internal;
using StardewValley.Tools;
using SObject = StardewValley.Object;

namespace StardewAutoPilot
{
    /// <summary>Combat readiness: weapon strength and healing food decide how deep the mine action may go.</summary>
    internal static class Gear
    {
        /// <summary>Average weapon damage needed below each band (floors 40-79 and 80-120).</summary>
        public const float PowerFor40 = 7f, PowerFor80 = 14f;
        public const int FoodFor20 = 3, FoodFor40 = 5;

        public static float Power(MeleeWeapon w) => (w.minDamage.Value + w.maxDamage.Value) / 2f;

        /// <summary>Backpack slot of the strongest melee weapon (scythes only if there is nothing else), or -1.</summary>
        public static int BestWeaponSlot(Farmer who)
        {
            int best = -1;
            float bestScore = -1;
            for (int i = 0; i < who.Items.Count; i++)
                if (who.Items[i] is MeleeWeapon w)
                {
                    float score = w.isScythe() ? 0.01f : Power(w);
                    if (score > bestScore)
                    {
                        best = i;
                        bestScore = score;
                    }
                }
            return best;
        }

        public static MeleeWeapon BestWeapon(Farmer who) => BestWeaponSlot(who) is var s and >= 0 ? (MeleeWeapon)who.Items[s] : null;

        public static float WeaponPower(Farmer who) => BestWeapon(who) is { } w && !w.isScythe() ? Power(w) : 0f;

        /// <summary>Items that restore health when eaten (count of individual items).</summary>
        public static int FoodCount(Farmer who) =>
            who.Items.OfType<SObject>().Where(o => o.Edibility > 0 && !o.bigCraftable.Value).Sum(o => o.Stack);

        /// <summary>Deepest floor that is safe with this weapon and food, and the reason it isn't deeper.</summary>
        public static (int floor, string reason) SafeDepth(Farmer who)
        {
            float power = WeaponPower(who);
            int food = FoodCount(who);
            string weapon = BestWeapon(who) is { } w ? $"{w.DisplayName} {w.minDamage.Value}-{w.maxDamage.Value}" : "no weapon";
            if (food < FoodFor20)
                return (19, $"only {food} healing food (need {FoodFor20}+ for floor 20 and below, {FoodFor40}+ for 40 and below)");
            if (power < PowerFor40)
                return (39, $"weapon too weak for floor 40+ ({weapon}; need average damage {PowerFor40}+): buy_weapon at the Adventurer's Guild");
            if (food < FoodFor40)
                return (39, $"only {food} healing food (need {FoodFor40}+ for floor 40 and below)");
            if (power < PowerFor80)
                return (79, $"weapon too weak for floor 80+ ({weapon}; need average damage {PowerFor80}+): buy_weapon at the Adventurer's Guild");
            return (120, null);
        }

        /// <summary>Melee weapons Marlon sells right now (the game's own shop data and conditions).</summary>
        public static List<(MeleeWeapon weapon, int price)> GuildWeapons()
        {
            var list = new List<(MeleeWeapon, int)>();
            try
            {
                foreach (var kv in ShopBuilder.GetShopStock("AdventureShop"))
                    if (kv.Key is MeleeWeapon w && !w.isScythe() && kv.Value.TradeItem == null)
                        list.Add((w, kv.Value.Price));
            }
            catch (Exception)
            {
                // stock can't be built outside a loaded save
            }
            return list.OrderByDescending(x => Power(x.Item1)).ToList();
        }

        public static Dictionary<string, object> Status(Farmer who)
        {
            var w = BestWeapon(who);
            var (depth, reason) = SafeDepth(who);
            return new Dictionary<string, object>
            {
                ["weapon"] = w == null ? null : $"{w.DisplayName} {w.minDamage.Value}-{w.maxDamage.Value}",
                ["weapon_power"] = WeaponPower(who),
                ["food"] = FoodCount(who),
                ["health"] = $"{who.health}/{who.maxHealth}",
                ["safe_depth"] = depth,
                ["safe_depth_reason"] = reason,
                ["guild_weapons"] = GuildWeapons().Take(6).Select(x => $"{x.weapon.DisplayName} {x.weapon.minDamage.Value}-{x.weapon.maxDamage.Value} {x.price}g").ToList()
            };
        }
    }
}
