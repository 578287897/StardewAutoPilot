using StardewAutoPilot;

string testRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "tests", "ModProtocol"));
string directory = Path.Combine(testRoot, ".test-" + Guid.NewGuid().ToString("N"));
Directory.CreateDirectory(directory);
string path = Path.Combine(directory, "receipts.json");
int checks = 0;
void Check(bool condition, string name)
{
    if (!condition) throw new Exception(name);
    checks++;
}
try
{
    var receipts = new ActionReceipts(path);
    Check(receipts.Begin("upgrade-1", "farm-a", "pickaxe"), "new request accepted");
    Check(!receipts.Begin("upgrade-1", "farm-a", "pickaxe"), "duplicate cannot start");
    receipts = new ActionReceipts(path);
    Check(receipts.Get("upgrade-1").Result == null, "crashed intent remains unresolved after restart");
    Check(!receipts.Begin("upgrade-1", "farm-b", "axe"), "same ID cannot be reused for another payload/save");
    Check(receipts.Get("upgrade-1").Scope == "farm-a", "original scope preserved");
    receipts.Complete("upgrade-1", new() { ["ok"] = true, ["request_id"] = "upgrade-1" });
    receipts = new ActionReceipts(path);
    Check(receipts.Get("upgrade-1").Result != null, "completion survives restart");
    Check(!receipts.Begin("upgrade-1", "farm-a", "pickaxe"), "completed request cannot execute twice");
    Check(receipts.Get("absent") == null, "unknown operation is not assumed successful");
    Check(File.Exists(path + ".bak"), "previous receipt file retained");
    string blocked = Path.Combine(directory, "not-a-directory");
    File.WriteAllText(blocked, "block directory creation");
    var failed = new ActionReceipts(Path.Combine(blocked, "receipts.json"));
    bool beginRejected = false;
    try { failed.Begin("not-started", "farm", "buy"); } catch (IOException) { beginRejected = true; }
    Check(beginRejected && failed.Get("not-started") == null, "failure to persist intent cannot start work");
    File.WriteAllText(path, "invalid-json");
    bool rejected = false;
    try { _ = new ActionReceipts(path); } catch (System.Text.Json.JsonException) { rejected = true; }
    Check(rejected, "corrupt ledger fails closed instead of forgetting operations");
    Console.WriteLine($"{checks} receipt checks passed.");

    FishingRecovery.Sample Open(bool fadeOut, bool handled, float progress, bool pulling) => new()
    {
        MenuOpen = true, FadeOut = fadeOut, ResultHandled = handled, Progress = progress, PullStarted = pulling
    };
    Check(FishingRecovery.Decide(10, 10, 0, Open(false, false, 0.3f, false)) == FishingRecovery.Step.Wait,
        "a moving minigame is left alone");
    Check(FishingRecovery.Decide(FishingRecovery.FadeInGraceTicks, FishingRecovery.StallTicks, 0, Open(false, false, 0.3f, false)) == FishingRecovery.Step.Wait,
        "stall during the fade-in grace does not abort");
    Check(FishingRecovery.Decide(FishingRecovery.FadeInGraceTicks + 1, FishingRecovery.StallTicks, 0, Open(false, false, 0.3f, false)) == FishingRecovery.Step.Escape,
        "progress that stops changing aborts as an escape");
    Check(FishingRecovery.Decide(FishingRecovery.MaxMinigameTicks, 0, 0, Open(false, false, 0.4f, false)) == FishingRecovery.Step.Escape,
        "the minigame has a hard tick cap even while progress changes");
    Check(FishingRecovery.Decide(100, 100, FishingRecovery.FadeOutGraceTicks - 1, Open(true, true, 1f, false)) == FishingRecovery.Step.Wait,
        "a normal catch fade-out is not cut short");
    Check(FishingRecovery.Decide(100, 100, FishingRecovery.FadeOutGraceTicks, Open(true, true, 1f, false)) == FishingRecovery.Step.AwardCatch,
        "a decided catch whose menu never closes is awarded once");
    Check(FishingRecovery.Decide(100, 100, FishingRecovery.FadeOutGraceTicks, Open(true, true, 1f, true)) == FishingRecovery.Step.CloseMenu,
        "a pull that already started only closes the menu");
    Check(FishingRecovery.Decide(100, 100, FishingRecovery.FadeOutGraceTicks, Open(true, true, 0f, false)) == FishingRecovery.Step.Escape,
        "a decided miss whose menu never closes does not award a fish");
    Check(FishingRecovery.Decide(100, 100, FishingRecovery.FadeOutGraceTicks, Open(true, false, 0.95f, false)) == FishingRecovery.Step.Escape,
        "a high progress bar the game has not accepted is not awarded");
    var closed = Open(true, true, 1f, false);
    closed.MenuOpen = false;
    Check(FishingRecovery.Decide(FishingRecovery.MaxMinigameTicks, FishingRecovery.StallTicks, FishingRecovery.FadeOutGraceTicks, closed) == FishingRecovery.Step.Wait,
        "a closed menu is not recovered again");

    Check(ShopLocations.RejectReason("FishShop", "Mountain", "Mountain") != null, "FishShop rejected on Mountain");
    Check(ShopLocations.RejectReason("FishShop", "Beach", "Beach") != null, "FishShop rejected on Beach");
    Check(ShopLocations.RejectReason("FishShop", "FishShop", "FishShop") == null, "FishShop allowed inside FishShop");
    Check(ShopLocations.RejectReason("FishShop", null, null) != null, "FishShop rejected when location is unknown");
    Check(ShopLocations.RejectReason("Carpenter", "ScienceHouse", "ScienceHouse") == null, "Carpenter allowed in ScienceHouse");
    Check(ShopLocations.RejectReason("Carpenter", "FishShop", "FishShop") != null, "Carpenter rejected in FishShop");
    Check(ShopLocations.RejectReason("AdventureShop", "AdventureGuild", "AdventureGuild") == null, "AdventureShop allowed in the guild");
    Check(ShopLocations.RejectReason("AdventureShop", "Mountain", "Mountain") != null, "AdventureShop rejected on Mountain");
    Check(ShopLocations.RejectReason("Saloon", "Town", "Town") != null, "Saloon rejected outdoors in Town");
    Check(ShopLocations.RejectReason("Saloon", "Saloon", "Saloon") == null, "Saloon allowed inside Saloon");
    Check(ShopLocations.RejectReason("Joja", "JojaMart", "JojaMart") == null, "Joja allowed in JojaMart");
    Check(ShopLocations.RejectReason("NotAShop", "Farm", "Farm") != null, "unknown shop rejected");
    Check(ShopLocations.MenuMismatch("FishShop", "FishShop") == null, "FishShop menu matches the request");
    Check(ShopLocations.MenuMismatch("FishShop", "SeedShop") != null, "FishShop request rejects a SeedShop menu");
    Check(ShopLocations.MenuMismatch("AdventureGuild", "AdventureShop") == null, "AdventureGuild alias matches the AdventureShop menu");
    Check(ShopLocations.TryResolve("AdventureGuild", out string guild, out string guildMenu) && guild == "AdventureGuild" && guildMenu == "AdventureShop", "AdventureGuild resolves to the guild and the AdventureShop menu");
    Check(ShopLocations.ShopAt("FishShop") == "FishShop", "FishShop interior is the fish counter");
    Check(ShopLocations.ShopAt("Mountain") == null, "Mountain is not a shop counter");
    Check(ShopLocations.ShopAt("AdventureGuild") == "AdventureShop", "guild interior maps to the AdventureShop id");

    var earned = QueryRules.Achievement(0, "Greenhorn (15k)^Earn 15,000g^true^-1^18", true);
    Check((int)earned["id"] == 0 && (string)earned["description"] == "Earn 15,000g" && (bool)earned["completed"], "achievement fields come from the data string");
    var hidden = QueryRules.Achievement(44, "Perfection^Reach the summit.^false^-1^9", false);
    Check((bool)hidden["show_before_earned"] == false && (int)hidden["prerequisite"] == -1 && (bool)hidden["completed"] == false, "unearned achievement keeps the data flags");

    Check(QueryRules.FestivalActivity("spring13", new[] { "set-up LuauSoup here" }) == "soup", "LuauSoup in the festival data is soup even on another date");
    Check(QueryRules.FestivalActivity("summer11", new[] { "no soup token" }) == "start", "summer11 without LuauSoup is not guessed");
    Check(QueryRules.FestivalActivity("spring24", Array.Empty<string>()) == "dance", "spring24 asset is the flower dance");
    Check(QueryRules.FestivalActivity("fall16", new[] { "Stardew Valley Fair" }) == "grange", "fall16 asset is the grange");
    Check(QueryRules.FestivalActivity("winter25", new[] { "Luau" }) == "start", "display text Luau is not the soup token");

    var asleep = QueryRules.AvailableTypes(new SceneFacts { WorldReady = false, OnFarm = true, CanFish = true });
    Check(asleep.Count == 0, "no actions before the world is ready");
    var cutscene = QueryRules.AvailableTypes(new SceneFacts { WorldReady = true, Cutscene = true, OnFarm = true });
    Check(cutscene.Count == 0, "a cutscene has no actions");
    var shop = QueryRules.AvailableTypes(new SceneFacts { WorldReady = true, Menu = "shop", OnFarm = true, CanFish = true });
    Check(shop.Contains("buy") && shop.Contains("close_menu") && !shop.Contains("fish") && !shop.Contains("mine"), "an open shop only offers shop actions");
    var festival = QueryRules.AvailableTypes(new SceneFacts { WorldReady = true, Festival = true, OnFarm = true });
    Check(festival.Contains("festival") && !festival.Contains("mine") && !festival.Contains("sleep"), "a festival does not offer the farm day");
    var farm = QueryRules.AvailableTypes(new SceneFacts { WorldReady = true, OnFarm = true, CanFish = true, HasKitchen = true, CanDonate = true, UnreadMail = 2, ShopCounter = false });
    Check(farm.Contains("water_crops") && farm.Contains("fish") && farm.Contains("cook") && farm.Contains("donate") && farm.Contains("check_mail") && farm.Contains("upgrade_tool") && !farm.Contains("open_shop") && !farm.Contains("leave_mine"), "farm scene includes travel and the live flags");
    var town = QueryRules.AvailableTypes(new SceneFacts { WorldReady = true, OnFarm = false, CanFish = false, HasKitchen = false, ShopCounter = true });
    Check(town.Contains("open_shop") && town.Contains("mine") && !town.Contains("water_crops") && !town.Contains("fish") && !town.Contains("cook"), "off the farm, water and fish wait for that scene");
    var mine = QueryRules.AvailableTypes(new SceneFacts { WorldReady = true, InMine = true, OnFarm = false, CanFish = false });
    Check(mine.Contains("leave_mine") && mine.Contains("fight") && !mine.Contains("sleep") && !mine.Contains("water_crops"), "the mine scene is the mine");

    var feast = new List<Dictionary<string, object>>
    {
        new() { ["in_days"] = 0, ["name"] = "Feast of the Winter Star", ["location"] = "Town", ["start"] = 900, ["end"] = 1400 }
    };
    string feastBlock = FestivalRoute.Block("CommunityCenter", 910, FestivalRoute.Windows(feast));
    Check(feastBlock != null && feastBlock.Contains("CommunityCenter"), "a Town festival removes the community center door");
    Check(FestivalRoute.Explain("no reachable route from Mountain to CommunityCenter (unreachable exits: mountain->town)", feastBlock) == "festival_map_limit", "failed Town exits during a festival are the festival map");
    Check(FestivalRoute.Block("CommunityCenter", 1500, FestivalRoute.Windows(feast)) == null, "after the festival the door is a normal route again");
    Check(FestivalRoute.Explain("no reachable route from Farm to WizardHouse", null) == "real_unreachable", "no exit list means the graph has no path");
    Check(FestivalRoute.Explain("no reachable route from Farm to Town (unreachable exits: farm->town)", null) == "exit_failed", "an exit that failed outside a festival is not a missing edge");
    Check(Presence.Classify(true, false, true, "Temp", null, 0) == "temporary_map", "a warp fade on Temp is still the temporary map");
    Check(Presence.Classify(true, false, false, "Temp", "DialogueBox", Presence.StuckTicks) == "waiting_dialogue", "an open dialogue is not a stuck map");
    Check(Presence.Classify(true, true, false, "Temp", null, Presence.StuckTicks) == "legal_festival", "a festival event is not skipped and is not stuck");
    Check(Presence.Classify(true, false, false, "Town", null, 0) == "legal_cutscene", "a normal event is a cutscene");
    Check(Presence.Classify(true, false, false, "Temp", null, Presence.StuckTicks - 1) == "temporary_map", "Temp is not stuck before the age threshold");
    Check(Presence.Classify(true, false, false, "Temp", null, Presence.StuckTicks) == "stuck", "Temp with no event and no dialogue is stuck");
    Check(Presence.ShouldWarpHome("stuck") && !Presence.ShouldWarpHome("legal_festival") && !Presence.ShouldWarpHome("temporary_map"), "only a confirmed stuck map warps home");
    Check(ItemMatch.IsExact("Quartz", "Quartz", "Quartz", "80", "(O)80"), "Quartz matches its own name and id");
    Check(!ItemMatch.IsExact("Quartz", "Refined Quartz", "Refined Quartz", "338", "(O)338"), "Refined Quartz is not Quartz");
    Check(ItemMatch.IsExact("80", "Quartz", "Quartz", "80", "(O)80"), "an item id matches that item only");
    Check(!ItemMatch.IsExact("80", "Refined Quartz", "Refined Quartz", "338", "(O)338"), "Quartz's id does not match Refined Quartz");

    Console.WriteLine($"{checks} protocol checks passed.");
}
finally
{
    // This random test directory was created above; never delete outside it.
    if (Path.GetDirectoryName(Path.GetFullPath(directory)) != testRoot)
        throw new Exception("test directory escaped workspace");
    Directory.Delete(directory, recursive: true);
}
