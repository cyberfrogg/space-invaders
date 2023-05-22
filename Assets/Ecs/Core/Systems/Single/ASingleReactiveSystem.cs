using System.Collections.Generic;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Core.Systems.Single
{
	public abstract class ASingleReactiveSystem<TEntity> : AReactiveSystemWithPool<TEntity>
		where TEntity : class, IEntity
	{
		protected ASingleReactiveSystem(IContext<TEntity> context) : base(context)
		{
		}

		protected ASingleReactiveSystem(ICollector<TEntity> collector) : base(collector)
		{
		}

		protected sealed override void Execute(List<TEntity> entities)
		{
			if (entities.Count > 1)
			{
				Debug.LogError("Should be only one entity");
			}
			ExecuteOne(entities[0]);
		}

		protected abstract void ExecuteOne(TEntity entity);
	}
}