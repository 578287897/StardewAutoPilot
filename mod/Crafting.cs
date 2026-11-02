using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Inventories;
using StardewValley.Objects;

namespace StardewAutoPilot
{
    /// <summary>Crafting recipes and chest storage, read straight from the game's data.</summary>
    internal static class Crafting
    {
        // material-like categories that belong in a chest rather than the backpack
        public static readonly HashSet<int> StorableCategories = new()
        {
            StardewValley.Object.metalResources,      // ores, coal, bars
            StardewValley.Object.buildingResources,   // wood, stone, fiber, clay
            StardewValley.Object.junkCategory,        // trash
            StardewValley.Object.monsterLootCategory,
            StardewValley.Object.mineralsCategory,
            StardewValley.Object.GemCategory,
            StardewValley.Object.CraftingCategory     // crafted items not placed yet (except chests)
        };

        /// <summary>All chests (not gift boxes) on the farm and in the farmhouse.</summary>
        public static List<Chest> FarmChests()
        {
            var chests = new List<Chest>();
            foreach (var loc in new GameLocation[] { Game1.getFarm(), Utility.getHomeOfFarmer(Game1.player) })
                if (loc != null)
                    chests.AddRange(loc.objects.Values.OfType<Chest>().Where(c => !c.giftbox.Value && c.playerChest.Value));
            return chests;
        }

        public static string IngredientName(string id)
        {
            if (int.TryParse(id, out int n) && n < 0)
                return id switch
                {
                    "-4" => "any fish",
                    "-5" => "any egg",
                    "-6" => "any milk",
                    "-777" => "any wild seeds",
                    _ => "category " + id
                };
            return ItemRegistry.GetDataOrErrorItem(id).DisplayName;
        }

        public static List<Dictionary<string, object>> Recipes(bool cooking = false)
        {
            var known = cooking ? Game1.player.cookingRecipes.Keys : Game1.player.craftingRecipes.Keys;
            var chests = FarmChests();
            var list = new List<Dictionary<string, object>>();
            foreach (string name in known)
            {
                CraftingRecipe recipe;
                try { recipe = new CraftingRecipe(name, cooking); }
                catch { continue; }
                list.Add(new Dictionary<string, object>
                {
                    ["name"] = name,
                    ["display"] = recipe.DisplayName,
                    ["ingredients"] = recipe.recipeList.Select(kv => $"{IngredientName(kv.Key)} x{kv.Value}").ToList(),
                    ["can_make"] = recipe.getCraftableCount(chests),
                    ["description"] = recipe.description?.Replace("\n", " ")
                });
            }
            return list.OrderByDescending(r => (int)r["can_make"] > 0).ThenBy(r => (string)r["name"]).ToList();
        }

        public static CraftingRecipe Find(string query, bool cooking = false)
        {
            var known = cooking ? Game1.player.cookingRecipes.Keys : Game1.player.craftingRecipes.Keys;
            string q = query.Trim().ToLowerInvariant();
            string name = known.FirstOrDefault(k => k.ToLowerInvariant() == q)
                          ?? known.FirstOrDefault(k => new CraftingRecipe(k, cooking).DisplayName.ToLowerInvariant() == q)
                          ?? known.FirstOrDefault(k => k.ToLowerInvariant().Contains(q));
            return name == null ? null : new CraftingRecipe(name, cooking);
        }

        /// <summary>Craft up to <paramref name="count"/> items; ingredients may come from farm chests. Returns how many were made.</summary>
        public static int Craft(CraftingRecipe recipe, int count, out string problem, IEnumerable<Chest> extraChests = null)
        {
            problem = null;
            var chests = FarmChests();
            if (extraChests != null)
                chests.AddRange(extraChests.Where(c => c != null && !chests.Contains(c)));
            var extra = chests.Select(c => (IInventory)c.Items).ToList();
            var extraItems = chests.SelectMany(c => c.Items).Where(i => i != null).ToList();
            int made = 0;
            for (; made < count; made++)
            {
                if (!recipe.doesFarmerHaveIngredientsInInventory(extraItems))
                {
                    problem = "not enough ingredients: " + string.Join(", ", recipe.recipeList.Select(kv => $"{IngredientName(kv.Key)} x{kv.Value}"));
                    break;
                }
                var item = recipe.createItem();
                if (!Game1.player.couldInventoryAcceptThisItem(item))
                {
                    problem = "inventory full";
                    break;
                }
                recipe.consumeIngredients(extra);
                Game1.player.addItemToInventoryBool(item);
                if (recipe.isCookingRecipe)
                    Game1.player.cookedRecipe(item.ItemId);
                else if (Game1.player.craftingRecipes.ContainsKey(recipe.name))
                    Game1.player.craftingRecipes[recipe.name] += 1; // times crafted, as the crafting menu does
                extraItems = chests.SelectMany(c => c.Items).Where(i => i != null).ToList();
            }
            return made;
        }

        /// <summary>Craft one item and put it on a tile directly (no backpack slot needed). Returns an error or null.</summary>
        public static string CraftAndPlace(CraftingRecipe recipe, GameLocation loc, Point tile)
        {
            var chests = FarmChests();
            if (!recipe.doesFarmerHaveIngredientsInInventory(chests.SelectMany(c => c.Items).Where(i => i != null).ToList()))
                return "not enough ingredients: " + string.Join(", ", recipe.recipeList.Select(kv => $"{IngredientName(kv.Key)} x{kv.Value}"));
            if (recipe.createItem() is not StardewValley.Object obj)
                return "this item can't be placed";
            var v = new Vector2(tile.X, tile.Y);
            if (!loc.CanItemBePlacedHere(v))
                return "tile is occupied";
            if (!obj.placementAction(loc, tile.X * 64, tile.Y * 64, Game1.player))
                return "placement failed";
            recipe.consumeIngredients(chests.Select(c => (IInventory)c.Items).ToList());
            if (Game1.player.craftingRecipes.ContainsKey(recipe.name))
                Game1.player.craftingRecipes[recipe.name] += 1;
            return null;
        }

        public static bool IsStorable(Item item) =>
            item is not Tool && item.Category != StardewValley.Object.SeedsCategory
            && (StorableCategories.Contains(item.Category) || item.QualifiedItemId == "(O)92" /* sap */)
            && item.QualifiedItemId != "(BC)130"; // keep spare chests in the backpack

        public static Chest NearestChest(GameLocation loc, Point from, Point? at)
        {
            if (at != null)
                return loc.objects.TryGetValue(new Vector2(at.Value.X, at.Value.Y), out var o) && o is Chest c && !c.giftbox.Value ? c : null;
            return loc.objects.Pairs
                .Where(kv => kv.Value is Chest c && !c.giftbox.Value && c.playerChest.Value)
                .OrderBy(kv => Math.Abs(kv.Key.X - from.X) + Math.Abs(kv.Key.Y - from.Y))
                .Select(kv => (Chest)kv.Value)
                .FirstOrDefault();
        }
    }
}
