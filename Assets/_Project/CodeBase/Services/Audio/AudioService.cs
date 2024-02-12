using System.Collections.Generic;
using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Services.Audio.Factory;
using _Project.CodeBase.Services.Log;
using _Project.CodeBase.Services.StaticData;
using DG.Tweening;
using UnityEngine;

namespace _Project.CodeBase.Services.Audio
{
    public class AudioService : IAudioService
    {
        private readonly IAudioFactory _audioFactory;
        private readonly ILogService _log;
        private readonly IStaticDataService _staticData;
        private readonly Camera _camera;

        private readonly Dictionary<string, AudioClip> _clips = new();

        private float _musicVolume;
        private AudioSource _music;

        private Tween _tween;

        private bool _isPlayingMusic;

        public AudioService(IAudioFactory audioFactory, 
            ILogService log,
            IStaticDataService staticData,
            Camera camera)
        {
            _audioFactory = audioFactory;
            _log = log;
            _staticData = staticData;
            _camera = camera;
        }

        public void Initialize()
        {
            CreateMusic();
            CreateSfxClips();
            _musicVolume = _staticData.Audio.musicVolume;
        }

        public void PlaySfx(string key, float volume)
        {
            if (!_clips.TryGetValue(key, out var clip))
            {
                _log.LogError("Couldn't find the clip");
                return;
            }

            AudioSource.PlayClipAtPoint(clip, _camera.transform.position, volume);
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
        
        private void CreateSfxClips()
        {
            _clips.Add(AssetName.Audio.Clash, _audioFactory.GetClip(AssetName.Audio.Clash));
            _clips.Add(AssetName.Audio.Click, _audioFactory.GetClip(AssetName.Audio.Click));
            _clips.Add(AssetName.Audio.Explosion, _audioFactory.GetClip(AssetName.Audio.Explosion));
        }
    }
}
