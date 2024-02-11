using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Project.CodeBase.Services.Pool
{
    public struct Pool
    {
        private readonly GameObject _prefab;
        private readonly IInstantiator _instantiator;

        private readonly Queue<GameObject> _objects;
        private readonly Lazy<Scene> _rootScene;
        
        public Pool(GameObject prefab, IInstantiator instantiator)
        {
            _prefab = prefab;
            _instantiator = instantiator;
            
            _objects = new Queue<GameObject>();
            _rootScene = new Lazy<Scene>(() => SceneManager.CreateScene($"[Pool] {prefab.name}"));
        }
        
        public GameObject Spawn(Transform parent)
        {
            if (!_objects.TryDequeue(out var result))
                result = _instantiator.InstantiatePrefab(_prefab);
            
            result.transform.SetParent(parent, false);
            result.SetActive(true);
            
            return result;
        }

        public void Despawn(GameObject gameObject)
        {
            gameObject.SetActive(false);
            SceneManager.MoveGameObjectToScene(gameObject, _rootScene.Value);
            
            _objects.Enqueue(gameObject);
        }

        public void Cleanup()
        {
            SceneManager.UnloadSceneAsync(_rootScene.Value);
            
            _objects.Clear();
        }
    }
}