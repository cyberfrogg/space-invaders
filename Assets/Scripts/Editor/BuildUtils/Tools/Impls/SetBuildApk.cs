using System;
using UnityEditor;
using Utils.Tools;

namespace BuildUtils.Tools.Impls
{
	public class SetBuildApk : ISequence
	{
		public void Do(Action onComplete)
		{
			EditorUserBuildSettings.buildAppBundle = false;
			onComplete();
		}
	}
}