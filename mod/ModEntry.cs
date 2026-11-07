using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace StardewAutoPilot
{
    public class ModEntry : Mod
    {
        internal static ModEntry Instance;
        internal ModConfig Config;
        internal ActionRunner Runner;
        internal MenuAutomation Menus;
        internal readonly MessageLog Log = new MessageLog(300);
        internal DateTime LastAgentContact = DateTime.MinValue;
        internal int DayStartedFor = -1;  // Game1.Date.TotalDays of the last fully started day

        private readonly ConcurrentQueue<Action> mainThreadQueue = new ConcurrentQueue<Action>();
        private HttpServer server;
        private int frozenTimeInterval = -1;
        private bool agentEverConnected;
        private bool pausedNoticeShown;
        private readonly HashSet<HUDMessage> seenHud = new HashSet<HUDMessage>();

        public override void Entry(IModHelper helper)
        {
            Instance = this;
            this.Config = helper.ReadConfig<ModConfig>();
            WikiText.Load(helper.DirectoryPath);
            this.Monitor.Log($"Wiki text: {WikiText.Count} entries from wiki.txt", LogLevel.Trace);
            this.Runner = new ActionRunner(this);
            this.Menus = new MenuAutomation(this);

            helper.Events.GameLoop.UpdateTicked += this.OnUpdateTicked;
            helper.Events.GameLoop.GameLaunched += (_, _) => this.RegisterConfigMenu();
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            helper.Events.GameLoop.DayStarted += (_, _) =>
            {
                // DayStarted fires only after the night (and its save) is complete: until then the world isn't "ready"
                this.DayStartedFor = Game1.Date.TotalDays;
                this.Log.Add("day", $"New day: {Game1.currentSeason} {Game1.dayOfMonth}, year {Game1.year}");
                if (string.IsNullOrWhiteSpace(this.Config.ApiKey) || string.IsNullOrWhiteSpace(this.Config.ApiBaseUrl))
                    Game1.addHUDMessage(new HUDMessage($"AutoPilot：进档后按 {this.Config.OpenSettingsKey} 填写网关与 API Key", 2));
            };
            helper.Events.GameLoop.ReturnedToTitle += (_, _) => this.Runner.Cancel("returned to title");
            helper.Events.Display.MenuChanged += (_, e) =>
            {
                if (e.NewMenu != null)
                    this.Log.Add("menu", "Opened " + e.NewMenu.GetType().Name);
            };

            this.server = new HttpServer(this, this.Config.Port);
            try
            {
                this.server.Start();
                this.Monitor.Log($"AutoPilot API listening on http://localhost:{this.Config.Port}/", LogLevel.Info);
                this.Monitor.Log($"载入存档后按 {this.Config.OpenSettingsKey} 打开 LLM 网关/Key 设置（仅进档后可用）。", LogLevel.Info);
            }
            catch (Exception ex)
            {
                this.Monitor.Log($"Failed to start HTTP server on port {this.Config.Port}: {ex.Message}", LogLevel.Error);
            }
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button != this.Config.OpenSettingsKey)
                return;
            // Only after the player has loaded a save — never on the title screen (so AI can't rush config / auto-pick saves)
            if (!Context.IsWorldReady)
            {
                this.Helper.Input.Suppress(e.Button);
                return;
            }
            if (Game1.activeClickableMenu is LlmSettingsMenu)
                return;
            if (Game1.activeClickableMenu != null || !Context.IsPlayerFree)
                return;
            this.Helper.Input.Suppress(e.Button);
            Game1.activeClickableMenu = new LlmSettingsMenu(this, null);
        }

        private void RegisterConfigMenu()
        {
            var gmcm = this.Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (gmcm == null)
                return;
            gmcm.Register(this.ModManifest, () => this.Config = new ModConfig(), () => this.Helper.WriteConfig(this.Config));
            gmcm.AddSectionTitle(this.ModManifest, () => "LLM 网关");
            gmcm.AddParagraph(this.ModManifest, () => "请先手动选档进入游戏，再按设置键或在此填写。代理默认不会在标题界面自动建档/读档。");
            gmcm.AddTextOption(this.ModManifest, () => this.Config.ApiBaseUrl, v => this.Config.ApiBaseUrl = v, () => "网关 base_url", () => "OpenAI 兼容地址，例如 https://api.deepseek.com/v1");
            gmcm.AddTextOption(this.ModManifest, () => this.Config.Model, v => this.Config.Model = v, () => "模型 model", () => "例如 deepseek-chat");
            gmcm.AddTextOption(this.ModManifest, () => this.Config.ApiKey, v => this.Config.ApiKey = v, () => "API Key", () => "写入本机 Mods/.../config.json，不会上传");
            gmcm.AddTextOption(this.ModManifest, () => this.Config.ReviewModel, v => this.Config.ReviewModel = v, () => "复盘模型（可空）", () => "夜间复盘用；留空则与主模型相同");
            gmcm.AddKeybind(this.ModManifest, () => this.Config.OpenSettingsKey, v => this.Config.OpenSettingsKey = v, () => "打开内置设置界面", () => "仅进档后可用（默认 F8）");
            gmcm.AddSectionTitle(this.ModManifest, () => "模组 / 代理");
            gmcm.AddNumberOption(this.ModManifest, () => this.Config.Port, v => this.Config.Port = v, () => "HTTP 端口", () => "改完需重启游戏", 1024, 65535);
            gmcm.AddTextOption(this.ModManifest, () => this.Config.ApiToken, v => this.Config.ApiToken = v, () => "可选 ApiToken", () => "非空时代理请求需带 Authorization Bearer");
            gmcm.AddBoolOption(this.ModManifest, () => this.Config.FreezeTimeWhileAgentThinks, v => this.Config.FreezeTimeWhileAgentThinks = v, () => "思考时冻结时间");
            gmcm.AddBoolOption(this.ModManifest, () => this.Config.AutoAdvanceDialogue, v => this.Config.AutoAdvanceDialogue = v, () => "自动点对话");
            gmcm.AddBoolOption(this.ModManifest, () => this.Config.AutoSkipEvents, v => this.Config.AutoSkipEvents = v, () => "自动跳过可跳过过场");
            gmcm.AddBoolOption(this.ModManifest, () => this.Config.PauseWhenAgentDisconnects, v => this.Config.PauseWhenAgentDisconnects = v, () => "代理断开时暂停");
            gmcm.AddBoolOption(this.ModManifest, () => this.Config.LlmDecidesGameRestart, v => this.Config.LlmDecidesGameRestart = v, () => "卡住时由模型决定是否重启", () => "用上面的模型判断。重启会读回上一夜的存档，今天没存的进度会丢。");
            this.Monitor.Log("Registered with Generic Mod Config Menu.", LogLevel.Trace);
        }

        // a long-running action (fishing, mining) means the agent is waiting on us, not gone
        internal bool AgentConnected => this.Runner.Busy || (DateTime.UtcNow - this.LastAgentContact).TotalSeconds < this.Config.AgentTimeoutSeconds;

        /// <summary>Run a function on the game thread and wait for the result.</summary>
        internal Task<T> OnMainThread<T>(Func<T> func)
        {
            var tcs = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);
            this.mainThreadQueue.Enqueue(() =>
            {
                try { tcs.SetResult(func()); }
                catch (Exception ex) { tcs.SetException(ex); }
            });
            return tcs.Task;
        }

        private void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            while (this.mainThreadQueue.TryDequeue(out var action))
                action();

            if (!Context.IsWorldReady)
                return;

            this.CaptureHudMessages();
            this.Runner.Tick();
            Fishing.Tick();
            this.Menus.Tick(e.Ticks);

            bool connected = this.AgentConnected;
            if (connected && this.Config.DisablePauseWhenUnfocused && Game1.options.pauseWhenOutOfFocus)
            {
                Game1.options.pauseWhenOutOfFocus = false;
                this.Monitor.Log("Agent connected: disabled 'pause when window inactive'.", LogLevel.Info);
            }

            // freeze the clock while the agent is thinking (connected, no action running)
            if (connected)
            {
                this.agentEverConnected = true;
                this.pausedNoticeShown = false;
            }
            bool agentLost = this.Config.PauseWhenAgentDisconnects && this.agentEverConnected && !connected;
            if (agentLost && !this.pausedNoticeShown)
            {
                this.pausedNoticeShown = true;
                Game1.addHUDMessage(new HUDMessage("AutoPilot 已暂停：AI 代理未连接（时间已冻结）", HUDMessage.error_type));
                this.Monitor.Log("Agent disconnected: game clock paused until it reconnects.", LogLevel.Info);
            }
            bool freeze = (this.Config.FreezeTimeWhileAgentThinks && connected && !this.Runner.Busy || agentLost) && Context.IsPlayerFree;
            if (freeze)
            {
                if (this.frozenTimeInterval < 0)
                    this.frozenTimeInterval = Game1.gameTimeInterval;
                Game1.gameTimeInterval = this.frozenTimeInterval;
            }
            else
                this.frozenTimeInterval = -1;
        }

        private void CaptureHudMessages()
        {
            var current = Game1.hudMessages.ToList();
            foreach (var msg in current)
            {
                if (this.seenHud.Add(msg) && !string.IsNullOrWhiteSpace(msg.message))
                    this.Log.Add("hud", msg.message);
            }
            this.seenHud.RemoveWhere(m => !current.Contains(m));
        }
    }

    /// <summary>Ring buffer of game messages (HUD, dialogue, menus) with increasing sequence numbers.</summary>
    internal class MessageLog
    {
        private readonly int capacity;
        private readonly LinkedList<Dictionary<string, object>> entries = new LinkedList<Dictionary<string, object>>();
        private long seq;

        public MessageLog(int capacity) { this.capacity = capacity; }

        public void Add(string kind, string text)
        {
            lock (this.entries)
            {
                this.entries.AddLast(new Dictionary<string, object>
                {
                    ["seq"] = ++this.seq,
                    ["kind"] = kind,
                    ["text"] = text,
                    ["time"] = Game1.timeOfDay,
                    ["day"] = Game1.dayOfMonth
                });
                while (this.entries.Count > this.capacity)
                    this.entries.RemoveFirst();
            }
        }

        public List<Dictionary<string, object>> Since(long since, int max = 50)
        {
            lock (this.entries)
                return this.entries.Where(e => (long)e["seq"] > since).TakeLast(max).ToList();
        }

        public long LastSeq { get { lock (this.entries) return this.seq; } }
    }
}
