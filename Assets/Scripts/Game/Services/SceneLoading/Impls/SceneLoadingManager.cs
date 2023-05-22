using Game.Services.SceneLoading.Game.SceneLoading;
using Game.Services.SceneLoading.Processors;
using PdUtils.SceneLoadingProcessor.Impls;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Services.SceneLoading.Impls
{
	public class SceneLoadingManager : ISceneLoadingManager
	{
		private readonly SignalBus _signalBus;

		private LoadingProcessor _processor;

		public SceneLoadingManager(
			SignalBus signalBus
		)
		{
			_signalBus = signalBus;
		}

		public void LoadGameFromSplash()
		{
			_processor = new LoadingProcessor();
			_processor.AddProcess(new OpenLoadingWindowProcess(_signalBus))
				.AddProcess(new LoadingProcess(SceneNames.GAME, LoadSceneMode.Additive))
				.AddProcess(new SetActiveSceneProcess(SceneNames.GAME))
				.AddProcess(new UnloadProcess(SceneNames.SPLASH))
				.AddProcess(new RunContextProcess("GameContext"))
				.AddProcess(new WaitUpdateProcess(4))
				.AddProcess(new ProjectWindowBack(_signalBus))
				.DoProcess();
		}
		

		public float GetProgress() => _processor?.Progress ?? 0f;
		
	}
}