using Zenject;

namespace Libs.GameAnalytics
{
	public class GameAnalyticServiceInstaller
	{
		public static void Install(DiContainer container)
		{
			container.BindInitializableExecutionOrder<GameAnalyticInitializer>(-10);
			container.BindInterfacesAndSelfTo<GameAnalytic>().AsSingle().NonLazy();
			container.BindInterfacesAndSelfTo<GameAnalyticInitializer>().AsSingle().NonLazy();
		}
	}
}