using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Project.CodeBase.Services.Pool
{
    public struct Pool
    {
        private readonly PoolObject _prefab;
        private readonly IInstantiator _instantiator;

        private readonly Queue<PoolObject> _objects;
        private readonly Lazy<Scene> _rootScene;
        
        public Pool(PoolObject prefab, IInstantiator instantiator)
        {
            _prefab = prefab;
            _instantiator = instantiator;
            
            _objects = new Queue<PoolObject>();
            _rootScene = new Lazy<Scene>(() => SceneManager.CreateScene($"[Pool] {prefab.name}"));
        }
        
        public PoolObject Spawn(Transform parent, Vector3 spawnPosition)
        {
            if (!_objects.TryDequeue(out var result))
                result = _instantiator.InstantiatePrefabForComponent<PoolObject>(_prefab);
            
            result.transform.SetParent(parent, false);
            result.gameObject.SetActive(true);
            result.OnSpawned(spawnPosition);
            
            return result;
        }

        public void Despawn(PoolObject poolObject)
        {
            poolObject.OnDespawned();
            poolObject.gameObject.SetActive(false);
            SceneManager.MoveGameObjectToScene(poolObject.gameObject, _rootScene.Value);
            
            _objects.Enqueue(poolObject);
        }

        public void Cleanup()
        {
            SceneManager.UnloadSceneAsync(_rootScene.Value);
            
            _objects.Clear();
        }
    }
}