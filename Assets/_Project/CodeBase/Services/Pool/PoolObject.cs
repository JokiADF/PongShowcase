using UnityEngine;

namespace _Project.CodeBase.Services.Pool
{
    public abstract class PoolObject : MonoBehaviour
    {
        public abstract void OnSpawned(Vector3 position);
        public abstract void OnDespawned();
    }
}