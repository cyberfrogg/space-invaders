using System;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using Utils.Tools;

namespace BuildUtils.Tools.Impls
{
	public abstract class AAndroidBuildPipeline : ISequence
	{
		private readonly string[] _scenes;
		private readonly string _path;
		private readonly string _fileName;
		private Action _onComplete;

		protected AAndroidBuildPipeline(string[] scenes, string path, string fileName)
		{
			_scenes = scenes;
			_path = path;
			_fileName = fileName;
		}

		public void Do(Action onComplete)
		{
			if (string.IsNullOrEmpty(_fileName))
			{
				Debug.Log("[AndroidBuildProject] File name can not be empty");
				return;
			}
			
			var buildReport = BuildPipeline.BuildPlayer(_scenes,
				$"{_path}/{_fileName}",
				BuildTarget.Android,
				GetBuildOptions());
			var buildSummary = buildReport.summary;
			var message =
				$"[{GetType().Name}] {DateTime.Now:g} Build for {buildSummary.platform}: {buildSummary.outputPath} Size:{buildSummary.totalSize} Result: {buildSummary.result}";

			if (buildSummary.result == BuildResult.Succeeded)
				Debug.Log(message);
			else
				Debug.LogAssertion(message);

			onComplete();
		}

		protected abstract BuildOptions GetBuildOptions();
	}
}