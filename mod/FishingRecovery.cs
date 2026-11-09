namespace StardewAutoPilot
{
    /// <summary>
    /// Decides what to do when the fishing minigame menu stays up. Pure so it can be tested
    /// without the game: the runner applies the step once, then checks the rod before any
    /// second catch or bait consumption.
    /// </summary>
    internal static class FishingRecovery
    {
        public const int FadeInGraceTicks = 30;
        public const int StallTicks = 300;          // no progress change, ~5s at 60fps
        public const int MaxMinigameTicks = 45 * 60;
        public const int FadeOutGraceTicks = 180;   // shake + perfect text + fade, ~3s at 60fps
        public const float CatchProgress = 0.9f;

        public enum Step
        {
            Wait,
            Escape,
            AwardCatch,
            CloseMenu
        }

        public struct Sample
        {
            public bool MenuOpen;
            public bool FadeOut;
            public bool ResultHandled;
            public float Progress;
            public bool PullStarted;
        }

        public static Step Decide(int ticksOpen, int ticksWithoutProgress, int fadeOutTicks, Sample sample)
        {
            if (!sample.MenuOpen)
                return Step.Wait;
            if (sample.FadeOut)
            {
                if (fadeOutTicks < FadeOutGraceTicks)
                    return Step.Wait;
                // The game already started the catch animation. Closing again must not award twice.
                if (sample.PullStarted)
                    return Step.CloseMenu;
                if (sample.ResultHandled && sample.Progress > CatchProgress)
                    return Step.AwardCatch;
                return Step.Escape;
            }
            if (ticksOpen >= MaxMinigameTicks)
                return Step.Escape;
            if (ticksOpen > FadeInGraceTicks && ticksWithoutProgress >= StallTicks)
                return Step.Escape;
            return Step.Wait;
        }
    }
}
