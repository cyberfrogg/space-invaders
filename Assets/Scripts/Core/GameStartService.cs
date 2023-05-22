using System;
using System.Collections.Generic;
using Facebook.Unity;
using GameAnalyticsSDK;
using PdUtils.FirstStartService;
using PdUtils.PlayerPrefs;
using UnityEngine;
using Zenject;

namespace Core
{
    public interface IGameStartService
    {
        int DaysSinceReg { get; }
    }
    
    public class GameStartService : IGameStartService, IInitializable
    {
        private readonly IFirstStartService _firstStartService;
        private readonly IPlayerPrefsManager _playerPrefsManager;
        private readonly IYandexAppMetrica _yandexAppMetrica;

        public GameStartService(
            IFirstStartService firstStartService, 
            IPlayerPrefsManager playerPrefsManager, 
            IYandexAppMetrica yandexAppMetrica)
        {
            _firstStartService = firstStartService;
            _playerPrefsManager = playerPrefsManager;
            _yandexAppMetrica = yandexAppMetrica;
        }

        public void Initialize()
        {
            GameAnalytics.Initialize();
            
            _firstStartService.SaveFirstStart(() => {});
            var sessionNumber = _playerPrefsManager.GetValue(Plugins.GelfLogger.Impl.GelfLogger.SESSION_SAVE_KEY, 0) + 1;

            const string evt = "game_start";
            var parameters = new Dictionary<string, object>
            {
                {"count", sessionNumber}
            };
            
            _yandexAppMetrica.ReportEvent(evt, parameters);
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, evt, parameters);
            
            
            Debug.Log($"[{nameof(GameStartService)}] Start FB Init");
            if (!FB.IsInitialized) {
                // Initialize the Facebook SDK
                FB.Init(OnFbInitComplete, OnFbHideUnity);
            } else {
                // Already initialized, signal an app activation App Event
                FB.ActivateApp();
            }
        }

        private void OnFbInitComplete()
        {
            if (FB.IsInitialized) {
                var logMessage = $"OnFbInitCompleteCalled IsLoggedIn='{FB.IsLoggedIn}' IsInitialized='{FB.IsInitialized}'";
                Debug.Log($"[{nameof(GameStartService)}] {logMessage}");
                
                FB.ActivateApp();
            } else {
                Debug.LogError($"[{nameof(GameStartService)}] Failed to Initialize the Facebook SDK");
            }
        }
        
        private void OnFbHideUnity (bool isGameShown)
        {
            if (!isGameShown) {
                // Pause the game - we will need to hide
                Time.timeScale = 0;
            } else {
                // Resume the game - we're getting focus again
                Time.timeScale = 1;
            }
        }
        
        public int DaysSinceReg
        {
            get
            {
                var firstStartTimeUtc = _firstStartService.GetFirstStartTimeUtc();
                return firstStartTimeUtc.HasValue ? (DateTime.UtcNow - firstStartTimeUtc.Value).Days : 0;
            }
        }
    }
}