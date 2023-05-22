using System;
using UnityEditor;
using UnityEngine;
using Utils.Tools;

namespace BuildUtils.Tools.Impls
{
	public class IOSReleaseExportBuild : ISequence
	{
		private string[] _scenes;
		private string _path;
		private string _fileName;

		public IOSReleaseExportBuild(string[] scenes, string path, string fileName)
		{
			_scenes = scenes;
			_path = path;
			_fileName = fileName;
		}

		public void Do(Action onComplete)
		{
			if (string.IsNullOrEmpty(_fileName))
			{
				Debug.Log($"[{nameof(IOSReleaseExportBuild)}] File name can not be empty");
				return;
			}

			EditorUserBuildSettings.iOSXcodeBuildConfig = XcodeBuildConfig.Release;
			var buildReport = BuildPipeline.BuildPlayer(_scenes,
				$"{_path}/{_fileName}",
				BuildTarget.iOS,
				BuildOptions.None);
			Debug.Log(
				$"[{nameof(IOSReleaseExportBuild)}] {DateTime.Now:g} Build for iOS: {buildReport.summary.outputPath} ({buildReport.summary.result})");

			onComplete();
		}
	}
}