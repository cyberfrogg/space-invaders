using Game.Services.SceneLoading;
using Project.Ui.Loading.Views;
using SimpleUi.Abstracts;
using UnityEngine;
using Zenject;

namespace Project.Ui.Loading.Controllers
{
	public class LoadingController : UiController<LoadingView>, ITickable
	{
		private readonly ISceneLoadingManager _sceneLoadingManager;

		public LoadingController(ISceneLoadingManager sceneLoadingManager)
		{
			_sceneLoadingManager = sceneLoadingManager;
		}

		public void Tick()
		{
			View.TextLoading.text = Mathf.RoundToInt(_sceneLoadingManager.GetProgress() * 100) + "% loaded";
		}
	}
}