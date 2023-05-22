using System;
using UnityEditor;
using Utils.Tools;

namespace BuildUtils.Tools.Impls
{
	public class SetBuildAab : ISequence
	{
		public void Do(Action onComplete)
		{
			EditorUserBuildSettings.buildAppBundle = true;
			onComplete();
		}
	}
}