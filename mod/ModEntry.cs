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
            this.Runner = new ActionRunner(this);
            this.Menus = new MenuAutomation(this);

            helper.Events.GameLoop.UpdateTicked += this.OnUpdateTicked;
            helper.Events.GameLoop.DayStarted += (_, _) =>
            {
                // DayStarted fires only after the night (and its save) is complete: until then the world isn't "ready"
                this.DayStartedFor = Game1.Date.TotalDays;
                this.Log.Add("day", $"New day: {Game1.currentSeason} {Game1.dayOfMonth}, year {Game1.year}");
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
            }
            catch (Exception ex)
            {
                this.Monitor.Log($"Failed to start HTTP server on port {this.Config.Port}: {ex.Message}", LogLevel.Error);
            }
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
