using System.IO;
using UnityEditor;
using UnityEngine;

namespace Helpers
{
	public class RemoveEmptyFolderAndMetaEditor
	{
		[MenuItem("Tools/Folders/Remove empty folders")]
		public static void RemoveEmptyFolderAndMeta()
		{
			var dataPath = Application.dataPath;
			var directoryInfo = new DirectoryInfo(dataPath);
			RemoveDirectoryIfEmpty(directoryInfo);
		}

		private static void RemoveDirectoryIfEmpty(DirectoryInfo directory)
		{
			var subDirectories = directory.GetDirectories();
			foreach (var subDirectory in subDirectories)
				RemoveDirectoryIfEmpty(subDirectory);

			var fileInfos = directory.GetFiles();
			if (fileInfos.Length > 0)
				return;

			var directoryMeta = $"{directory.FullName}.meta";
			if (File.Exists(directoryMeta))
				File.Delete(directoryMeta);
			directory.Delete();
		}
	}
}