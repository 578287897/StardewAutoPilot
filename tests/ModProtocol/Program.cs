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
    Console.WriteLine($"{checks} protocol checks passed.");
}
finally
{
    // This random test directory was created above; never delete outside it.
    if (Path.GetDirectoryName(Path.GetFullPath(directory)) != testRoot)
        throw new Exception("test directory escaped workspace");
    Directory.Delete(directory, recursive: true);
}
