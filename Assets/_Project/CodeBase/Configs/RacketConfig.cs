using UnityEngine;

namespace _Project.CodeBase.Configs
{
    public abstract class RacketConfig: ScriptableObject
    {
        [Tooltip("Vertical speed in m/s.")]
        public float speed = 5.0f;
        [Tooltip("Position of the player at start.")]
        public Vector3 spawnPosition = new(0f, 0f, 0f);
    }
}