using System.Collections.Generic;
using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Services.Audio.Factory;
using _Project.CodeBase.Services.Log;
using _Project.CodeBase.Services.StaticData;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace _Project.CodeBase.Services.Audio
{
    public class AudioService : IAudioService
    {
        private readonly IAudioFactory _audioFactory;
        private readonly ILogService _log;
        private readonly IStaticDataService _staticData;

        private float _musicVolume;
        private AudioSource _music;

        private Transform _cameraTransform;
        private Tween _tween;

        private bool _isPlayingMusic;

        public AudioService(IAudioFactory audioFactory, 
            ILogService log,
            IStaticDataService staticData)
        {
            _audioFactory = audioFactory;
            _log = log;
            _staticData = staticData;
        }

        public void Initialize()
        {
            CreateMusic();
            _musicVolume = _staticData.Audio.musicVolume;
        }

        public void PlayMusic()
        {
            _isPlayingMusic = true;
            
            _tween?.Kill();
            _tween = _music.DOFade(_musicVolume, 1.5f)
                .SetEase(Ease.InQuad)
                .OnStart(() =>
                {
                    _music.volume = 0f;
                    _music.Play();
                })
                .OnComplete(() => _music.volume = _musicVolume);
            
            _log.Log("Music started to play");
        }

        public void StopMusic()
        {
            _isPlayingMusic = false;
            
            _tween?.Kill();
            _tween = _music.DOFade(0f, 1.5f)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    _music.volume = 0f;
                    _music.Stop();
                });
            
            _log.Log("Music stopped to play");
        }

        public void DuckMusic(float targetVolume, float duration)
        {
            if(_isPlayingMusic)
            {
                _tween?.Kill();
                _tween = _music.DOFade(targetVolume, duration)
                    .SetEase(Ease.OutQuad)
                    .SetLoops(1, LoopType.Yoyo)
                    .OnComplete(() => _music.volume = _musicVolume);
            }
        }

        private void CreateMusic()
        {
            var clip = _audioFactory.GetClip(AssetName.Audio.Music);
            
            var go = new GameObject("Music");
            Object.DontDestroyOnLoad(go);
            
            _music = go.AddComponent<AudioSource>();
            _music.clip = clip;
            _music.spatialBlend = 0;
            _music.volume = 0;
            _music.loop = true;
        }
    }
}
