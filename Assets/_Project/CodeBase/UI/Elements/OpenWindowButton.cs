using _Project.CodeBase.UI.Services.Screens;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.CodeBase.UI.Elements
{
    public class OpenWindowButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private ScreenId screenId;
        
        private IScreenService _screenService;

        [Inject]
        public void Construct(IScreenService screenService) => 
            _screenService = screenService;

        private void Awake() => 
            button.onClick.AddListener(Open);

        private void Open() => 
            _screenService.Open(screenId);
    }
}