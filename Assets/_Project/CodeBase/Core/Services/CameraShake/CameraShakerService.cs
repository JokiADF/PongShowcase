using DG.Tweening;
using UnityEngine;

namespace _Project.CodeBase.Gameplay.Services.CameraShake
{
    public class CameraShakerService : ICameraShakerService
    {
        private readonly Camera _camera;
        private readonly Vector3 _defaultPositionForCamera;

        private CameraShakerService(Camera camera)
        {
            _camera = camera;
            _defaultPositionForCamera = _camera.transform.position;
        }

        public void Shake(float duration, float strength) =>
            _camera.transform
                .DOShakePosition(duration, strength, 75)
                .OnComplete(() => _camera.transform.position = _defaultPositionForCamera);
    }
}
