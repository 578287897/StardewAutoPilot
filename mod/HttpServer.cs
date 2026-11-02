using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StardewModdingAPI;
using StardewValley;

namespace StardewAutoPilot
{
    /// <summary>
    /// Minimal local JSON API.
    ///   GET  /ping                 health check
    ///   GET  /state                time, player, inventory, menu, current job, exits
    ///   GET  /map?radius=10        ASCII map around the player + legend
    ///   GET  /crops?location=Farm  crop summary (needs water / ready / growing)
    ///   GET  /messages?since=N     HUD / dialogue / menu log
    ///   POST /act   {type,...}     run one action and wait until it finishes
    ///   POST /cancel               cancel the running action
    /// </summary>
    internal class HttpServer
    {
        private readonly ModEntry mod;
        private readonly HttpListener listener = new HttpListener();
        private static readonly JsonSerializerOptions JsonOpts = new JsonSerializerOptions { WriteIndented = false };

        public HttpServer(ModEntry mod, int port)
        {
            this.mod = mod;
            this.listener.Prefixes.Add($"http://localhost:{port}/");
        }

        public void Start()
        {
            this.listener.Start();
            Task.Run(this.Loop);
        }

        private async Task Loop()
        {
            while (this.listener.IsListening)
            {
                HttpListenerContext ctx;
                try { ctx = await this.listener.GetContextAsync(); }
                catch { break; }
                _ = Task.Run(() => this.Handle(ctx));
            }
        }

