using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Game.Models.Camera.Impl
{
	public class PlayerCameraHolder : IPlayerCameraHolder
	{
		private Transform _follow;
		private Transform _lookAt;
		private UnityEngine.Camera _camera;
		private Transform _projectilePlace;
		private CinemachineBrain _brain;
		private CinemachineVirtualCamera _baseCamera;


		public Transform LookAt
		{
			get => _lookAt;
			set
			{
				_lookAt = value;
				SetLookAtTarget(_lookAt);
			}
		}

		public Transform Follow
		{
			get => _follow;
			set
			{
				_follow = value;
				SetFollowTarget(_lookAt);
			}
		}

		public void SetEnabled(bool enabled)
		{
			_camera.enabled = enabled;
		}

		public T GetLiveCameraComponent<T>(CinemachineCore.Stage stage)
			where T : CinemachineComponentBase
		{
			var camera = _baseCamera;
			return camera.GetCinemachineComponent(stage) as T;
		}

		public void Init(CinemachineVirtualCamera baseCamera)
		{
			_baseCamera = baseCamera;
			
			VirtualCameras = new CinemachineVirtualCamera[]
			{
				baseCamera
			};
			
			SetFollowTarget(_follow);
			SetLookAtTarget(_lookAt);
		}

		public IReadOnlyList<CinemachineVirtualCamera> VirtualCameras { get; private set; } =
			Array.Empty<CinemachineVirtualCamera>();
		

		private void SetFollowTarget(Transform follow)
		{
			if (_baseCamera)
				_baseCamera.Follow = follow;
		}

		private void SetLookAtTarget(Transform lookAt)
		{
			if (_baseCamera)
				_baseCamera.LookAt = lookAt;
		}

		public void SetCamera(UnityEngine.Camera camera)
		{
			_camera = camera;
		}

		public void SetBrain(CinemachineBrain brain)
		{
			_brain = brain;
		}

		public void SetProjectilePlace(Transform projectilePlace)
		{
			_projectilePlace = projectilePlace;
		}


		public UnityEngine.Camera GetCamera() => _camera;


		public Transform GetProjectilePlace => _projectilePlace;


		public void Update()
		{
			if (_brain == null)
				return;

			_brain.ManualUpdate();
			SetRotationZToZero();
		}

		private void SetRotationZToZero()
		{
			var transform = _camera.transform;
			var rotation = transform.rotation;
			var eulerAngles = rotation.eulerAngles;
			eulerAngles.z = 0;
			rotation.eulerAngles = eulerAngles;
			transform.rotation = rotation;
		}
	}
}