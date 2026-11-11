namespace StardewAutoPilot
{
    /// <summary>
    /// A festival temporary map does not end on its own, and the game does not advance
    /// <c>Game1.timeOfDay</c> while that event is up. These decisions stay free of the game
    /// so the protocol tests can cover the Winter Star freeze.
    /// </summary>
    internal static class FestivalHold
    {
        /// <summary>MenuAutomation counts once per 20 ticks. 60 is about 20 seconds.</summary>
        public const int StrandedTicks = 60;

        /// <summary>A playable festival may be between two actions. 270 is about 90 seconds.</summary>
        public const int IdleFestivalTicks = 270;

        /// <summary>Wait yields once per tick. 180 is about 3 seconds at 60fps.</summary>
        public const int WaitGiveUpTicks = 180;

        public static int LeaveAfter(bool playable) => playable ? IdleFestivalTicks : StrandedTicks;

        /// <summary>
        /// True when the player is on the festival Temp map and nobody is driving an action.
        /// A story cutscene that is not a festival and is not stuck in a warp is left to the
        /// existing force-skip. A festival, or a warp that never clears, will not end itself.
        /// </summary>
        public static bool ShouldLeave(bool onTemp, bool eventUp, bool festival, bool warping, bool playable, bool runnerBusy, int age)
        {
            if (!onTemp || !eventUp || runnerBusy)
                return false;
            if (!festival && !warping)
                return false;
            return age >= LeaveAfter(playable);
        }

        /// <summary>The ten-minute clock does not move during an event or on the Temp map.</summary>
        public static bool ClockCanAdvance(bool eventUp, bool onTemp) => !eventUp && !onTemp;

        /// <summary>
        /// Thinking may pin <c>gameTimeInterval</c> only while the game itself would let time pass.
        /// Pinning during an event keeps the clock stopped after the event ends and the agent is still idle.
        /// </summary>
        public static bool PinClock(bool eventUp, bool festival, bool onTemp, bool wantFreeze)
        {
            if (!wantFreeze || eventUp || festival || onTemp)
                return false;
            return true;
        }
    }
}
