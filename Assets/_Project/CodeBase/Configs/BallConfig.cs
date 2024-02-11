using UnityEngine;

namespace _Project.CodeBase.Configs
{
    [CreateAssetMenu(menuName = "Configs/BallConfig", fileName = "BallConfig", order = 3)]
    public class BallConfig : ScriptableObject
    {
        [Tooltip("Speed in m/s.")]
        public float speed = 4f;
        [Tooltip("Rebound force")]
        public float bounceStrength = 5f;
        [Tooltip("Spawn position")]
        public Vector3 spawnPosition;
    }
}