using System.IO;
using UnityEditor;
using UnityEngine;

namespace Helpers
{
	public class PlayerPrefsHelperEditor
	{
		[MenuItem("Tools/SavedGameData/Delete PlayerPrefs")]
		public static void PlayerPrefsDeleteAll()
		{
			PlayerPrefs.DeleteAll();
			UnityEngine.Debug.Log($"[{nameof(PlayerPrefsHelperEditor)}] [✖_✖] Delete all PlayerPrefs");
		}

		[MenuItem("Tools/SavedGameData/Delete data in PersistentDataPath")]
		public static void DeleteGameDataInPersistentDataPath()
		{
			var pathData = Application.persistentDataPath;
			var files = Directory.GetFiles(pathData);
			foreach (var file in files)
			{
				var fileInfo = new FileInfo(file);
				fileInfo.Delete();
			}

			UnityEngine.Debug.Log($"[{nameof(PlayerPrefsHelperEditor)}] [✖_✖] Delete all in dir: {pathData}");
		}

		[MenuItem("Tools/SavedGameData/DeleteAll #&d")]
		public static void DeleteAll()
		{
			PlayerPrefsDeleteAll();
			DeleteGameDataInPersistentDataPath();
		}
	}
}