        private async Task Handle(HttpListenerContext ctx)
        {
            object result;
            int status = 200;
            try
            {
                this.mod.LastAgentContact = DateTime.UtcNow;
                string path = ctx.Request.Url.AbsolutePath.TrimEnd('/').ToLowerInvariant();
                var q = ctx.Request.QueryString;
                switch (path)
                {
                    case "/ping":
                        result = await this.mod.OnMainThread(() => (object)new Dictionary<string, object>
                        {
                            ["ok"] = true,
                            ["mod"] = "StardewAutoPilot",
                            ["world_ready"] = Context.IsWorldReady
                        });
                        break;
                    case "/state":
                        result = await this.mod.OnMainThread(() => (object)StateReader.GetState(this.mod));
                        break;
                    case "/map":
                        int radius = int.TryParse(q["radius"], out var r) ? Math.Clamp(r, 3, 40) : 10;
                        result = await this.mod.OnMainThread(() => (object)StateReader.GetMap(radius));
                        break;
                    case "/crops":
                        string loc = q["location"];
                        result = await this.mod.OnMainThread(() => (object)StateReader.GetCrops(loc));
                        break;
                    case "/tile":
                        int tx = int.Parse(q["x"]), ty = int.Parse(q["y"]);
                        result = await this.mod.OnMainThread(() => (object)StateReader.GetTile(tx, ty));
                        break;
                    case "/items":
                        var ids = (q["ids"] ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                        result = await this.mod.OnMainThread(() => (object)ids.Select(id => ItemInfo.Describe(id)).ToList());
                        break;
                    case "/new_game":
                        string pname = q["name"] ?? "AutoPilot", fname = q["farm"] ?? "AI", fav = q["favorite"] ?? "Parsnips";
                        int farmType = int.TryParse(q["farm_type"], out var ft) ? ft : 0;
                        result = await this.mod.OnMainThread(() =>
                        {
                            if (Context.IsWorldReady)
                                return (object)new { ok = false, message = "a save is already loaded" };
                            if (Game1.activeClickableMenu is not StardewValley.Menus.TitleMenu title)
                                return new { ok = false, message = "not on the title screen" };
                            // same steps as the title menu's New button + character creator OK (with 'skip intro')
                            Game1.resetPlayer();
                            Game1.whichFarm = farmType;
                            Game1.startingCabins = 0;
                            Game1.multiplayerMode = 0;
                            Game1.player.Name = pname;
                            Game1.player.displayName = pname;
                            Game1.player.farmName.Value = fname;
                            Game1.player.favoriteThing.Value = fav;
                            Game1.player.isCustomized.Value = true;
                            Game1.player.ConvertClothingOverrideToClothesItems();
                            title.createdNewCharacter(true);
                            return new { ok = true, message = $"creating new game: {pname} / {fname} farm (type {farmType})" };
                        });
                        break;
                    case "/plot_check":
                    case "/find_plot":
                        bool find = path == "/find_plot";
                        int px = int.TryParse(q["x"], out var qx) ? qx : 0, py = int.TryParse(q["y"], out var qy) ? qy : 0;
                        int pw = int.TryParse(q["w"], out var qw) ? Math.Clamp(qw, 1, 30) : 6, ph = int.TryParse(q["h"], out var qh) ? Math.Clamp(qh, 1, 30) : 4;
                        string plotLoc = q["location"] ?? "Farm";
                        result = await this.mod.OnMainThread(() =>
                        {
                            var l = Game1.getLocationFromName(plotLoc);
                            if (l == null)
                                return (object)new { ok = false, message = "unknown location " + plotLoc };
                            return find
                                ? Plots.Find(l, pw, ph, new Microsoft.Xna.Framework.Point(px, py))
                                : Plots.Check(l, new Microsoft.Xna.Framework.Rectangle(px, py, pw, ph));
                        });
                        break;
                    case "/recipes":
                        bool cooking = q["cooking"] == "1" || q["cooking"] == "true";
                        result = await this.mod.OnMainThread(() => Context.IsWorldReady ? (object)Crafting.Recipes(cooking) : new { ok = false, message = "world not ready" });
                        break;
                    case "/social":
                        result = await this.mod.OnMainThread(() => Context.IsWorldReady ? (object)Social.Overview() : new { ok = false, message = "world not ready" });
                        break;
                    case "/bundles":
                        result = await this.mod.OnMainThread(() => Context.IsWorldReady ? (object)Bundles.Status() : new { ok = false, message = "world not ready" });
                        break;
                    case "/farm_grid":
                        result = await this.mod.OnMainThread(() => Context.IsWorldReady ? (object)FarmGrid.Get() : new { ok = false, message = "world not ready" });
                        break;
                    case "/crop_data":
                        result = await this.mod.OnMainThread(() => Context.IsWorldReady ? (object)GameData.Crops() : new { ok = false, message = "world not ready" });
                        break;
                    case "/progress":
                        result = await this.mod.OnMainThread(() => Context.IsWorldReady ? (object)Progress.Status() : new { ok = false, message = "world not ready" });
                        break;
                    case "/ranch":
                        result = await this.mod.OnMainThread(() => Context.IsWorldReady ? (object)Ranch.Status() : new { ok = false, message = "world not ready" });
                        break;
                    case "/building_sites":
                        string btype = q["type"] ?? "Coop";
                        int nx = int.TryParse(q["x"], out var bx) ? bx : 64, ny = int.TryParse(q["y"], out var by) ? by : 15;
                        result = await this.mod.OnMainThread(() => Context.IsWorldReady ? (object)Ranch.FindSites(btype, new Microsoft.Xna.Framework.Point(nx, ny)) : new { ok = false });
                        break;
                    case "/saves":
                        result = new { saves = Directory.Exists(Constants.SavesPath) ? Directory.GetDirectories(Constants.SavesPath).Select(Path.GetFileName).ToArray() : Array.Empty<string>() };
                        break;
                    case "/load_save":
                        string save = q["name"];
                        result = await this.mod.OnMainThread(() =>
                        {
                            if (Context.IsWorldReady)
                                return (object)new { ok = false, message = "a save is already loaded" };
                            if (!(Game1.activeClickableMenu is StardewValley.Menus.TitleMenu))
                                return new { ok = false, message = "not on the title screen" };
                            if (string.IsNullOrEmpty(save) || !Directory.Exists(Path.Combine(Constants.SavesPath, save)))
                                return new { ok = false, message = "unknown save " + save };
                            StardewValley.SaveGame.Load(save);
                            Game1.exitActiveMenu();
                            return new { ok = true, message = "loading " + save };
                        });
                        break;
                    case "/messages":
                        long since = long.TryParse(q["since"], out var s) ? s : 0;
                        result = new Dictionary<string, object> { ["last_seq"] = this.mod.Log.LastSeq, ["messages"] = this.mod.Log.Since(since) };
                        break;
                    case "/act":
                        string body;
                        using (var reader = new StreamReader(ctx.Request.InputStream, Encoding.UTF8))
                            body = await reader.ReadToEndAsync();
                        var args = JsonDocument.Parse(string.IsNullOrWhiteSpace(body) ? "{}" : body).RootElement.Clone();
                        var job = await this.mod.OnMainThread(() => this.mod.Runner.Start(args));
                        var done = await Task.WhenAny(job, Task.Delay(TimeSpan.FromMinutes(5)));
                        if (done != job)
                        {
                            await this.mod.OnMainThread(() => { this.mod.Runner.Cancel("HTTP timeout"); return 0; });
                            result = ActionRunner.Fail("action timed out after 5 minutes");
                        }
                        else
                            result = job.Result;
                        break;
                    case "/cancel":
                        result = await this.mod.OnMainThread(() => { this.mod.Runner.Cancel("cancelled by agent"); return (object)new { ok = true }; });
                        break;
                    default:
                        status = 404;
                        result = new { ok = false, message = "unknown endpoint " + path };
                        break;
                }
            }
            catch (Exception ex)
            {
                status = 500;
                result = new { ok = false, message = ex.GetType().Name + ": " + ex.Message };
                this.mod.Monitor.Log("HTTP error: " + ex, LogLevel.Trace);
            }

            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(result, JsonOpts));
                ctx.Response.StatusCode = status;
                ctx.Response.ContentType = "application/json; charset=utf-8";
                ctx.Response.ContentLength64 = bytes.Length;
                await ctx.Response.OutputStream.WriteAsync(bytes, 0, bytes.Length);
                ctx.Response.Close();
            }
            catch { /* client went away */ }
        }
    }
}
