using UnityEngine;

namespace _Project.CodeBase.Services.Pool
{
    public interface IPoolingService
    {
        TComponent Spawn<TComponent>(TComponent prefab, Transform parent = null) where TComponent : MonoBehaviour;
        GameObject Spawn(GameObject prefab, Transform parent = null);
        void Despawn(GameObject gameObject);
        void Cleanup();
    }
}