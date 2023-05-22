using System;
using UnityEditor;
using Utils.Tools;

namespace BuildUtils.Tools.Impls
{
	public class SetKeystoreAndAlias : ISequence
	{
		private const string KEYSTORE_NAME = "into_the_backrooms.keystore";
		private const string KEYSTORE_PASSWORD = "backrooms";
		private const string ALIAS_NAME = "tarpo";
		private const string ALIAS_PASSWORD = "WZRm9QH3";

		public void Do(Action onComplete)
		{
			PlayerSettings.Android.useCustomKeystore = true;
			PlayerSettings.Android.keystoreName = KEYSTORE_NAME;
			PlayerSettings.Android.keystorePass = KEYSTORE_PASSWORD;
			PlayerSettings.Android.keyaliasName = ALIAS_NAME;
			PlayerSettings.Android.keyaliasPass = ALIAS_PASSWORD;
			onComplete();
		}
	}
}