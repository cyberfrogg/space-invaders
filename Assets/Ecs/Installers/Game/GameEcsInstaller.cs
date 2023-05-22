using Ecs.Core.Extensions;
using Ecs.Installers.Game.Feature;
using Ecs.Installers.Game.Feature.Impls;

namespace Ecs.Installers.Game
{
	public class GameEcsInstaller : AEcsInstaller
	{
		protected override void InstallSystems(Contexts contexts, bool isDebug)
		{
			BindContext<ActionContext>();
			BindContext<GameContext>();
			BindContext<InputContext>();
			BindContext<SchedulerContext>();
			BindContext<SignalContext>();

			GameEcsSystems.Install(Container, isDebug);

			// Event systems
			BindEventSystem<ActionEventSystems>();
		
			BindEventSystem<GameEventSystems>();
			BindEventSystem<InputEventSystems>();
		
			BindEventSystem<SchedulerEventSystems>();
			BindEventSystem<SignalEventSystems>();
			

			// Cleanup destroyed entity 
			Container.BindDestroyedCleanup<ActionContext, ActionEntity>(ActionMatcher.Destroyed);
		
			Container.BindDestroyedCleanup<GameContext, GameEntity>(GameMatcher.Destroyed);
			Container.BindDestroyedCleanup<InputContext, InputEntity>(InputMatcher.Destroyed);
			Container.BindDestroyedCleanup<SchedulerContext, SchedulerEntity>(SchedulerMatcher.Destroyed);
			Container.BindDestroyedCleanup<SignalContext, SignalEntity>(SignalMatcher.Destroyed);

			BindFeature<GameFeature, IGameFeature>();
		}
	}
}