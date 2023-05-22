using System.Collections.Generic;
using BuildUtils;
using UnityEngine;

namespace Db.BuildSettings.Impls
{
	[CreateAssetMenu(menuName = "Settings/BuildSettings", fileName = "BuildSettings")]
	public class BuildSetting : ScriptableObject, IBuildSettings
	{
		[SerializeField] private EBuildType buildType;
		[SerializeField] private EStoreType storeType;
		
		public List<string> scenes;

		public EBuildType BuildType => buildType;

		public EStoreType StoreType
		{
			get
			{
				switch (Application.platform)
				{
					case RuntimePlatform.LinuxEditor:
					case RuntimePlatform.WindowsEditor:
					case RuntimePlatform.OSXEditor:
						return EStoreType.Editor;
					default:
						return storeType;
				}
			}
		}
		
	}
}