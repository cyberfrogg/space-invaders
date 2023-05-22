using UnityEditor;

namespace BuildUtils.Tools.Impls
{
	public class AndroidDevelopmentBuildPipeline : AAndroidBuildPipeline
	{
		public AndroidDevelopmentBuildPipeline(
			string[] scenes,
			string path,
			string fileName
		) : base(scenes, path, fileName)
		{
		}

		protected override BuildOptions GetBuildOptions() => BuildOptions.Development;
	}
}