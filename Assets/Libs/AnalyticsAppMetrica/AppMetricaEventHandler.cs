using System.Collections.Generic;
using Libs.Analytics.EventHandler;
using UnityEngine;

namespace Libs.AnalyticsAppMetrica
{
    public class AppMetricaEventHandler : AEventHandler
    {
        private readonly IYandexAppMetrica _appMetrica;

        private readonly List<string> _sendEventsBuffer;
        private readonly int _daysSinceReg;

        public AppMetricaEventHandler(IYandexAppMetrica appMetrica, 
            List<string> sendEventsBuffer, 
            int daysSinceReg)
        {
            _appMetrica = appMetrica;
            _sendEventsBuffer = sendEventsBuffer;
            _daysSinceReg = daysSinceReg;
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

            _appMetrica.ReportEvent(evt, paramsBuffer);

            if (_sendEventsBuffer.Contains(evt))
            {
                _appMetrica.SendEventsBuffer();
            }
        }
    }
}