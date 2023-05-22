using Ecs.Utils.Impl;
using Game.Models.Camera.Impl;
using Game.Services.Pool.Impls;
using Game.Signals;
using Game.Ui;
using Libs.AnalyticsAppMetrica;
using Libs.GameAnalytics;
using Zenject;

namespace Installers.Game
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            DeclareSignals();
            Bind();
            BindAi();
            BindWindows();
            BindManagers();
        }

        private void DeclareSignals()
        {
	        Container.DeclareSignal<SignalLevelStart>();
	        Container.DeclareSignal<SignalLevelRestart>();
	        Container.DeclareSignal<SignalLevelComplete>();
	        Container.DeclareSignal<SignalLevelFail>();
        }

        private void Bind()
        {
	        AppMetricaServiceInstaller.Install(Container);
	        GameAnalyticServiceInstaller.Install(Container);
	        
            Container.Bind<LateFixedManager>().AsSingle();
            Container.Bind<LateFixedUpdate>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<PlayerCameraHolder>().AsSingle();
        }
        
        private void BindAi()
		{

		}

        private void BindWindows()
        {
	        Container.DeclareSignal<GameHudWindow>();
	        Container.BindInterfacesAndSelfTo<GameHudWindow>().AsSingle();
        }

        private void BindManagers()
        {
	        Container.BindInterfacesTo<SpawnService>().AsSingle();
	        Container.BindInterfacesTo<LinkedEntityRepository>().AsSingle();
	        Container.BindInterfacesTo<PrefabPoolService>().AsSingle();
        }
    }
}