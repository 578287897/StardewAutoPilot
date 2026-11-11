using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;

namespace StardewAutoPilot
{
    /// <summary>Describes menus as structured data and handles the boring ones automatically.</summary>
    internal class MenuAutomation
    {
        private readonly ModEntry mod;
        private IClickableMenu lastMenu;
        private string lastDialogue;
        private int menuAge;
        private int eventAge;
        private string lastEventKey;
        private int tempAge;
        private int strandedAge;
        private bool releasedStranded;
        public static int TempAge { get; private set; }

        public MenuAutomation(ModEntry mod) { this.mod = mod; }

        public void Tick(uint ticks)
        {
            var menu = Game1.activeClickableMenu;
            if (!ReferenceEquals(menu, this.lastMenu))
            {
                this.lastMenu = menu;
                this.menuAge = 0;
            }
            this.menuAge++;

            if (menu is DialogueBox db)
            {
                string text = SafeText(db);
                if (text != null && text != this.lastDialogue)
                {
                    this.lastDialogue = text;
                    string speaker = db.characterDialogue?.speaker?.Name;
                    this.mod.Log.Add(db.isQuestion ? "question" : "dialogue", (speaker != null ? speaker + ": " : "") + text);
                }
            }
            else
                this.lastDialogue = null;

            // only act every 20 ticks, and never while the agent is driving a menu action itself
            if (ticks % 20 != 0 || this.mod.Runner.Busy && this.mod.Runner.CurrentType is "dialog_answer" or "dialog_advance" or "menu_click")
                return;

            var ev = Game1.CurrentEvent;
            string eventKey = Game1.eventUp && ev != null ? $"{ev.id}:{ev.isFestival}" : null;
            if (eventKey != this.lastEventKey)
            {
                this.lastEventKey = eventKey;
                this.eventAge = 0;
            }
            if (eventKey != null)
                this.eventAge++;

            bool warping = Game1.isWarping || Game1.fadeToBlack;
            bool onTemp = string.Equals(Game1.currentLocation?.Name, "Temp", StringComparison.OrdinalIgnoreCase);
            bool runnerBusy = this.mod.Runner.Busy;
            bool festival = ev?.isFestival == true;
            bool playable = festival && ev.playerControlSequence && !warping && Context.IsPlayerFree;
            if (!onTemp || !Game1.eventUp)
            {
                this.strandedAge = 0;
                this.releasedStranded = false;
            }
            else if (!runnerBusy)
                this.strandedAge++;
            else
                this.strandedAge = 0;
            if (onTemp && Game1.eventUp && !runnerBusy && this.releasedStranded && this.strandedAge >= FestivalHold.StrandedTicks)
            {
                this.strandedAge = 0;
                this.HardLeaveTemp();
                return;
            }
            if (FestivalHold.ShouldLeave(onTemp, Game1.eventUp, festival, warping, playable, runnerBusy, this.strandedAge) && !this.releasedStranded)
            {
                this.releasedStranded = true;
                this.strandedAge = 0;
                this.ReleaseStrandedMap(ev);
                return;
            }

            bool bareTemp = onTemp && Game1.eventUp && ev == null && !warping;
            this.tempAge = bareTemp ? this.tempAge + 1 : 0;
            TempAge = this.tempAge;
            string presence = Presence.Classify(Game1.eventUp, festival, warping, Game1.currentLocation?.Name, menu?.GetType().Name, this.tempAge);
            if (Presence.ShouldWarpHome(presence))
            {
                this.tempAge = 0;
                TempAge = 0;
                this.mod.Log.Add("event", "Temp had no event for 15s; warping home without restarting the process");
                Game1.warpFarmer("FarmHouse", 9, 9, 2);
                return;
            }

            if (Game1.eventUp && ev != null && this.mod.Config.AutoSkipEvents && !ev.skipped && !ev.isFestival)
            {
                // Normal path: skippable cutscenes. Stuck path: after ~90s still eventUp, force-skip
                // so sleep/work cannot spin forever on "a cutscene/event is running".
                bool stuck = this.eventAge >= 270; // Tick runs every 20 frames ≈ 1/3s → ~90s
                if (ev.skippable || stuck)
                {
                    ev.skipped = true;
                    this.mod.Log.Add("event", (stuck && !ev.skippable ? "Force-skipped stuck cutscene " : "Skipped cutscene ") + ev.id);
                    if (stuck && !ev.skippable)
                        this.mod.Monitor.Log($"Force-skipping non-skippable event {ev.id} after it stayed up too long.", LogLevel.Warn);
                    ev.skipEvent();
                    return;
                }
            }

            switch (menu)
            {
                case DialogueBox box when this.mod.Config.AutoAdvanceDialogue && !box.isQuestion && this.menuAge > 30:
                    box.receiveLeftClick(0, 0);
                    break;
                // reward pop-ups (skipped event gifts, treasure, quest rewards): take everything and close; chests are left alone
                case ItemGrabMenu grab when grab.context is not StardewValley.Objects.Chest && this.menuAge > 20:
                    var taken = new List<string>();
                    foreach (var item in grab.ItemsToGrabMenu.actualInventory.ToList())
                    {
                        if (item == null)
                            continue;
                        int stack = item.Stack;
                        if (Game1.player.addItemToInventoryBool(item))
                            taken.Add($"{stack}x {item.DisplayName}");
                        else
                        {
                            // backpack full: drop it at our feet instead of losing it with the menu
                            Game1.createItemDebris(item, Game1.player.getStandingPosition(), Game1.player.FacingDirection);
                            taken.Add($"{item.Stack}x {item.DisplayName} (dropped on the ground: backpack full)");
                        }
                        grab.ItemsToGrabMenu.actualInventory.Remove(item);
                        grab.behaviorOnItemGrab?.Invoke(item, Game1.player);
                    }
                    if (taken.Count > 0)
                        this.mod.Log.Add("hud", "Received " + string.Join(", ", taken));
                    grab.exitThisMenu(false);
                    break;
                case ShippingMenu when this.mod.Config.AutoConfirmEndOfDayMenus && this.menuAge > 60:
                    this.ClickField(menu, "okButton");
                    break;
                // profession choice at levels 5/10: pick the money-making branch (same steps as clicking it)
                case LevelUpMenu chooser when this.mod.Config.AutoConfirmEndOfDayMenus && this.menuAge > 120 && chooser.isActive
                                              && this.mod.Helper.Reflection.GetField<bool>(menu, "isProfessionChooser").GetValue():
                    var choices = this.mod.Helper.Reflection.GetField<List<int>>(menu, "professionsToChoose").GetValue();
                    if (choices.Count >= 2)
                    {
                        // farming: Tiller over Rancher (crops first); other skills: the first branch (Fisher/Forester/Miner/Fighter...)
                        int pick = choices[0] / 6 == 0 && choices[0] % 6 == 0 ? choices[1] : choices[0];
                        Game1.player.professions.Add(pick);
                        chooser.getImmediateProfessionPerk(pick);
                        chooser.isActive = false;
                        chooser.informationUp = false;
                        this.mod.Helper.Reflection.GetField<bool>(menu, "isProfessionChooser").SetValue(false);
                        chooser.RemoveLevelFromLevelList();
                        this.mod.Log.Add("hud", "Chose profession " + LevelUpMenu.getProfessionTitleFromNumber(pick));
                    }
                    break;
                // the level-up screen ignores clicks; it is confirmed through okButtonClicked()
                case LevelUpMenu levelUp when this.mod.Config.AutoConfirmEndOfDayMenus && this.menuAge > 60
                                              && levelUp.isActive && !this.mod.Helper.Reflection.GetField<bool>(menu, "isProfessionChooser").GetValue():
                    levelUp.okButtonClicked();
                    break;
            }
        }

