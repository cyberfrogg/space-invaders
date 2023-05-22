using UnityEditor;

namespace BuildUtils.Tools.Impls
{
	public class AndroidReleaseBuildPipeline : AAndroidBuildPipeline
	{
		public AndroidReleaseBuildPipeline(
			string[] scenes,
			string path,
			string fileName
		) : base(scenes, path, fileName)
		{
		}

		protected override BuildOptions GetBuildOptions() => BuildOptions.None;
	}
}