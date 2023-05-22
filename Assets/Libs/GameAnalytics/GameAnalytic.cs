using System.Collections.Generic;
using Libs.Analytics;
using Zenject;

namespace Libs.GameAnalytics
{
    public class GameAnalytic : AbstractAnalytic
    {
        public GameAnalytic(IList<IAnalyticable> analyticables, SignalBus signalBus, DiContainer diContainer) 
            : base(analyticables, signalBus, diContainer)
        {

        }
    }
}