using Game.Services.SceneLoading;
using Zenject;

namespace Splash
{
	public class SplashManager : IInitializable
	{
		private readonly ISceneLoadingManager _sceneLoadingManager;

		public SplashManager(
			ISceneLoadingManager sceneLoadingManager
		)
		{
			_sceneLoadingManager = sceneLoadingManager;
		}

		public void Initialize()
		{
			LoadGame();
		}

		
		private void LoadGame()
		{
			_sceneLoadingManager.LoadGameFromSplash();
		}
	}
}