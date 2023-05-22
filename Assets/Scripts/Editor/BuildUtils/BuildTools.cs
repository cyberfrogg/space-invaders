using System;
using BuildUtils.Tools;
using BuildUtils.Tools.Impls;
using Db.BuildSettings;
using UnityEditor;
using Utils.Tools;

namespace BuildUtils
{
	public class BuildTools
	{
		private const string PROJECT_NAME = "prj";
		private const string BUILD_NAME = "BasicProject";
		private const string DEV_BUILD_NAME = "Dev" + BUILD_NAME;

		//Scenes includes in build
		public static readonly GameSceneRepo GameSceneRepo = GameSceneRepo.Build();

		private static readonly SequenceManager SequenceManager = new SequenceManager();

		[MenuItem("Tools/Build/[Target] GooglePlay")]
		public static void GooglePlayTargetBuild() => SetTargetBuild(EStoreType.GooglePlay);

		[MenuItem("Tools/Build/[Target] Huawei")]
		public static void HuaweiTargetBuild() => SetTargetBuild(EStoreType.Huawei);

		[MenuItem("Tools/Build/[Target] Amazon")]
		public static void AmazonTargetBuild() => SetTargetBuild(EStoreType.Amazon);

		[MenuItem("Tools/Build/[Target] Samsung")]
		public static void SamsungTargetBuild() => SetTargetBuild(EStoreType.Samsung);

		private static void SetTargetBuild(EStoreType storeType)
		{
			SequenceManager.Clear();
			ConfiguratorCustomBuildSteps.Configure(SequenceManager, storeType);
			SequenceManager.Add(new SetBuildType(EBuildType.Debug, storeType))
				.Do();
			AssetDatabase.Refresh();
		}

		[MenuItem("Tools/Build/[GooglePlay] Debug")]
		public static void GoogleDebugAndroidApk() => BuildDebugAndroidApk(EStoreType.GooglePlay);

		// [MenuItem("Tools/Build/[Huawei] Debug")]
		// public static void HuaweiDebugAndroidApk() => BuildDebugAndroidApk(EStoreType.Huawei);
		//
		// [MenuItem("Tools/Build/[Amazon] Debug")]
		// public static void AmazonDebugAndroidApk() => BuildDebugAndroidApk(EStoreType.Amazon);
		//
		// [MenuItem("Tools/Build/[Samsung] Debug")]
		// public static void SamsungDebugAndroidApk() => BuildDebugAndroidApk(EStoreType.Samsung);

		private static void BuildDebugAndroidApk(EStoreType storeType)
		{
			void BuildDebugApk(string path)
			{
				BuildDebugAndroidApk(path, storeType);
			}

			SequenceManager.Clear();
			SequenceManager
				.Add(new ChooseBuildPath(DEV_BUILD_NAME, BuildDebugApk))
				.Do();
		}

		private static void BuildDebugAndroidApk(string buildPath, EStoreType storeType)
		{
			var apkName = GetDebugApkName(storeType);
			SequenceManager.Clear();
			ConfiguratorCustomBuildSteps.Configure(SequenceManager, storeType);
			SequenceManager
				.Add(new CreateBuildScenes(GameSceneRepo.GetScenesWithRequirePreProcessBuild()))
				.Add(new SetBuildType(EBuildType.Debug, storeType))
				.Add(new SetDebugKeystoreAndAlias())
				.Add(new SetStripEngineCode())
				.Add(new SetLogAll())
				.Add(new SetBuildApkArm7Mono())
				.Add(new AndroidDevelopmentBuildPipeline(GameSceneRepo.GetScenesAfterPreProcessBuild(), buildPath,
					apkName))
				.Do();
		}

		[MenuItem("Tools/Build/[GooglePlay] Debug IL2CPP")]
		public static void GoogleDebugIl2CPPAndroidApk() => BuildDebugIl2CPPAndroidApk(EStoreType.GooglePlay);

		// [MenuItem("Tools/Build/[Huawei] Debug IL2CPP")]
		// public static void HuaweiDebugIl2CPPAndroidApk() => BuildDebugIl2CPPAndroidApk(EStoreType.Huawei);
		//
		// [MenuItem("Tools/Build/[Amazon] Debug IL2CPP")]
		// public static void AmazonDebugIl2CPPAndroidApk() => BuildDebugIl2CPPAndroidApk(EStoreType.Amazon);
		//
		// [MenuItem("Tools/Build/[Samsung] Debug IL2CPP")]
		// public static void SamsungDebugIl2CPPAndroidApk() => BuildDebugIl2CPPAndroidApk(EStoreType.Samsung);

