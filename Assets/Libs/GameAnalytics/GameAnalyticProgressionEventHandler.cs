using System.Collections.Generic;
using GameAnalyticsSDK;
using Libs.Analytics.EventHandler;
using UnityEngine;

namespace Libs.GameAnalytics
{
    public class GameAnalyticProgressionEventHandler : AEventHandler
    {
        private readonly int _daysSinceReg;
        private readonly List<string> _startEvents;
        private readonly List<string> _completeEvents;
        private readonly List<string> _failEvents;

        public GameAnalyticProgressionEventHandler(
            int daysSinceReg,
            List<string> startEvents,
            List<string> completeEvents,
            List<string> failEvents)
        {
            _daysSinceReg = daysSinceReg;
            _startEvents = startEvents;
            _completeEvents = completeEvents;
            _failEvents = failEvents;
        }

        protected override void SendEvent(string evt, Dictionary<string, object> paramsBuffer)
        {
            Debug.Log("[App Metrica] Send event: " + evt);
            if (paramsBuffer == null)
            {
                paramsBuffer = new Dictionary<string, object>();
            }
            else
            {
                foreach (var param in paramsBuffer)
                {
                    Debug.Log("Param, key: " + param.Key + ", value: " + param.Value);
                }
            }
            
            paramsBuffer.Add("days since reg", _daysSinceReg);

            var status = GAProgressionStatus.Undefined;
            if (_startEvents.Contains(evt))
            {
                status = GAProgressionStatus.Start;
            }
            if (_completeEvents.Contains(evt))
            {
                status = GAProgressionStatus.Complete;
            }
            if (_failEvents.Contains(evt))
            {
                status = GAProgressionStatus.Fail;
            }
            
            GameAnalyticsSDK.GameAnalytics.NewProgressionEvent(status, evt, paramsBuffer);
        }
    }
}