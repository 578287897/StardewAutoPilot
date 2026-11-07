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
}
finally
{
    // This random test directory was created above; never delete outside it.
    if (Path.GetDirectoryName(Path.GetFullPath(directory)) != testRoot)
        throw new Exception("test directory escaped workspace");
    Directory.Delete(directory, recursive: true);
}
