using System;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using Utils.Tools;

namespace BuildUtils.Tools.Impls
{
	public class CreateBuildScenes : ISequence
	{
		private readonly string[] _scenes;

		public CreateBuildScenes(string[] scenes)
		{
			_scenes = scenes;
		}

		public void Do(Action onComplete)
		{
			var initialScene = SceneManager.GetActiveScene();
			var initialSceneName = initialScene.path;
			EditorSceneManager.OpenScene(initialSceneName);
			onComplete();
		}
	}
}