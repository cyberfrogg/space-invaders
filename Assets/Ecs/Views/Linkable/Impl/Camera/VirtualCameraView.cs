using Cinemachine;
using Game.Models.Camera;
using JCMG.EntitasRedux;
using UnityEngine;
using Inject = Zenject.InjectAttribute;

namespace Ecs.Views.Linkable.Impl.Camera
{
	public class VirtualCameraView : ObjectView
	{
		[SerializeField] private CinemachineVirtualCamera baseCamera;

		[Inject] private IPlayerCameraHolder _cameraHolder;

		public override void Link(IEntity entity, IContext context)
		{
			base.Link(entity, context);
			_cameraHolder.Init(baseCamera);
		}
	}
}