		private static void BuildDebugIl2CPPAndroidApk(EStoreType storeType)
		{
			void BuildDebugApk(string path)
			{
				BuildDebugIl2CPPAndroidApk(path, storeType);
			}

			SequenceManager.Clear();
			SequenceManager
				.Add(new ChooseBuildPath(DEV_BUILD_NAME, BuildDebugApk))
				.Do();
		}

		private static void BuildDebugIl2CPPAndroidApk(string buildPath, EStoreType storeType)
		{
			var apkName = GetDebugApkName(storeType);
			SequenceManager.Clear();
			ConfiguratorCustomBuildSteps.Configure(SequenceManager, storeType);
			SequenceManager
				.Add(new CreateBuildScenes(GameSceneRepo.GetScenesWithRequirePreProcessBuild()))
				.Add(new SetBuildType(EBuildType.Debug, storeType))
				.Add(new SetDebugKeystoreAndAlias())
				.Add(new SetStripEngineCode())
				.Add(new SetBuildApk())
				.Add(new SetLogAll())
				.Add(new SetIl2CppAllTargetPlatforms())
				.Add(new AndroidDevelopmentBuildPipeline(GameSceneRepo.GetScenesAfterPreProcessBuild(), buildPath,
					apkName))
				.Do();
		}

		[MenuItem("Tools/Build/[GooglePlay] Mono Release APK")]
		public static void GooglePlayReleaseAndroidApk() => BuildReleaseAndroidApk(EStoreType.GooglePlay);

		// [MenuItem("Tools/Build/[Huawei] Mono Release APK")]
		// public static void HuaweiReleaseAndroidApk() => BuildReleaseAndroidApk(EStoreType.Huawei);
		//
		// [MenuItem("Tools/Build/[Amazon] Mono Release APK")]
		// public static void AmazonReleaseAndroidApk() => BuildReleaseAndroidApk(EStoreType.Amazon);
		//
		// [MenuItem("Tools/Build/[Samsung] Mono Release APK")]
		// public static void SamsungReleaseAndroidApk() => BuildReleaseAndroidApk(EStoreType.Samsung);

		private static void BuildReleaseAndroidApk(EStoreType storeType)
		{
			void BuildReleaseAPK(string path)
			{
				BuildReleaseAndroidApk(path, storeType);
			}

			SequenceManager.Clear();
			SequenceManager
				.Add(new ChooseBuildPath(BUILD_NAME, BuildReleaseAPK))
				.Do();
		}

		private static void BuildReleaseAndroidApk(string buildPath, EStoreType storeType)
		{
			var apkName = GetReleaseApkName(storeType);
			SequenceManager.Clear();
			ConfiguratorCustomBuildSteps.Configure(SequenceManager, storeType);
			SequenceManager
				.Add(new CreateBuildScenes(GameSceneRepo.GetScenesWithRequirePreProcessBuild()))
				.Add(new SetBuildType(EBuildType.Release, storeType))
				.Add(new SetKeystoreAndAlias())
				.Add(new SetStripEngineCode())
				.Add(new SetLogExceptions())
				.Add(new SetBuildApkArm7Mono())
				.Add(new AndroidReleaseBuildPipeline(GameSceneRepo.GetScenesAfterPreProcessBuild(), buildPath, apkName))
				.Do();
		}

		[MenuItem("Tools/Build/[GooglePlay] Release ILL2CPP APK")]
		public static void GooglePlayReleaseAndroidIll2CppApk()
			=> BuildReleaseAndroidIll2CppApk(EStoreType.GooglePlay);

		// [MenuItem("Tools/Build/[Huawei] Release ILL2CPP APK")]
		// public static void HuaweiReleaseAndroidIll2CppApk()
		// 	=> BuildReleaseAndroidIll2CppApk(EStoreType.Huawei);
		//
		// [MenuItem("Tools/Build/[Amazon] Release ILL2CPP APK")]
		// public static void AmazonReleaseAndroidIll2CppApk()
		// 	=> BuildReleaseAndroidIll2CppApk(EStoreType.Amazon);
		//
		// [MenuItem("Tools/Build/[Samsung] Release ILL2CPP APK")]
		// public static void SamsungReleaseAndroidIll2CppApk()
		// 	=> BuildReleaseAndroidIll2CppApk(EStoreType.Samsung);

		private static void BuildReleaseAndroidIll2CppApk(EStoreType storeType)
		{
			void BuildReleaseIll2Cpp(string path)
			{
				BuildReleaseAndroidIll2CppApk(path, storeType);
			}

			SequenceManager.Clear();
			SequenceManager
				.Add(new ChooseBuildPath(BUILD_NAME, BuildReleaseIll2Cpp))
				.Do();
		}

