using Ecs.Views.Linkable;
using Game.Models.Camera;
using UnityEngine;

namespace Game.Utils.Raycast.Impl
{
	public class RayCastProvider : IRayCastProvider
	{
		private const float START_RAY_CAST_Y = 10f;

		private readonly GameContext _game;
		private readonly IPlayerCameraHolder _playerCameraHolder;

		private Vector3 _position = new Vector3(0, START_RAY_CAST_Y, 0);
		private Ray _ray = new Ray(Vector3.zero, Vector3.down);

		private RaycastHit _hit;

		public RayCastProvider(GameContext game, IPlayerCameraHolder playerCameraHolder)
		{
			_game = game;
			_playerCameraHolder = playerCameraHolder;
		}

		public Vector3 GetHitPoint(int layer, out Vector3 hitNormal, out float distance, out int objectHash)
		{
			objectHash = -1;
			hitNormal = Vector3.zero;
			distance = 50f;
			var camera = _playerCameraHolder.GetCamera();
			if (camera == null)
				return Vector3.zero;

			var transform = camera.transform;
			_ray = new Ray(transform.position, transform.forward);
			if (!Physics.Raycast(_ray.origin, _ray.direction, out _hit,
				    distance, layer, QueryTriggerInteraction.Ignore))
				return Vector3.zero;

			hitNormal = _hit.normal;
			distance = _hit.distance;
			var component = _hit.collider.transform.GetComponent<IObjectHash>();
			objectHash = component?.Hash ?? -1;
			return _hit.point;
		}

		public bool Raycast(
			Vector3 origin,
			Vector3 direction,
			out RaycastHit hit,
			float distance,
			int layerMask,
			QueryTriggerInteraction triggerInteraction
		)
			=> Physics.Raycast(origin, direction, out hit, distance, layerMask, triggerInteraction);

		public bool SphereCast(
			Vector3 origin,
			float radius,
			Vector3 direction,
			out RaycastHit hit,
			float distance,
			int layerMask,
			QueryTriggerInteraction triggerInteraction
		)
			=> Physics.SphereCast(origin, radius, direction, out hit, distance, layerMask, triggerInteraction);

		public int OverlapSphereNonAlloc(
			Vector3 origin,
			float radius,
			Collider[] buffer,
			int layerMask,
			QueryTriggerInteraction triggerInteraction
		)
			=> Physics.OverlapSphereNonAlloc(origin, radius, buffer, layerMask, triggerInteraction);

		public int SphereCastNonAlloc(
			Vector3 origin,
			float radius,
			Vector3 direction,
			RaycastHit[] buffer,
			float distance,
			int layerMask,
			QueryTriggerInteraction triggerInteraction
		)
			=> Physics.SphereCastNonAlloc(origin, radius, direction, buffer, distance, layerMask, triggerInteraction);

		public int OverlapBoxNonAlloc(
			Vector3 center,
			Vector3 halfExtents,
			Collider[] results,
			Quaternion orientation,
			int mask,
			QueryTriggerInteraction queryTriggerInteraction
		)
			=> Physics.OverlapBoxNonAlloc(center, halfExtents, results, orientation, mask, queryTriggerInteraction);
	}
}