using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace _Project.CodeBase.Infrastructure.SceneManagement.UI
{
    public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        [SerializeField] private CanvasGroup group;
        [SerializeField] private TextMeshProUGUI text;

        private readonly string[] _loadingTexts = {
            "Loading", "Loading.", "Loading..", "Loading..."
        };
        
        private void Awake() => 
            DontDestroyOnLoad(this);

        public void Show()
        {
            gameObject.SetActive(true);
            group.alpha = 1;
            
            UpdateLoadingText();
        }

        public void Hide() => DoFadeIn();

        private async void DoFadeIn()
        {
            while (group.alpha > 0)
            {
                group.alpha -= 0.03f;
                await UniTask.Delay(TimeSpan.FromSeconds(0.03));
            }
      
            gameObject.SetActive(false);
        }
        
        private async void UpdateLoadingText()
        {
            while (gameObject.activeSelf)
            {
                var tick = (int)(Time.time / 0.25f);
                text.text = _loadingTexts[tick % _loadingTexts.Length];
                
                await UniTask.Delay(TimeSpan.FromSeconds(0.25));
            }
        }
    }
}
