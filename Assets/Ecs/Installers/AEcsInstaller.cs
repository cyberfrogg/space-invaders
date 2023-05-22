using System;
using Db.BuildSettings;
using Ecs.Core.Bootstrap;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Installers
{
	public abstract class AEcsInstaller : MonoInstaller, IDisposable
	{
		[Inject] private IBuildSettings _buildSettings;

		private Contexts _contexts;

		public override void InstallBindings()
		{
			Container.Bind<IDisposable>().FromInstance(this).AsTransient();

			_contexts = Contexts.SharedInstance;
			var isDebug = _buildSettings.BuildType != EBuildType.Release;
			InstallSystems(_contexts, isDebug);

			// Main Bootstrap
			Container.BindInstance(_contexts).WhenInjectedInto<Bootstrap>();
			Container.BindInterfacesTo<Bootstrap>().AsSingle().NonLazy();
		}

		protected abstract void InstallSystems(Contexts contexts, bool isDebug);

		protected void BindEventSystem<TEventSystem>()
			where TEventSystem : Feature
		{
			Container.BindInterfacesTo<TEventSystem>().AsSingle().WithArguments(_contexts);
		}

		protected void BindContext<TContext>()
			where TContext : IContext
		{
			foreach (var ctx in _contexts.AllContexts)
				if (ctx is TContext context)
				{
					Container.BindInterfacesAndSelfTo<TContext>().FromInstance(context).AsSingle();
					return;
				}

			throw new Exception($"[{nameof(AEcsInstaller)}] No context with type: {typeof(TContext).Name}");
		}

		protected void BindFeature<TConcrete, TContract>()
			where TConcrete : CustomFeature, TContract, new()
			where TContract : ICustomFeature
		{
			var mainFeature = new TConcrete();
			Container.Bind<TContract>().FromInstance(mainFeature);
			Container.Bind<CustomFeature>().FromInstance(mainFeature).WhenInjectedInto<Bootstrap>();
		}

		public void Dispose()
		{
		}
	}
}