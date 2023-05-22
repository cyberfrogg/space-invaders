using System;
using System.Linq;
using Db.BuildSettings.Impls;
using UnityEditor;

namespace BuildUtils
{
	public class GameSceneRepo
	{
		private readonly BuildSetting _buildSetting;

		private GameSceneRepo(BuildSetting buildSetting)
		{
			_buildSetting = buildSetting;
		}

		public static GameSceneRepo Build()
		{
			var guids = AssetDatabase.FindAssets("t:ScriptableObject");
			var collection = guids.Select(guid =>
			{
				var path = AssetDatabase.GUIDToAssetPath(guid);
				return AssetDatabase.LoadAssetAtPath<BuildSetting>(path);
			}).Where(f => f != null);
			var buildSettings = collection.FirstOrDefault();
			if (buildSettings == null)
				throw new Exception($"[BuildTools] No build settings");
			
			return new GameSceneRepo(buildSettings);
		}

		public string[] GetScenesAfterPreProcessBuild() => _buildSetting.scenes.ToArray();


		public string[] GetScenesWithRequirePreProcessBuild() => _buildSetting.scenes.ToArray();
	}
}