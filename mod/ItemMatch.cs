using System;

namespace StardewAutoPilot
{
    /// <summary>Exact item identity. A shorter name must not match a longer one.</summary>
    internal static class ItemMatch
    {
        public static bool IsExact(string query, string displayName, string internalName, string itemId, string qualifiedId)
        {
            if (string.IsNullOrWhiteSpace(query))
                return false;
            return Equals(query, displayName) || Equals(query, internalName) || Equals(query, itemId) || Equals(query, qualifiedId);
        }

        private static bool Equals(string query, string value) =>
            !string.IsNullOrEmpty(value) && string.Equals(query.Trim(), value.Trim(), StringComparison.OrdinalIgnoreCase);
    }
}