		private static void BuildReleaseAndroidIll2CppApk(string buildPath, EStoreType storeType)
		{
			var apkName = GetReleaseApkName(storeType);
			SequenceManager.Clear();
			ConfiguratorCustomBuildSteps.Configure(SequenceManager, storeType);
			SequenceManager
				.Add(new CreateBuildScenes(GameSceneRepo.GetScenesWithRequirePreProcessBuild()))
				.Add(new SetBuildType(EBuildType.Release, storeType))
				.Add(new SetKeystoreAndAlias())
				.Add(new SetStripEngineCode())
				.Add(new SetLogExceptions())
				.Add(new SetIl2CppAllTargetPlatforms())
				.Add(new SetBuildApk())
				.Add(new AndroidReleaseBuildPipeline(GameSceneRepo.GetScenesAfterPreProcessBuild(), buildPath, apkName))
				.Do();
		}

		[MenuItem("Tools/Build/[GooglePlay] Release ILL2CPP AAB")]
		public static void GooglePlayReleaseAndroidIll2CppAab()
			=> BuildReleaseAndroidIll2CppAab(EStoreType.GooglePlay);

		private static void BuildReleaseAndroidIll2CppAab(EStoreType storeType)
		{
			void BuildReleaseIll2Cpp(string path)
			{
				BuildReleaseAndroidIll2CppAab(path, storeType);
			}

			SequenceManager.Clear();
			SequenceManager
				.Add(new ChooseBuildPath(BUILD_NAME, BuildReleaseIll2Cpp))
				.Do();
		}

		private static void BuildReleaseAndroidIll2CppAab(string buildPath, EStoreType storeType)
		{
			var apkName = GetReleaseAabName(storeType);
			SequenceManager.Clear();
			ConfiguratorCustomBuildSteps.Configure(SequenceManager, storeType);
			SequenceManager
				.Add(new CreateBuildScenes(GameSceneRepo.GetScenesWithRequirePreProcessBuild()))
				.Add(new SetBuildType(EBuildType.Release, storeType))
				.Add(new SetKeystoreAndAlias())
				.Add(new SetStripEngineCode())
				.Add(new SetLogExceptions())
				.Add(new SetIl2CppAllTargetPlatforms())
				.Add(new SetBuildAab())
				.Add(new AndroidReleaseBuildPipeline(GameSceneRepo.GetScenesAfterPreProcessBuild(), buildPath, apkName))
				.Do();
		}

		[MenuItem("Tools/Build/[GooglePlay] Release ILL2CPP APK + AAB")]
		public static void GooglePlayFullReleaseAndroidIll2CppApk()
			=> BuildFullReleaseAndroidIll2CppApk(EStoreType.GooglePlay);

		// [MenuItem("Tools/Build/[Huawei] Release ILL2CPP APK + AAB")]
		// public static void HuaweiFullReleaseAndroidIll2CppApk()
		// 	=> BuildFullReleaseAndroidIll2CppApk(EStoreType.Huawei);
		//
		// [MenuItem("Tools/Build/[Amazon] Release ILL2CPP APK + AAB")]
		// public static void AmazonFullReleaseAndroidIll2CppApk()
		// 	=> BuildFullReleaseAndroidIll2CppApk(EStoreType.Amazon);
		//
		// [MenuItem("Tools/Build/[Samsung] Release ILL2CPP APK + AAB")]
		// public static void SamsungFullReleaseAndroidIll2CppApk()
		// 	=> BuildFullReleaseAndroidIll2CppApk(EStoreType.Samsung);

		private static void BuildFullReleaseAndroidIll2CppApk(EStoreType storeType)
		{
			void BuildReleaseIll2Cpp(string path)
			{
				BuildReleaseAndroidApkAndAbb(path, storeType);
			}

			SequenceManager.Clear();
			SequenceManager
				.Add(new ChooseBuildPath(BUILD_NAME, BuildReleaseIll2Cpp))
				.Do();
		}

		private static void BuildReleaseAndroidApkAndAbb(string buildPath, EStoreType storeType)
		{
			var apkName = GetReleaseApkName(storeType);
			var aabName = GetReleaseAabName(storeType);
			SequenceManager.Clear();
			ConfiguratorCustomBuildSteps.Configure(SequenceManager, storeType);
			SequenceManager
				.Add(new CreateBuildScenes(GameSceneRepo.GetScenesWithRequirePreProcessBuild()))
				.Add(new SetBuildType(EBuildType.Release, storeType))
				.Add(new SetKeystoreAndAlias())
				.Add(new SetLogExceptions())
				.Add(new SetStripEngineCode())
				.Add(new SetIl2CppAllTargetPlatforms())
				.Add(new SetBuildApk())
				.Add(new AndroidReleaseBuildPipeline(GameSceneRepo.GetScenesAfterPreProcessBuild(), buildPath, apkName))
				.Add(new SetBuildAab())
				.Add(new AndroidReleaseBuildPipeline(GameSceneRepo.GetScenesAfterPreProcessBuild(), buildPath, aabName))
				.Do();
		}

