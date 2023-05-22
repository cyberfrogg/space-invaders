using Cinemachine;
using Game.Models.Camera.Impl;
using JCMG.EntitasRedux;
using UnityEngine;
using Zenject;

namespace Ecs.Views.Linkable.Impl.Camera
{
	public class CameraView : ObjectView
	{
		[SerializeField] private UnityEngine.Camera _camera;
		[SerializeField] private CinemachineBrain _brain;
		[SerializeField] private Transform _projectilePlace;

		[Inject] private PlayerCameraHolder _cameraHolder;

		public override void Link(IEntity entity, IContext context)
		{
			_cameraHolder.SetCamera(_camera);
			_cameraHolder.SetBrain(_brain);
			_cameraHolder.SetProjectilePlace(_projectilePlace);
			base.Link(entity, context);
		}

		public override void OnRotationAdded(GameEntity entity, Quaternion value)
		{
			base.OnRotationAdded(entity, value);
			entity.ReplaceLookDirection(transform.forward);
		}
	}
}