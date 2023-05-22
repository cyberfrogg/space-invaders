using System.Collections.Generic;
using Ecs.Core.Interfaces;
using JCMG.EntitasRedux;

namespace Ecs.Core.Systems
{
	public abstract class FixedReactiveSystem<TEntity> : IReactiveSystem, IFixedSystem
		where TEntity : class, IEntity
	{
		private readonly ICollector<TEntity> _collector;
		private readonly List<TEntity> _buffer;
		private string _toStringCache;

		protected FixedReactiveSystem(IContext<TEntity> context)
		{
			_collector = GetTrigger(context);
			_buffer = new List<TEntity>();
		}

		protected FixedReactiveSystem(ICollector<TEntity> collector)
		{
			_collector = collector;
			_buffer = new List<TEntity>();
		}

		protected abstract ICollector<TEntity> GetTrigger(IContext<TEntity> context);

		protected abstract bool Filter(TEntity entity);

		protected abstract void Execute(List<TEntity> entities);

		public void Activate()
		{
			_collector.Activate();
		}

		public void Deactivate()
		{
			_collector.Deactivate();
		}

		public void Clear()
		{
			_collector.ClearCollectedEntities();
		}

		public void Fixed()
		{
			if (_collector.Count == 0)
				return;
			foreach (var collectedEntity in _collector.CollectedEntities)
			{
				if (!Filter(collectedEntity))
					continue;
				collectedEntity.Retain(this);
				_buffer.Add(collectedEntity);
			}

			_collector.ClearCollectedEntities();
			if (_buffer.Count == 0)
				return;
			Execute(_buffer);
			for (var index = 0; index < _buffer.Count; ++index)
				_buffer[index].Release(this);
			_buffer.Clear();
		}

		public void Update()
		{
		}

		public override string ToString() =>
			_toStringCache ?? (_toStringCache = "ReactiveSystem(" + GetType().Name + ")");

		~FixedReactiveSystem()
		{
			Deactivate();
		}
	}
}