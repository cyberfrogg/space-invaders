using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ModestTree;
using SpreadsheetUtil.Helpers;
using UnityEditor;
using UnityEngine;
using Utils.Serializer;
using Utils.Tools;
using Object = UnityEngine.Object;

namespace BuildUtils.Tools.Impls
{
	public class LoadSpreadsheets : ISequence
	{
		private List<ISpreadsheetLoader> _loaders;
		private Action _onComplete;

		public void Do(Action onComplete)
		{
			_onComplete = onComplete;
			var customEditors = AppDomain.CurrentDomain.GetAssemblies()
				.Select(assembly => assembly.GetTypes())
				.Aggregate((types, types1) => types.Concat(types1).ToArray())
				.Where(type => type.HasInterface<ISpreadsheetLoader>()
				               && type.HasAttribute(typeof(CustomEditor)))
				.Distinct()
				.ToArray();

			var customEditorToScriptableObjects = new Dictionary<Type, Object[]>();

			foreach (var customEditor in customEditors)
			{
				var customEditorClassType = GetCustomEditorClassType(customEditor);
				var resources = LoadResources(customEditorClassType);
				customEditorToScriptableObjects.Add(customEditor, resources);
			}

			_loaders = new List<ISpreadsheetLoader>();

			foreach (var customEditorToScriptableObject in customEditorToScriptableObjects)
			{
				var customEditorType = customEditorToScriptableObject.Key;
				foreach (var scriptableObject in customEditorToScriptableObject.Value)
				{
					var editor = Editor.CreateEditor(scriptableObject, customEditorType);
					var spreadsheetLoader = editor as ISpreadsheetLoader;
					if (spreadsheetLoader == null)
						continue;
					_loaders.Add(spreadsheetLoader);
				}
			}

			LoadSpreadSheets();
		}

		private void LoadSpreadSheets()
		{
			if (_loaders.Count == 0)
			{
				UnityEngine.Debug.Log($"[{nameof(LoadSpreadsheets)}] Load completed");
				_onComplete();
				return;
			}

			var spreadsheetLoader = _loaders[0];
			spreadsheetLoader.Success += OnLoadComplete;
			spreadsheetLoader.DownloadAndProcess();
		}

		private void OnLoadComplete(bool result)
		{
			if (!result)
				throw new System.Exception($"[{nameof(LoadSpreadsheets)}] Load spread sheets fail.");

			_loaders.RemoveAt(0);
			LoadSpreadSheets();
		}

		private Type GetCustomEditorClassType(Type customEditorType)
		{
			var customAttribute = customEditorType.GetCustomAttribute<CustomEditor>();
			var type = customAttribute.GetType();
			var fieldInfo = type.GetField("m_InspectedType",
				BindingFlags.Default | BindingFlags.NonPublic | BindingFlags.Instance);
			return (Type) fieldInfo.GetValue(customAttribute);
		}

		private Object[] LoadResources(Type resourceType)
		{
			var resources = Resources.LoadAll("Settings", resourceType);
			return resources.ToArray();
		}
	}
}