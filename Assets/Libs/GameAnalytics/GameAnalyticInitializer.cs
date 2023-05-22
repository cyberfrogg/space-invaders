using System.Collections.Generic;
using Core;
using Zenject;

namespace Libs.GameAnalytics
{
    public class GameAnalyticInitializer : IInitializable
    {
        private readonly GameAnalytic _gameAnalytic;
        private readonly IGameStartService _gameStartService;

        public GameAnalyticInitializer(
            GameAnalytic gameAnalytic,
            IGameStartService gameStartService)
        {
            _gameAnalytic = gameAnalytic;
            _gameStartService = gameStartService;
        }

        public void Initialize()
        {
            _gameAnalytic
                .AddHandler(new GameAnalyticProgressionEventHandler(_gameStartService.DaysSinceReg, 
                        StartEvents, CompleteEvents, FailEvents));

            _gameAnalytic.Init();
        }

        private static List<string> StartEvents =>
            new()
            {
                "level_start",
            };
        
        private static List<string> CompleteEvents =>
            new()
            {
                "level_complete"
            };
        
        private static List<string> FailEvents =>
            new()
            {
                "level_fail",
            };
        
    }
}