using System;
using System.Linq;
using Db.BuildSettings;
using Db.BuildSettings.Impls;
using UnityEditor;
using Utils.Serializer;
using Utils.Tools;

namespace BuildUtils.Tools.Impls
{
	public class SetBuildType : ISequence
	{
		private readonly EBuildType _buildType;
		private readonly EStoreType _storeType;

		public SetBuildType(EBuildType buildType, EStoreType storeType)
		{
			_buildType = buildType;
			_storeType = storeType;
		}

		public void Do(Action onComplete)
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
			var buildSettingsSo = new SerializedObject(buildSettings);
			var buildTypeSp = buildSettingsSo.FindProperty("buildType");
			buildTypeSp.SetEnum(_buildType);
			var storeTypeSp = buildSettingsSo.FindProperty("storeType");
			storeTypeSp.SetEnum(_storeType);
			buildSettingsSo.ApplyModifiedProperties();
			ConfigureProjectUtils.SetTargetStore(_storeType);
			onComplete();
		}
	}
}