using System;
using UnityEditor;
using Utils.Tools;

namespace BuildUtils.Tools.Impls
{
	public class SetBuildApkArm7Mono : ISequence
	{
		public void Do(Action onComplete)
		{
			EditorUserBuildSettings.buildAppBundle = false;
			PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.Mono2x);
			PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARMv7;
			onComplete();
		}
	}
}