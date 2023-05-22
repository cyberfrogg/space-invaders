using System;
using UnityEditor;
using Utils.Tools;

namespace BuildUtils.Tools.Impls
{
	public class SetDebugKeystoreAndAlias : ISequence
	{
		public void Do(Action onComplete)
		{
			PlayerSettings.Android.useCustomKeystore = false;
			PlayerSettings.Android.keystoreName = string.Empty;
			PlayerSettings.Android.keystorePass = null;
			PlayerSettings.Android.keyaliasName = null;
			PlayerSettings.Android.keyaliasPass = null;
			onComplete();
		}
	}
}