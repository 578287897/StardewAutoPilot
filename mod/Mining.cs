using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Locations;
using StardewValley.Monsters;

namespace StardewAutoPilot
{
    /// <summary>Mine floors: ladders, exits and monsters, read from the map and the location's characters.</summary>
    internal static class Mining
    {
        public const int LadderDown = 173, Shaft = 174, LadderUp = 115, Elevator = 112;

        /// <summary>Tiles on the Buildings layer with one of the given indexes (ladders, exits...).</summary>
        public static List<Point> FindTiles(GameLocation loc, params int[] indexes)
        {
            var found = new List<Point>();
            var layer = loc.Map.GetLayer("Buildings");
            if (layer == null)
                return found;
            for (int x = 0; x < layer.LayerWidth; x++)
                for (int y = 0; y < layer.LayerHeight; y++)
                {
                    int index = loc.getTileIndexAt(x, y, "Buildings");
                    if (index >= 0 && indexes.Contains(index))
                        found.Add(new Point(x, y));
                }
            return found;
        }

        public static List<Monster> Monsters(GameLocation loc) =>
            loc.characters.OfType<Monster>().Where(m => m.Health > 0 && !m.IsInvisible).ToList();

        public static Dictionary<string, object> Describe(GameLocation loc)
        {
            if (loc is not MineShaft mine)
                return null;
            var p = Game1.player.TilePoint;
            return new Dictionary<string, object>
            {
                ["level"] = mine.mineLevel,
                ["deepest"] = Game1.player.deepestMineLevel,
                ["ladders_down"] = FindTiles(loc, LadderDown, Shaft).Select(t => new[] { t.X, t.Y }).ToList(),
                ["monsters"] = Monsters(loc).OrderBy(m => World.Manhattan(m.TilePoint, p)).Take(8)
                    .Select(m => new { name = m.Name, x = m.TilePoint.X, y = m.TilePoint.Y, hp = m.Health }).ToList(),
                ["stones_left"] = loc.objects.Values.Count(o => World.ObjectKind(o) == "stone")
            };
        }
    }
}
