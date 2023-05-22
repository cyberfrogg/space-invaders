namespace Game.Models.Camera.Impl
{
    public class UiCameraHolder : IUiCameraHolder
    {
        private readonly UnityEngine.Camera _camera;

        public UiCameraHolder(UnityEngine.Camera camera)
        {
            _camera = camera;
        }

        public UnityEngine.Camera GetCamera() => _camera;
    }
}