        /// <summary>
        /// Leave a festival Temp map without the vanilla jump to 22:00.
        /// <see cref="Event.exitEvent"/> fast-forwards machines by the minutes until 22:00 and then
        /// sets <c>timeOfDayAfterFade</c>. Setting the clock to 22:00 first makes that span zero,
        /// and putting the saved time back keeps 9:10 (or whenever the farmer was pulled in).
        /// </summary>
        private void ReleaseStrandedMap(Event ev)
        {
            int kept = Game1.timeOfDay;
            if (ev != null && ev.isFestival)
            {
                try
                {
                    // Span until 22:00 is zero, so machines are not fast-forwarded. Restored below.
                    Game1.timeOfDay = 2200;
                    ev.exitEvent();
                }
                finally
                {
                    Game1.timeOfDay = kept;
                    Game1.timeOfDayAfterFade = kept;
                }
                foreach (var npc in Utility.getAllVillagers())
                {
                    if (npc != null)
                        npc.ignoreScheduleToday = false;
                }
                this.mod.Log.Add("event", $"Festival Temp map was not going to end; left it and kept the clock at {kept}.");
                this.mod.Monitor.Log($"Left a stranded festival map. Clock kept at {kept} instead of jumping to 2200.", LogLevel.Warn);
                return;
            }
            this.HardLeaveTemp();
        }

