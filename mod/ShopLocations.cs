using System;
using System.Collections.Generic;

namespace StardewAutoPilot
{
    /// <summary>
    /// Shop id to the interior where that counter actually is.
    /// Keep in step with agent/prompts.py SHOP_HOURS. TryOpenShopMenu follows owner rules,
    /// so it can open FishShop while the player is still on the Beach or the Mountain.
    /// </summary>
    internal static class ShopLocations
    {
        private static readonly Dictionary<string, string> Locations = new(StringComparer.OrdinalIgnoreCase)
        {
            ["SeedShop"] = "SeedShop",
            ["Blacksmith"] = "Blacksmith",
            ["AnimalShop"] = "AnimalShop",
            ["Carpenter"] = "ScienceHouse",
            ["FishShop"] = "FishShop",
            ["Saloon"] = "Saloon",
            ["AdventureShop"] = "AdventureGuild",
            ["AdventureGuild"] = "AdventureGuild",
            ["Hospital"] = "Hospital",
            ["Joja"] = "JojaMart",
        };

        /// <summary>Game data key to pass to TryOpenShopMenu. AdventureGuild is the location name, not the shop id.</summary>
        public static bool TryResolve(string shopId, out string location, out string menuShopId)
        {
            location = null;
            menuShopId = null;
            if (string.IsNullOrWhiteSpace(shopId) || !Locations.TryGetValue(shopId.Trim(), out location))
                return false;
            menuShopId = shopId.Trim().Equals("AdventureGuild", StringComparison.OrdinalIgnoreCase) ? "AdventureShop" : shopId.Trim();
            return true;
        }

        /// <summary>Shop id whose counter is this interior, or null when the player is not at one.</summary>
        public static string ShopAt(string locationName)
        {
            if (string.IsNullOrWhiteSpace(locationName))
                return null;
            string found = null;
            foreach (var pair in Locations)
            {
                if (!pair.Value.Equals(locationName.Trim(), StringComparison.OrdinalIgnoreCase))
                    continue;
                string id = pair.Key.Equals("AdventureGuild", StringComparison.OrdinalIgnoreCase) ? "AdventureShop" : pair.Key;
                found = found == null ? id : found;
            }
            return found;
        }

        /// <summary>Null when this player location is the counter for shopId. Otherwise a failure the agent can act on.</summary>
        public static string RejectReason(string shopId, string locationName, string locationUniqueName)
        {
            if (!TryResolve(shopId, out string expected, out _))
                return $"can't open shop '{shopId}': unknown shop (refusing to open a menu without a location check)";
            if (NameMatches(locationName, expected) || NameMatches(locationUniqueName, expected))
                return null;
            string here = !string.IsNullOrEmpty(locationUniqueName) ? locationUniqueName : locationName;
            if (string.IsNullOrEmpty(here))
                return $"can't open shop '{shopId}': player location is unknown; go to {expected} first";
            return $"can't open shop '{shopId}' at {here}; the counter is in {expected}";
        }

        /// <summary>Null when the menu that opened is the shop that was requested.</summary>
        public static string MenuMismatch(string requestedShopId, string openedShopId)
        {
            if (!TryResolve(requestedShopId, out _, out string expectedMenu))
                return $"shop menu '{openedShopId}' does not match unknown shop '{requestedShopId}'";
            if (!string.IsNullOrEmpty(openedShopId)
                && (string.Equals(openedShopId, expectedMenu, StringComparison.OrdinalIgnoreCase)
                    || string.Equals(openedShopId, requestedShopId.Trim(), StringComparison.OrdinalIgnoreCase)))
                return null;
            return $"shop menu '{openedShopId}' does not match '{requestedShopId}' (expected {expectedMenu})";
        }

        private static bool NameMatches(string actual, string expected) =>
            !string.IsNullOrEmpty(actual) && string.Equals(actual, expected, StringComparison.OrdinalIgnoreCase);
    }
}
