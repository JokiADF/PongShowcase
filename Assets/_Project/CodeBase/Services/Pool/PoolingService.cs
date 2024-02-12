using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.CodeBase.Services.Pool
{
    public class PoolingService : IPoolingService
    {
        private readonly IInstantiator _instantiator;
        private readonly Dictionary<int, Pool> _usablePools = new();
        private readonly Dictionary<int, Pool> _storablePools = new();

        public PoolingService(IInstantiator instantiator) => 
            _instantiator = instantiator;

        public TComponent SpawnForComponent<TComponent>(TComponent prefab, Vector3 spawnPosition,
            Transform parent = null) where TComponent : PoolObject
        {
            var spawnedObject = Spawn(prefab, spawnPosition, parent);
            return spawnedObject.GetComponent<TComponent>();
        }

        public PoolObject Spawn(PoolObject prefab, Vector3 spawnPosition, Transform parent = null)
        {
            var prefabId = prefab.GetInstanceID();

            if (!_usablePools.TryGetValue(prefabId, out var pool)) 
                pool = CreateNewPool(prefab, prefabId);
            
            var instance = pool.Spawn(parent, spawnPosition);
            _storablePools.Add(instance.GetInstanceID(), pool);
            
            return instance;
        }

        public void Despawn(PoolObject poolObject)
        {
            var instanceID = poolObject.GetInstanceID();
            
            if(_storablePools.TryGetValue(instanceID, out var pool))
            {
                _storablePools.Remove(instanceID);
                pool.Despawn(poolObject);
            }
        }
        
        public void Cleanup()
        {
            foreach (var pool in _usablePools)
                pool.Value.Cleanup();
            
            _usablePools.Clear();
            _storablePools.Clear();
        }

        private Pool CreateNewPool(PoolObject prefab, int prefabId)
        {
            var pool = new Pool(prefab, _instantiator);
            _usablePools.Add(prefabId, pool);
            return pool;
        }
    }
}