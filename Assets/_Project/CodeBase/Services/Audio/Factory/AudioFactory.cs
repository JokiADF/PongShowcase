using _Project.CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace _Project.CodeBase.Services.Audio.Factory
{
    public class AudioFactory : IAudioFactory
    {
        private readonly IAssetProvider _assetProvider;

        public AudioFactory(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        public AudioClip GetClip(string key) => 
            _assetProvider.Get<AudioClip>(key);
    }
}