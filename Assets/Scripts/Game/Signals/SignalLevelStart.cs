using Libs.Analytics;

namespace Game.Signals
{
    public readonly struct SignalLevelStart : ISignalAnalytic
    {
        public readonly int Level;

        public SignalLevelStart(int level)
        {
            Level = level;
        }
    }
}