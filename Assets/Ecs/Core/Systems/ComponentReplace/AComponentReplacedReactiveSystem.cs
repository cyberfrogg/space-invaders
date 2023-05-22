using System;
using Ecs.Core.Collectors;
using JCMG.EntitasRedux;

namespace Ecs.Core.Systems.ComponentReplace
{
	public abstract class AComponentReplacedReactiveSystem<TEntity, TComponent, TValue> : IReactiveSystem
		where TEntity : class, IEntity
		where TComponent : class, IComponent
	{
		private readonly ComponentReplacedCollector<TEntity, TComponent, TValue> _collector;

		private bool _isActive;

		protected AComponentReplacedReactiveSystem(IContext<TEntity> context, int eventPoolCapacity = 4)
		{
			var componentIndex = FindComponentIndex(typeof(TComponent));
			_collector = new ComponentReplacedCollector<TEntity, TComponent, TValue>(context, componentIndex, GetValue,
				GetDefault(), eventPoolCapacity);
			if (AutoActive)
				Activate();
		}

		protected virtual bool AutoActive => true;

		public void Activate()
		{
			if (_isActive)
				return;

			_isActive = true;
			_collector.Activate();
		}

		public void Deactivate()
		{
			if (!_isActive)
				return;

			_isActive = false;
			_collector.Deactivate();
		}

		public void Clear()
		{
			_collector.ClearCollectedEntities();
		}

		public void Update()
		{
			if (_collector.Count == 0)
				return;

			var entries = _collector.GetCollectedEntities();
			foreach (var entry in entries)
			{
				var replacedEvent = entry.Value;
				OnReplaced(entry.Key, replacedEvent.Last, replacedEvent.Next);
			}

			_collector.ClearCollectedEntities();
		}

		protected abstract Type[] GetComponentTypes();

		protected virtual TValue GetDefault() => default;

		protected abstract TValue GetValue(TComponent component);

		protected abstract void OnReplaced(TEntity entity, TValue last, TValue next);

		private int FindComponentIndex(Type type)
		{
			var componentTypes = GetComponentTypes();
			for (var i = 0; i < componentTypes.Length; i++)
			{
				var componentType = componentTypes[i];
				if (componentType == type)
					return i;
			}

			throw new Exception($"[{GetType().Name}] Cannot find component index {type.Name}");
		}
	}
}