        /// <summary>The festival fade did not finish. Drop the event flag and warp home at the current time.</summary>
        private void HardLeaveTemp()
        {
            int kept = Game1.timeOfDay;
            var ev = Game1.currentLocation?.currentEvent;
            if (ev != null)
            {
                ev.isFestival = false;
                try { ev.cleanup(); }
                catch (Exception ex) { this.mod.Monitor.Log("Temp cleanup failed: " + ex.Message, LogLevel.Warn); }
            }
            if (Game1.currentLocation != null)
                Game1.currentLocation.currentEvent = null;
            Game1.eventUp = false;
            Game1.eventOver = false;
            Game1.fadeToBlack = false;
            Game1.nonWarpFade = false;
            Game1.timeOfDayAfterFade = -1;
            Game1.locationRequest = null;
            typeof(Game1).GetProperty("isWarping", BindingFlags.Public | BindingFlags.Static)
                ?.GetSetMethod(true)
                ?.Invoke(null, new object[] { false });
            Game1.timeOfDay = kept;
            Game1.player.CanMove = true;
            Game1.warpFarmer("FarmHouse", 9, 9, 2);
            this.mod.Log.Add("event", $"Temp map was still holding the clock at {kept}; warping home.");
            this.mod.Monitor.Log($"Warped home from a Temp map that did not release. Clock kept at {kept}.", LogLevel.Warn);
        }

        /// <summary>Click the center of a ClickableComponent field on a menu. Returns false if the field doesn't exist.</summary>
        public bool ClickField(IClickableMenu menu, string field)
        {
            var comp = this.mod.Helper.Reflection.GetField<ClickableComponent>(menu, field, required: false)?.GetValue();
            if (comp == null)
                return false;
            menu.receiveLeftClick(comp.bounds.Center.X, comp.bounds.Center.Y);
            return true;
        }

        public static List<ClickableComponent> Components(IClickableMenu menu)
        {
            if (menu.allClickableComponents == null)
                menu.populateClickableComponentList();
            return menu.allClickableComponents?.Where(c => c != null && c.visible).ToList() ?? new List<ClickableComponent>();
        }

        private static string SafeText(DialogueBox db)
        {
            try { return db.getCurrentString(); }
            catch { return null; }
        }

        /// <summary>A shop row; seeds also get growth time, seasons and profit per day so the agent can compare crops.</summary>
        private static Dictionary<string, object> ShopEntry(Item item, int price, int stock)
        {
            var row = new Dictionary<string, object> { ["id"] = item.QualifiedItemId, ["name"] = item.DisplayName, ["price"] = price };
            if (stock != int.MaxValue)
                row["stock"] = stock;
            if (item.Category == StardewValley.Object.SeedsCategory)
            {
                var info = ItemInfo.Describe(item.QualifiedItemId, price);
                if (info.TryGetValue("crop", out var crop))
                    row["crop"] = crop;
                if (info.TryGetValue("profit_per_day_first_harvest", out var ppd))
                    row["profit_per_day"] = ppd;
            }
            return row;
        }

        public static Dictionary<string, object> Describe(ModEntry mod, IClickableMenu menu)
        {
            var d = new Dictionary<string, object> { ["type"] = menu.GetType().Name };
            switch (menu)
            {
                case DialogueBox db:
                    d["text"] = SafeText(db);
                    d["speaker"] = db.characterDialogue?.speaker?.Name;
                    d["is_question"] = db.isQuestion;
                    if (db.responses != null)
                        d["responses"] = db.responses.Select((r, i) => new { index = i, text = r.responseText }).ToList();
                    d["hint"] = db.isQuestion ? "use dialog_answer {index}" : "use dialog_advance";
                    return d;

                case ShopMenu shop:
                    d["shop_id"] = shop.ShopId;
                    d["items"] = shop.itemPriceAndStock
                        .Where(kv => kv.Key is Item { IsRecipe: false } && kv.Value.TradeItem == null)
                        .Take(80)
                        .Select(kv => ShopEntry((Item)kv.Key, kv.Value.Price, kv.Value.Stock))
                        .ToList();
                    d["hint"] = "use buy {item, count}; close_menu when done";
                    return d;

                case ItemGrabMenu grab:
                    d["chest"] = grab.context is StardewValley.Objects.Chest; // reward pop-ups (not chests) are collected by the mod
                    break;

                case LevelUpMenu:
                    bool chooser = mod.Helper.Reflection.GetField<bool>(menu, "isProfessionChooser").GetValue();
                    d["is_profession_chooser"] = chooser;
                    if (chooser)
                    {
                        d["left"] = string.Join(" ", mod.Helper.Reflection.GetField<List<string>>(menu, "leftProfessionDescription", false)?.GetValue() ?? new List<string>());
                        d["right"] = string.Join(" ", mod.Helper.Reflection.GetField<List<string>>(menu, "rightProfessionDescription", false)?.GetValue() ?? new List<string>());
                        d["hint"] = "use choose_profession {side: left|right}";
                    }
                    return d;
            }

            d["components"] = Components(menu).Take(40)
                .Select((c, i) => new { index = i, name = c.name, label = c.label })
                .ToList();
            d["hint"] = "use menu_click {index} or close_menu";
            return d;
        }
    }
}
