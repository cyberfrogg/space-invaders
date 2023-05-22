using System;
using JCMG.EntitasRedux;

namespace Ecs.Core.Systems.ComponentReplace.Impls
{
	public abstract class
		AGameComponentReplacedReactiveSystem<TComponent, TValue> : AComponentReplacedReactiveSystem<GameEntity,
			TComponent, TValue>
		where TComponent : class, IComponent
	{
		protected AGameComponentReplacedReactiveSystem(IContext<GameEntity> context, int eventPoolCapacity = 4) : base(
			context, eventPoolCapacity)
		{
		}

		protected override Type[] GetComponentTypes() => GameComponentsLookup.ComponentTypes;
	}
}