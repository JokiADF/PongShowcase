using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Services.Audio;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.CodeBase.UI.Elements
{
    public class ButtonSfx : MonoBehaviour
    {
        [SerializeField] private Button button;
        
        private IAudioService _audioService;

        [Inject]
        public void Construct(IAudioService audioService) => 
            _audioService = audioService;

        private void Awake() =>
            button.onClick.AddListener(PlaySfx);
    
        private void PlaySfx() => 
            _audioService.PlaySfx(AssetName.Audio.Click, 0.55f);
    }
}
