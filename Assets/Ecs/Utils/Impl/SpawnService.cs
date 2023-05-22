using System;
using Db.Objects;
using Db.Prefabs;
using Ecs.Views.Linkable;
using Game.Services.Pool;
using UnityEngine;
using Zenject;

namespace Ecs.Utils.Impl
{
	public class SpawnService : ISpawnService<GameEntity, ILinkable>
	{
		private readonly DiContainer _container;
		private readonly IPrefabsBase _prefabsBase;
		private readonly IObjectBase _objectBase;
		private readonly IPrefabPoolService _prefabPoolService;

		public SpawnService(
			DiContainer container,
			IPrefabsBase prefabsBase,
			IObjectBase objectBase,
			IPrefabPoolService prefabPoolService
		)
		{
			_container = container;
			_prefabsBase = prefabsBase;
			_objectBase = objectBase;
			_prefabPoolService = prefabPoolService;
		}

		public ILinkable Spawn(GameEntity entity)
		{
			
			var position = entity.HasPosition ? entity.Position.Value : Vector3.zero;
			if (entity.HasObjectType)
				return InstantiateLinkable(position, _objectBase.Get(entity.ObjectType.Value));

			if (entity.HasPrefab)
			{
				var prefabName = entity.Prefab.Value;
				return _prefabPoolService.Spawn(prefabName, position, Quaternion.identity, out var linkable)
					? linkable
					: InstantiateLinkable(position, _prefabsBase.Get(prefabName));
			}

			throw new Exception($"[SpawnService] Can't instantiate entity with uid: " + entity);
		}

		private ILinkable InstantiateLinkable(Vector3 position, GameObject prefab)
		{
			var gameObject = _container.InstantiatePrefab(prefab, position, Quaternion.identity, null);
			return gameObject.GetComponent<ILinkable>();
		}

		private void ApplyEntityValues(GameEntity entity, Transform transform)
		{
			var position = entity.HasPosition ? entity.Position.Value : Vector3.zero;
			var rotation = entity.HasRotation ? entity.Rotation.Value : Quaternion.identity;
			transform.SetPositionAndRotation(position, rotation);
		}
	}
}