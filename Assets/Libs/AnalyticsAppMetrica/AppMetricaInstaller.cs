using System.Collections.Generic;
using Core;
using Plugins.GelfLogger;
using UnityEngine;
using Zenject;

namespace Libs.AnalyticsAppMetrica
{
	public class AppMetricaInstaller : MonoInstaller
	{
		[SerializeField] private global::AppMetrica prefabIos;
		[SerializeField] private global::AppMetrica prefabAndroid;

		public override void InstallBindings()
		{
			if (PlatformUtils.IsIPhone())
			{
				Instantiate(prefabIos);
			}

			if (PlatformUtils.IsAndroid())
			{
				Instantiate(prefabAndroid);
			}

			Container.Bind<IYandexAppMetrica>().FromInstance(global::AppMetrica.Instance).AsSingle();
			// Container.Bind<LoggerSetAppMetricaId>().AsSingle().NonLazy();
		}

		private class LoggerSetAppMetricaId
		{
			private readonly IYandexAppMetrica _appMetrica;
			private readonly IGelfLogger _gelfLogger;

			public LoggerSetAppMetricaId(IYandexAppMetrica appMetrica, IGelfLogger gelfLogger)
			{
				_appMetrica = appMetrica;
				_gelfLogger = gelfLogger;

				appMetrica.RequestAppMetricaDeviceID(OnAppMetricaId);
			}

			private void OnAppMetricaId(string id, YandexAppMetricaRequestDeviceIDError? error)
			{
				if (error.HasValue)
				{
					Debug.LogError($"[{nameof(AppMetricaInstaller)}] {error}");
					return;
				}

				_appMetrica.ReportEvent("user", new Dictionary<string, object>
				{
					{ "device_id", id }
				});
				_gelfLogger.SetAppMetricaId(id);
			}
		}
	}
}