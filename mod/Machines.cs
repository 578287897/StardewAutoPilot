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
    }
}
