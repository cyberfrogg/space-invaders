using Libs.Analytics;

namespace Game.Signals
{
    public readonly struct SignalLevelRestart : ISignalAnalytic
    {
        public readonly int Level;

        public SignalLevelRestart(int level)
        {
            Level = level;
        }
    }
}