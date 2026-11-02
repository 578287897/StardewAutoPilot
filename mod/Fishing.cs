using System;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Menus;

namespace StardewAutoPilot
{
    /// <summary>
    /// Plays the fishing minigame from game state (no screen reading): each tick after the game updates the
    /// bobber bar, decide whether the "reel" button would be held and apply the difference the game itself
    /// would have applied (holding = -0.25 acceleration, releasing = +0.25; scaled by 0.6 while the fish is in the bar).
    /// </summary>
    internal static class Fishing
    {
        public static bool Active;

        public static void Tick()
        {
            if (!Active || Game1.activeClickableMenu is not BobberBar bar || bar.fadeOut)
                return;

            float fishCenter = bar.bobberPosition + 16f;
            float barCenter = bar.bobberBarPos + bar.bobberBarHeight / 2f;
            // aim slightly ahead: where the bar will be in a few ticks at its current speed
            bool hold = fishCenter < barCenter + bar.bobberBarSpeed * 6f;
            if (!hold)
                return; // the game already applied "released"

            float scale = bar.bobberInBar ? (bar.bobbers.Contains("(O)691") ? 0.3f : 0.6f) : 1f;
            float delta = -0.5f * scale; // from +0.25 (released) to -0.25 (held)
            bar.bobberBarSpeed += delta;
            bar.bobberBarPos += delta;
            float max = 568 - bar.bobberBarHeight;
            if (bar.bobberBarPos <= 0f)
            {
                bar.bobberBarPos = 0f;
                bar.bobberBarSpeed = Math.Max(bar.bobberBarSpeed, 0f);
            }
            else if (bar.bobberBarPos > max)
                bar.bobberBarPos = max;
        }

        /// <summary>FishingRod.getAddedDistance (private in the game).</summary>
        public static int AddedDistance(Farmer who) =>
            who.FishingLevel >= 15 ? 4 : who.FishingLevel >= 8 ? 3 : who.FishingLevel >= 4 ? 2 : who.FishingLevel >= 1 ? 1 : 0;

        /// <summary>Where the bobber lands for a cast, using the same formula as FishingRod's cast animation.</summary>
        public static Point Landing(Point standingPixel, int dir, float power, int added)
        {
            float x = standingPixel.X, y = standingPixel.Y;
            if (dir == 1 || dir == 3)
                x += (dir == 1 ? 1 : -1) * (Math.Max(128f, power * (added + 4) * 64f) - 8f);
            else
                y += (dir == 2 ? 1 : -1) * Math.Max(128f, power * (added + 3) * 64f);
            return new Point((int)Math.Floor(x / 64f), (int)Math.Floor(y / 64f));
        }

        /// <summary>
        /// Casting power that lands the bobber in fishable water with a tile of water on each side
        /// (falls back to no margin for narrow streams). Prefers the farthest such cast. -1 if none.
        /// </summary>
        public static float PickPower(GameLocation loc, Point standingPixel, int dir, int added)
        {
            Point side = dir == 1 || dir == 3 ? new Point(0, 1) : new Point(1, 0);
            Point along = dir switch { 0 => new Point(0, -1), 1 => new Point(1, 0), 2 => new Point(0, 1), _ => new Point(-1, 0) };
            foreach (bool margin in new[] { true, false })
                for (float power = 1f; power >= 0.1f; power -= 0.05f)
                {
                    var t = Landing(standingPixel, dir, power, added);
                    if (!loc.isTileFishable(t.X, t.Y))
                        continue;
                    if (margin && !(loc.isTileFishable(t.X + along.X, t.Y + along.Y) && loc.isTileFishable(t.X - along.X, t.Y - along.Y)
                                    && loc.isTileFishable(t.X + side.X, t.Y + side.Y) && loc.isTileFishable(t.X - side.X, t.Y - side.Y)))
                        continue;
                    return power;
                }
            return -1f;
        }

        public static Point TileCenterPixel(Point tile) => new Point(tile.X * 64 + 32, tile.Y * 64 + 32);

        /// <summary>A standing tile from which a cast lands in fishable water, the direction to face and the power.</summary>
        public static bool FindSpot(GameLocation loc, Point from, int added, out System.Collections.Generic.List<Point> path, out int dir, out float power)
        {
            int foundDir = -1;
            float foundPower = -1f;
            int maxReach = added + 5;
            bool IsSpot(Point p)
            {
                if (loc.isWaterTile(p.X, p.Y))
                    return false;
                for (int d = 0; d < 4; d++)
                {
                    var step = d switch { 0 => new Point(0, -1), 1 => new Point(1, 0), 2 => new Point(0, 1), _ => new Point(-1, 0) };
                    bool near = false; // cheap pre-check before simulating casts
                    for (int k = 1; k <= maxReach && !near; k++)
                        near = loc.isWaterTile(p.X + step.X * k, p.Y + step.Y * k);
                    if (!near)
                        continue;
                    float pw = PickPower(loc, TileCenterPixel(p), d, added);
                    if (pw > 0)
                    {
                        foundDir = d;
                        foundPower = pw;
                        return true;
                    }
                }
                return false;
            }
            path = World.FindPath(loc, from, IsSpot, 60000);
            if (path != null)
                IsSpot(path.Count > 0 ? path[^1] : from);
            dir = foundDir;
            power = foundPower;
            return path != null;
        }
    }
}
