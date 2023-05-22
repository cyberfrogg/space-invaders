using System;
using UnityEditor;
using Utils.Tools;

namespace BuildUtils.Tools.Impls
{
	public class ChooseBuildPath : ISequence
	{
		private readonly string _name;
		private readonly Action<string> _onPathChoose;
		private readonly Action<string> _onPath;
		
		private string _oldPath;
		private string _key;

		public ChooseBuildPath(string name, Action<string> onPathChoose)
		{
			_name = name;
			_onPathChoose = onPathChoose;
		}

		public void Do(Action onComplete)
		{
			_key = $"BuildTool.Android{_name}.LastPath";
			var path = ChoosePath();
			if (string.IsNullOrEmpty(path))
			{
				UnityEngine.Debug.Log("[BuildTools] Build canceled");
				return;
			}

			SaveBuildPath();
			_onPathChoose(path);
			onComplete();
		}

		private string ChoosePath()
		{
			_oldPath = EditorPrefs.HasKey(_key) ? EditorPrefs.GetString(_key) : "";
			_oldPath = EditorUtility.SaveFolderPanel("Choose Location of Built", _oldPath, "");
			return _oldPath;
		}

		private void SaveBuildPath() => EditorPrefs.SetString(_key, _oldPath);
	}
}