using System.Collections.Generic;
using Core;
using SimpleUi.Signals;
using Zenject;

namespace Libs.AnalyticsAppMetrica
{
    public class AppMetricaInitializer : IInitializable
    {
        private readonly AppMetrica _appMetrica;
        private readonly IYandexAppMetrica _yandexAppMetrica;
        private readonly IGameStartService _gameStartService;

        public AppMetricaInitializer(
            AppMetrica appMetrica,
            IYandexAppMetrica yandexAppMetrica,
            IGameStartService gameStartService)
        {
            _appMetrica = appMetrica;
            _yandexAppMetrica = yandexAppMetrica;
            _gameStartService = gameStartService;
        }

        public void Initialize()
        {
            _appMetrica
                .AddHandler(new AppMetricaEventHandler(_yandexAppMetrica, SendEventsBuffer,
                    _gameStartService.DaysSinceReg));

            _appMetrica.Init();
        }

        private static List<string> SendEventsBuffer =>
            new()
            {
                "level_start",
                "level_complete"
            };
    }
}