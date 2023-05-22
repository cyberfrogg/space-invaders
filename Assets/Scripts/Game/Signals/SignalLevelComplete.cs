using Libs.Analytics;

namespace Game.Signals
{
    public readonly struct SignalLevelComplete : ISignalAnalytic
    {
        public readonly int Level;
        public readonly int TimeSpent;

        public SignalLevelComplete(int level, int timeSpent)
        {
            Level = level;
            TimeSpent = timeSpent;
        }
    }
}