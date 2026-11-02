using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.TerrainFeatures;

namespace StardewAutoPilot
{
    /// <summary>The whole farm as one character per tile, for the agent's zoning plan.</summary>
    internal static class FarmGrid
    {
        /// <summary>
        /// x not buildable · w water · B building · . free buildable ground · d clearable debris (weeds/stones/twigs/grass)
        /// t tree (any axe) · r large stump, log or boulder (needs an upgraded tool) · c tilled/crop · p path/flooring
        /// o placed object (chest, machine, fruit tree...)
        /// </summary>
        public static char Tile(Farm farm, int x, int y)
        {
            if (!World.InBounds(farm, x, y))
                return 'x';
            if (farm.isWaterTile(x, y))
                return 'w';
            var v = new Vector2(x, y);
            if (farm.getBuildingAt(v) != null)
                return 'B';
            if (!GroundBuildable(farm, x, y))
                return 'x';
            if (farm.resourceClumps.Any(r => r.occupiesTile(x, y)))
                return 'r';
            if (farm.objects.TryGetValue(v, out var obj))
                return Plots.ClearableKinds.Contains(World.ObjectKind(obj)) ? 'd' : 'o';
            if (farm.terrainFeatures.TryGetValue(v, out var tf))
                return tf switch
                {
                    HoeDirt => 'c',
                    Flooring => 'p',
                    Grass => 'd',
                    Tree => 't',
                    _ => 'o'
                };
            return '.';
        }

        /// <summary>The map allows building here (ignores whatever currently stands on the tile).</summary>
        public static bool GroundBuildable(Farm farm, int x, int y)
        {
            var rect = farm.GetBuildableRectangle();
            if (rect != Rectangle.Empty && !rect.Contains(x, y))
                return false;
            string buildable = farm.doesTileHavePropertyNoNull(x, y, "Buildable", "Back");
            return buildable.Equals("t", StringComparison.OrdinalIgnoreCase) || buildable.Equals("true", StringComparison.OrdinalIgnoreCase)
                   || farm.doesTileHaveProperty(x, y, "Diggable", "Back") != null && !buildable.Equals("f", StringComparison.OrdinalIgnoreCase);
        }

        public static Dictionary<string, object> Get()
        {
            var farm = Game1.getFarm();
            int w = farm.Map.Layers[0].LayerWidth, h = farm.Map.Layers[0].LayerHeight;
            var rows = new List<string>();
            for (int y = 0; y < h; y++)
            {
                var sb = new StringBuilder(w);
                for (int x = 0; x < w; x++)
                    sb.Append(Tile(farm, x, y));
                rows.Add(sb.ToString());
            }
            var door = farm.GetMainFarmHouseEntry();
            var bin = World.ShippingBin(farm);
            return new Dictionary<string, object>
            {
                ["width"] = w,
                ["height"] = h,
                ["rows"] = rows,
                ["door"] = new[] { door.X, door.Y },
                ["shipping_bin"] = bin == null ? null : new[] { bin.tileX.Value, bin.tileY.Value },
                ["exits"] = World.GetExits(farm).Select(e => new { to = e.To, x = e.X, y = e.Y }).ToList(),
                ["buildings"] = farm.buildings.Select(b => new
                {
                    type = b.buildingType.Value, x = b.tileX.Value, y = b.tileY.Value, w = b.tilesWide.Value, h = b.tilesHigh.Value,
                    door = new[] { b.tileX.Value + b.humanDoor.X, b.tileY.Value + b.humanDoor.Y }
                }).ToList()
            };
        }
    }
}
