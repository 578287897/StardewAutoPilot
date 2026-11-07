using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using StardewValley;
using SObject = StardewValley.Object;

namespace StardewAutoPilot
{
    /// <summary>Processing machines (kegs, preserves jars, furnaces...) on the farm and in the house.</summary>
    internal static class Machines
    {
        public static IEnumerable<GameLocation> Locations()
        {
            yield return Game1.getFarm();
            if (Utility.getHomeOfFarmer(Game1.player) is { } home)
                yield return home;
        }

        public static IEnumerable<(GameLocation loc, Point tile, SObject machine)> All()
        {
            foreach (var loc in Locations())
                foreach (var pair in loc.objects.Pairs)
                    if (pair.Value.bigCraftable.Value && pair.Value.GetMachineData() != null)
                        yield return (loc, new Point((int)pair.Key.X, (int)pair.Key.Y), pair.Value);
        }

        public static List<Dictionary<string, object>> Status() =>
            All().Select(m => new Dictionary<string, object>
            {
                ["name"] = m.machine.DisplayName,
                ["id"] = m.machine.QualifiedItemId,
                ["location"] = m.loc.NameOrUniqueName,
                ["x"] = m.tile.X,
                ["y"] = m.tile.Y,
                ["contains"] = m.machine.heldObject.Value?.DisplayName,
                ["ready"] = m.machine.readyForHarvest.Value,
                ["minutes_left"] = m.machine.heldObject.Value != null && !m.machine.readyForHarvest.Value ? m.machine.MinutesUntilReady : 0
            }).ToList();

        /// <summary>First backpack slot holding something this machine accepts (asks the machine itself, without consuming).</summary>
        public static int AcceptedSlot(SObject machine, Farmer who, string only = null)
        {
            for (int i = 0; i < who.Items.Count; i++)
            {
                var item = who.Items[i];
                if (item == null || item is Tool)
                    continue;
                if (only != null && !item.DisplayName.Contains(only, System.StringComparison.OrdinalIgnoreCase) && !item.Name.Contains(only, System.StringComparison.OrdinalIgnoreCase))
                    continue;
                // probe mode is side-effect free: the game calls it every frame for the hover cursor
                bool accepts;
                try { accepts = machine.performObjectDropInAction(item, true, who); }
                catch { accepts = false; }
                if (accepts)
                    return i;
            }
            return -1;
        }

        /// <summary>Move up to <paramref name="count"/> of an item from the farm chests into the backpack. Returns how many moved.</summary>
        public static int TakeFromChests(string qualifiedId, int count, Farmer who)
        {
            int moved = 0;
            foreach (var chest in Crafting.FarmChests())
            {
                int have = chest.Items.CountId(qualifiedId);
                int n = System.Math.Min(have, count - moved);
                if (n <= 0)
                    continue;
                var item = ItemRegistry.Create(qualifiedId, n);
                if (!who.couldInventoryAcceptThisItem(item))
                    break;
                chest.Items.ReduceId(qualifiedId, n);
                who.addItemToInventoryBool(item);
                moved += n;
                if (moved >= count)
                    break;
            }
            return moved;
        }

        /// <summary>
        /// Make the backpack able to feed this machine from the farm chests: its fuel (e.g. coal for furnaces) first,
        /// then the first chest item the machine accepts (e.g. 5 copper ore). Returns the accepted backpack slot or -1.
        /// </summary>
        public static int StockFromChests(SObject machine, Farmer who, string only = null)
        {
            foreach (var extra in machine.GetMachineData()?.AdditionalConsumedItems ?? new())
            {
                string id = ItemRegistry.QualifyItemId(extra.ItemId);
                int missing = extra.RequiredCount - who.Items.CountId(id);
                if (missing > 0)
                    TakeFromChests(id, missing, who);
            }
            foreach (var chest in Crafting.FarmChests())
                foreach (var item in chest.Items.Where(i => i is SObject && i is not Tool).ToList())
                {
                    if (only != null && !item.DisplayName.Contains(only, System.StringComparison.OrdinalIgnoreCase) && !item.Name.Contains(only, System.StringComparison.OrdinalIgnoreCase))
                        continue;
                    bool accepts;
                    try { accepts = machine.performObjectDropInAction(item, true, who); }
                    catch { accepts = false; }
                    if (!accepts)
                        continue;
                    // a few loads' worth, so the next empty machine (or the next batch) is ready too
                    TakeFromChests(item.QualifiedItemId, System.Math.Min(item.Stack, 25), who);
                    return AcceptedSlot(machine, who, only);
                }
            return -1;
        }
    }
}