		public static void Build()
		{
			var buildPath = GetBuildPath();
			var storeType = GetStoreType();

			if (string.IsNullOrEmpty(buildPath))
				throw new Exception($"[BuildTools] Build path is empty!");

			EditorTestValidator.ValidateTests(buildPath);
			BuildReleaseAndroidApkAndAbb(buildPath, storeType);
		}

		public static void BuildRelease()
		{
			var buildPath = GetBuildPath();
			var storeType = GetStoreType();

			if (string.IsNullOrEmpty(buildPath))
				throw new Exception($"[BuildTools] Build path is empty!");

			BuildReleaseAndroidApkAndAbb(buildPath, storeType);
		}

		public static void BuildDebug()
		{
			var buildPath = GetBuildPath();
			var storeType = GetStoreType();

			if (string.IsNullOrEmpty(buildPath))
				throw new Exception($"[BuildTools] Build path is empty!");

			BuildDebugAndroidApk(buildPath, storeType);
		}

		private static string GetBuildPath() => CommandArguments.GetArgParameter("BUILD_PATH");

		private static EStoreType GetStoreType()
		{
			var parameter = CommandArguments.GetArgParameter("STORE_TYPE");
			return (EStoreType)Enum.Parse(typeof(EStoreType), parameter);
		}

		public static void SetAndroidDebugDefines()
		{
			const string defines = "ZEN_SIGNALS_ADD_UNIRX;ZEN_TESTS_OUTSIDE_UNITY;mopub_manager";
			ApplyBuildNumber();
			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, defines);
		}

		public static void SetAndroidReleaseDefines()
		{
			const string defines =
				"ZEN_SIGNALS_ADD_UNIRX;ZEN_TESTS_OUTSIDE_UNITY;ZEN_STRIP_ASSERTS_IN_BUILDS;ENTITAS_FAST_AND_UNSAFE;mopub_manager";
			ApplyBuildNumber();
			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, defines);
		}

		private static void ApplyBuildNumber()
		{
			var buildNumber = CommandArguments.GetArgParameter("BUILD_NUMBER");
			PlayerSettings.bundleVersion = PlayerSettings.bundleVersion + "." + buildNumber;
		}

		private static string GetDebugApkName(EStoreType storeType)
		{
			var storePrefix = GetStorePrefix(storeType);
			return $"{storePrefix}-{PROJECT_NAME}-dev-apk-{PlayerSettings.bundleVersion}.apk";
		}

		private static string GetReleaseApkName(EStoreType storeType)
		{
			var storePrefix = GetStorePrefix(storeType);
			return $"{storePrefix}-{PROJECT_NAME}-apk-{PlayerSettings.bundleVersion}.apk";
		}

		private static string GetReleaseAabName(EStoreType storeType)
		{
			var storePrefix = GetStorePrefix(storeType);
			return $"{storePrefix}-{PROJECT_NAME}-aab-{PlayerSettings.bundleVersion}.aab";
		}

		private static string GetStorePrefix(EStoreType storeType)
		{
			switch (storeType)
			{
				case EStoreType.Editor:
					return "ed";
				case EStoreType.GooglePlay:
					return "gp";
				case EStoreType.AppStore:
					return "as";
				case EStoreType.Amazon:
					return "am";
				case EStoreType.Huawei:
					return "hu";
				case EStoreType.Samsung:
					return "sm";
				default:
					throw new ArgumentOutOfRangeException(nameof(storeType), storeType, null);
			}
		}

		[MenuItem("Tools/Build/[iOS] Release Export")]
		public static void BuildExportIOSRelease()
		{
			SequenceManager.Clear();
			SequenceManager
				.Add(new ChooseBuildPath($"{BUILD_NAME}IOS", BuildExportIOSRelease))
				.Do();
		}

		private static void BuildExportIOSRelease(string buildPath)
		{
			var fileName = $"zp-release";
			SequenceManager.Clear();
			SequenceManager
				.Add(new CreateBuildScenes(GameSceneRepo.GetScenesWithRequirePreProcessBuild()))
				.Add(new SetBuildType(EBuildType.Release, EStoreType.AppStore))
				.Add(new SetKeystoreAndAlias())
				.Add(new SetLogExceptions())
				.Add(new SetStripEngineCode())
				.Add(new SetIl2CppAllTargetPlatforms())
				.Add(new SetLoggingLevelException())
				.Add(new IOSReleaseExportBuild(GameSceneRepo.GetScenesAfterPreProcessBuild(), buildPath, fileName))
				.Do();
		}
	}
}