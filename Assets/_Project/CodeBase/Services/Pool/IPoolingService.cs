using UnityEngine;

namespace _Project.CodeBase.Services.Pool
{
    public interface IPoolingService
    {
        TComponent SpawnForComponent<TComponent>(TComponent prefab, Vector3 spawnPosition, Transform parent = null) where TComponent : PoolObject;
        PoolObject Spawn(PoolObject prefab, Vector3 spawnPosition, Transform parent = null);
        void Despawn(PoolObject poolObject);
        void Cleanup();
    }
}