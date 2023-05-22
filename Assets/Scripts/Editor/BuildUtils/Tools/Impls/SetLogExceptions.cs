using System;
using UnityEditor;
using UnityEngine;
using Utils.Tools;

namespace BuildUtils.Tools.Impls
{
	public class SetLogExceptions : ISequence
	{
		public void Do(Action onComplete)
		{
			PlayerSettings.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
			PlayerSettings.SetStackTraceLogType(LogType.Warning, StackTraceLogType.None);
			PlayerSettings.SetStackTraceLogType(LogType.Assert, StackTraceLogType.None);
			PlayerSettings.SetStackTraceLogType(LogType.Error, StackTraceLogType.ScriptOnly);
			PlayerSettings.SetStackTraceLogType(LogType.Exception, StackTraceLogType.ScriptOnly);
		}
	}
}