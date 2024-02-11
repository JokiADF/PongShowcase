using UnityEngine;

namespace _Project.CodeBase.Configs
{
    [CreateAssetMenu(menuName = "Configs/AudioConfig", fileName = "AudioConfig", order = 4)]
    public class AudioConfig : ScriptableObject
    {
        [Range(0f, 1f)]
        public float musicVolume = 0.5f;
    }
}