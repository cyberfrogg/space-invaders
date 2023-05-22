using System;
using System.Collections.Generic;
using System.Linq;
using JCMG.EntitasRedux;

namespace Ecs.Core.Collectors
{
	public class ComponentReplacedCollector<TEntity, TComponent, TValue> : ICollector
		where TEntity : class, IEntity where TComponent : class
	{
		private readonly IContext<TEntity> _context;
		private readonly int _componentIndex;
		private readonly Func<TComponent, TValue> _getter;
		private readonly TValue _defaultValue;

		private readonly Stack<ValueReplacedEvent<TValue>> _replacedEventsPool;

		private readonly Dictionary<TEntity, ValueReplacedEvent<TValue>> _replacedEvents = new(EntityEqualityComparer<TEntity>.COMPARER);

		public ComponentReplacedCollector(
			IContext<TEntity> context,
			int componentIndex,
			Func<TComponent, TValue> getter,
			TValue defaultValue,
			int eventsPoolCapacity
		)
		{
			_context = context;
			_componentIndex = componentIndex;
			_getter = getter;
			_defaultValue = defaultValue;
			_replacedEventsPool = new Stack<ValueReplacedEvent<TValue>>(eventsPoolCapacity);
		}


		public void Activate()
		{
			_context.OnEntityCreated += OnEntityCreated;
		}

		public void Deactivate()
		{
			_context.OnEntityCreated -= OnEntityCreated;
		}

		public void ClearCollectedEntities()
		{
			foreach (var eventsValue in _replacedEvents.Values)
			{
				eventsValue.Last = _defaultValue;
				eventsValue.Next = _defaultValue;
				_replacedEventsPool.Push(eventsValue);
			}

			_replacedEvents.Clear();
		}

		public int Count => _replacedEvents.Count;

		public IEnumerable<TCast> GetCollectedEntities<TCast>() where TCast : class, IEntity =>
			_replacedEvents.Keys.Cast<TCast>();

		public IEnumerable<KeyValuePair<TEntity, ValueReplacedEvent<TValue>>> GetCollectedEntities() => _replacedEvents;

		private void OnEntityCreated(IContext context, IEntity entity)
		{
			entity.OnComponentAdded += OnComponentAdded;
			entity.OnComponentReplaced += OnComponentReplaced;
			entity.OnComponentRemoved += OnComponentRemoved;
			entity.OnDestroyEntity += OnDestroyEntity;
		}

		private void OnDestroyEntity(IEntity entity)
		{
			if (entity is TEntity castedEntity)
				_replacedEvents.Remove(castedEntity);

			entity.OnComponentAdded -= OnComponentAdded;
			entity.OnComponentReplaced -= OnComponentReplaced;
			entity.OnComponentRemoved -= OnComponentRemoved;
			entity.OnDestroyEntity -= OnDestroyEntity;
		}

		private void OnComponentAdded(IEntity entity, int index, IComponent component)
		{
			if (_componentIndex != index)
				return;

			var castedEntity = entity as TEntity;
			ProcessComponentUpdate(castedEntity, null, component);
		}

		private void OnComponentReplaced(
			IEntity entity,
			int index,
			IComponent previousComponent,
			IComponent newComponent
		)
		{
			if (_componentIndex != index)
				return;

			var castedEntity = entity as TEntity;
			ProcessComponentUpdate(castedEntity, previousComponent, newComponent);
		}

		private void OnComponentRemoved(IEntity entity, int index, IComponent component)
		{
			if (_componentIndex != index)
				return;

			var castedEntity = entity as TEntity;
			ProcessComponentRemoved(castedEntity, component);
		}

		private void ProcessComponentUpdate(TEntity entity, IComponent previousComponent, IComponent newComponent)
		{
			if (!_replacedEvents.TryGetValue(entity, out var replacedEvent))
			{
				replacedEvent = Create(previousComponent);
				_replacedEvents.Add(entity, replacedEvent);
			}

			var castedComponent = newComponent as TComponent;
			var value = _getter(castedComponent);
			replacedEvent.Next = value;
		}

		private void ProcessComponentRemoved(TEntity entity, IComponent component)
		{
			if (!_replacedEvents.TryGetValue(entity, out var replacedEvent))
			{
				replacedEvent = Create(component);
				_replacedEvents.Add(entity, replacedEvent);
			}

			replacedEvent.Next = _defaultValue;
		}

		private ValueReplacedEvent<TValue> Create(IComponent component)
		{
			var castedComponent = component as TComponent;
			var value = _getter(castedComponent);
			if (_replacedEventsPool.Count == 0)
				return new ValueReplacedEvent<TValue>(value, _defaultValue);

			var replacedEvent = _replacedEventsPool.Pop();
			replacedEvent.Last = value;
			return replacedEvent;
		}
	}

	public class ValueReplacedEvent<TValue>
	{
		public TValue Last;
		public TValue Next;

		public ValueReplacedEvent(TValue last, TValue next)
		{
			Last = last;
			Next = next;
		}
	}
}