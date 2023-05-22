using Db.BuildSettings;
using Db.BuildSettings.Impls;
using UnityEngine;
using Zenject;
using ZenjectUtil.Test.Extensions;

namespace Installers.Game
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(ProjectSettingsInstaller), fileName = nameof(ProjectSettingsInstaller))]
    public class ProjectSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private BuildSetting buildSettings;
        
        public override void InstallBindings()
        {
            Container.Bind<IBuildSettings>().FromSubstitute(buildSettings).AsSingle();
        }
    }
}