using System;
using UnityEditor;
using UnityEngine;
using Utils.Tools;

namespace BuildUtils.Tools.Impls
{
	public class ExportAndroidProject : ISequence
	{
		private readonly string[] _scenes;
		private readonly string _path;
		private readonly string _fileName;
		private Action _onComplete;

		public ExportAndroidProject(string[] scenes, string path, string fileName)
		{
			_scenes = scenes;
			_path = path;
			_fileName = fileName;
		}

		public void Do(Action onComplete)
		{
			if (string.IsNullOrEmpty(_fileName))
			{
				Debug.Log("[ExportAndroidProject] File name can not be empty");
				return;
			}

			var buildReport = BuildPipeline.BuildPlayer(_scenes,
				$"{_path}/{_fileName}",
				BuildTarget.Android,
				BuildOptions.AcceptExternalModificationsToPlayer);
			Debug.Log($"[BuildTool] {DateTime.Now:g} Build for Android: {_fileName} (Success)");

			onComplete();
		}
	}
}