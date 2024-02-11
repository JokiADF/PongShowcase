using UnityEngine;

namespace _Project.CodeBase.Services.Audio.Factory
{
    public interface IAudioFactory
    {
        AudioClip GetClip(string key);
    }
}