using System.Collections.Generic;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Core.Systems.Single
{
	public abstract class ASingleDestroyedReactiveSystem<TEntity> : AReactiveSystemWithPool<TEntity>
		where TEntity : class, IEntity, IDestroyedEntity
	{
		protected ASingleDestroyedReactiveSystem(IContext<TEntity> context) : base(context)
		{
		}

		protected ASingleDestroyedReactiveSystem(ICollector<TEntity> collector) : base(collector)
		{
		}

		protected sealed override void Execute(List<TEntity> entities)
		{
			if (entities.Count > 1)
			{
				Debug.LogError("Should be only one entity");
			}
			
			ExecuteOne(entities[0]);

			foreach (var entity in entities)
			{
				entity.IsDestroyed = true;
			}
		}

		protected abstract void ExecuteOne(TEntity entity);
	}
}