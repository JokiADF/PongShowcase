using System.Collections.Generic;
using System.Threading.Tasks;
using _Project.CodeBase.Services.Log;
using _Project.CodeBase.UI.Screens;
using _Project.CodeBase.UI.Services.Factory;
using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.UI.Services.Screens
{
    public class ScreenService : IScreenService
    {
        private readonly IUIFactory _uiFactory;
        private readonly Dictionary<ScreenId, ScreenBase> _windows = new();
        
        private ScreenBase _activeScreen;

        public ScreenService(IUIFactory uiFactory) => 
            _uiFactory = uiFactory;

        public void Open(ScreenId screenId)
        {
            var window = GetWindow(screenId);
            ChangeActiveWindow(window);
        }

        private ScreenBase GetWindow(ScreenId screenId)
        {
            if (_windows.TryGetValue(screenId, out var window)) 
                return window;

            _windows.Add(screenId, _uiFactory.CreateWindow(screenId));
            return _windows[screenId];
        }

        private void ChangeActiveWindow(ScreenBase window)
        {
            if (_activeScreen != null) 
                _activeScreen.Close();

            window.Open();
            _activeScreen = window;
        }
    }
}