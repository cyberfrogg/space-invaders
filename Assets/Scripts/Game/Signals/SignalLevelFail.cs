using Core;
using Libs.Analytics;

namespace Game.Signals
{
    public struct SignalLevelFail : ISignalAnalytic
    {
        public readonly int Level;
        public readonly int TimeSpent;
        
        public GameResult.EFailReason? Reason;

        public SignalLevelFail(int level, int timeSpent) : this()
        {
            Level = level;
            TimeSpent = timeSpent;
        }
    }
}