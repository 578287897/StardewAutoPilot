namespace StardewAutoPilot
{
    public class ModConfig
    {
        /// <summary>Local HTTP port the agent connects to (http://localhost:PORT/).</summary>
        public int Port { get; set; } = 8765;

        /// <summary>Freeze the in-game clock while the agent is connected but no action is running (i.e. while the LLM is thinking).</summary>
        public bool FreezeTimeWhileAgentThinks { get; set; } = true;

        /// <summary>Click through non-question dialogue automatically (text is still logged to /messages).</summary>
        public bool AutoAdvanceDialogue { get; set; } = true;

        /// <summary>Skip skippable cutscenes automatically.</summary>
        public bool AutoSkipEvents { get; set; } = true;

        /// <summary>Confirm the shipping summary and non-profession level-up screens at night.</summary>
        public bool AutoConfirmEndOfDayMenus { get; set; } = true;

        /// <summary>Keep the game running when its window loses focus while an agent is connected.</summary>
        public bool DisablePauseWhenUnfocused { get; set; } = true;

        /// <summary>Once the agent has played this session, pause the clock while it is disconnected (crash, stopped, network), so days don't pass unattended.</summary>
        public bool PauseWhenAgentDisconnects { get; set; } = true;

        /// <summary>The agent counts as connected if it made a request within this many seconds.</summary>
        public int AgentTimeoutSeconds { get; set; } = 60;
    }
}
