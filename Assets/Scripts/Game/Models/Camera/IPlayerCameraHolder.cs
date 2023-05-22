using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Game.Models.Camera
{
	public interface IPlayerCameraHolder : ICameraHolder
	{
		Transform GetProjectilePlace { get; }
		Transform Follow { get; set; }
		Transform LookAt { get; set; }
		void Init(CinemachineVirtualCamera baseCamera);
		IReadOnlyList<CinemachineVirtualCamera> VirtualCameras { get; }
		void Update();
		void SetEnabled(bool enabled);

		T GetLiveCameraComponent<T>(CinemachineCore.Stage stage) where T : CinemachineComponentBase;
	}
}