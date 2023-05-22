using System;
using UnityEditor;
using UnityEngine;
using Utils.Tools;

namespace BuildUtils.Tools.Impls
{
	public class SetLogAll : ISequence
	{
		public void Do(Action onComplete)
		{
			PlayerSettings.SetStackTraceLogType(LogType.Log, StackTraceLogType.ScriptOnly);
			PlayerSettings.SetStackTraceLogType(LogType.Warning, StackTraceLogType.ScriptOnly);
			PlayerSettings.SetStackTraceLogType(LogType.Assert, StackTraceLogType.ScriptOnly);
			PlayerSettings.SetStackTraceLogType(LogType.Error, StackTraceLogType.ScriptOnly);
			PlayerSettings.SetStackTraceLogType(LogType.Exception, StackTraceLogType.ScriptOnly);
		}
	}
}