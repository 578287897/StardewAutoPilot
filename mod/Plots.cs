using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.TerrainFeatures;

namespace StardewAutoPilot
{
    /// <summary>Rectangular crop plots, so the farm is laid out in tidy blocks instead of scattered tiles.</summary>
    internal static class Plots
    {
        public static readonly HashSet<string> ClearableKinds = new() { "weed", "stone", "twig" };

        /// <summary>Classify every tile of a rectangle: usable as farmland, clearable debris, or blocked.</summary>
        public static Dictionary<string, object> Check(GameLocation loc, Rectangle r)
        {
            int blocked = 0, debris = 0, tilled = 0, planted = 0;
            for (int x = r.X; x < r.Right; x++)
                for (int y = r.Y; y < r.Bottom; y++)
                {
                    switch (Classify(loc, x, y))
                    {
                        case "blocked": blocked++; break;
                        case "debris": debris++; break;
                        case "tilled": tilled++; break;
                        case "planted": planted++; break;
                    }
                }
            int area = r.Width * r.Height;
            return new Dictionary<string, object>
            {
                ["x"] = r.X, ["y"] = r.Y, ["w"] = r.Width, ["h"] = r.Height,
                ["ok"] = blocked == 0,
                ["blocked"] = blocked,
                ["debris"] = debris,
                ["tilled_empty"] = tilled,
                ["planted"] = planted,
                ["free"] = area - blocked - planted
            };
        }

        /// <summary>usable | debris | tilled | planted | blocked</summary>
        public static string Classify(GameLocation loc, int x, int y)
        {
            if (!World.InBounds(loc, x, y) || loc.isWaterTile(x, y))
                return "blocked";
            var v = new Vector2(x, y);
            if (loc.objects.TryGetValue(v, out var obj))
                return ClearableKinds.Contains(World.ObjectKind(obj)) ? "debris" : "blocked";
            if (loc.resourceClumps.Any(c => c.occupiesTile(x, y)))
                return "blocked";
            if (loc.terrainFeatures.TryGetValue(v, out var tf))
            {
                return tf switch
                {
                    HoeDirt d when d.crop == null => "tilled",
                    HoeDirt => "planted",
                    Grass => "debris",
                    _ => "blocked"
                };
            }
            if (loc.doesTileHaveProperty(x, y, "Diggable", "Back") == null)
                return "blocked";
            return World.IsWalkable(loc, x, y) ? "usable" : "blocked";
        }

        /// <summary>Best fully-usable rectangles near an anchor (fewest debris, closest first).</summary>
        public static List<Dictionary<string, object>> Find(GameLocation loc, int w, int h, Point anchor, int radius = 25, int max = 5)
        {
            var found = new List<(double score, Dictionary<string, object> info)>();
            for (int x = anchor.X - radius; x <= anchor.X + radius; x++)
                for (int y = anchor.Y - radius; y <= anchor.Y + radius; y++)
                {
                    var r = new Rectangle(x, y, w, h);
                    // cheap corner test before the full scan
                    if (Classify(loc, x, y) == "blocked" || Classify(loc, r.Right - 1, r.Bottom - 1) == "blocked")
                        continue;
                    var info = Check(loc, r);
                    if (!(bool)info["ok"])
                        continue;
                    double dist = Math.Abs(r.Center.X - anchor.X) + Math.Abs(r.Center.Y - anchor.Y);
                    found.Add((dist + (int)info["debris"] * 0.5, info));
                }

            // keep non-overlapping results
            var result = new List<Dictionary<string, object>>();
            var taken = new List<Rectangle>();
            foreach (var (_, info) in found.OrderBy(f => f.score))
            {
                var r = new Rectangle((int)info["x"], (int)info["y"], w, h);
                if (taken.Any(t => t.Intersects(r)))
                    continue;
                taken.Add(r);
                result.Add(info);
                if (result.Count >= max)
                    break;
            }
            return result;
        }
    }
}
