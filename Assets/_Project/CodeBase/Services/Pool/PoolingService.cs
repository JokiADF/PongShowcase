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

        public TComponent Spawn<TComponent>(TComponent prefab, Transform parent = null) where TComponent : MonoBehaviour
        {
            var spawnedObject = Spawn(prefab.gameObject, parent);
            return spawnedObject.GetComponent<TComponent>();
        }

        public GameObject Spawn(GameObject prefab, Transform parent = null)
        {
            var prefabId = prefab.GetInstanceID();

            if (!_usablePools.TryGetValue(prefabId, out var pool)) 
                pool = CreateNewPool(prefab, prefabId);

            _storablePools.Add(prefabId, pool);
            
            var instance = pool.Spawn(parent);
            return instance;
        }

        public void Despawn(GameObject gameObject)
        {
            var instanceID = gameObject.GetInstanceID();
            
            if(_storablePools.TryGetValue(instanceID, out var pool))
            {
                _storablePools.Remove(instanceID);
                pool.Despawn(gameObject);
            }
        }
        
        public void Cleanup()
        {
            foreach (var pool in _usablePools)
                pool.Value.Cleanup();
            
            _usablePools.Clear();
            _storablePools.Clear();
        }

        private Pool CreateNewPool(GameObject prefab, int prefabId)
        {
            var pool = new Pool(prefab, _instantiator);
            _usablePools.Add(prefabId, pool);
            return pool;
        }
    }
}