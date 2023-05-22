using System;
using UnityEditor;
using Utils.Tools;

namespace BuildUtils.Tools.Impls
{
	public class SetStripEngineCode : ISequence
	{
		public void Do(Action onComplete)
		{
			PlayerSettings.stripEngineCode = true;
			PlayerSettings.SetManagedStrippingLevel(BuildTargetGroup.Android, ManagedStrippingLevel.Low);
			onComplete();
		}
	}
}