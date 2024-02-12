using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Services.Log;
using _Project.CodeBase.Services.StaticData;
using _Project.CodeBase.UI.Elements;
using _Project.CodeBase.UI.Screens;
using _Project.CodeBase.UI.Services.Screens;
using UnityEngine;
using Zenject;

namespace _Project.CodeBase.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private Transform _uiRoot;
        
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assets;
        private readonly ILogService _log;
        
        private ScreenBase _hud;

        public UIFactory(IInstantiator instantiator, IAssetProvider assets, ILogService log)
        {
            _instantiator = instantiator;
            _assets = assets;
            _log = log;
        }

        public void CreateUIRoot() => 
            _uiRoot = InstantiatePrefab(AssetName.UI.Root).transform;

        public ScreenBase CreateWindow(ScreenId screenId)
        {
            string assetName = default;

            switch (screenId)
            {
                case ScreenId.Menu: assetName = AssetName.UI.Menu; break;
                case ScreenId.ScoreTable: assetName = AssetName.UI.Scoreboard; break;
                case ScreenId.HUD: return CreateHUD();
                case ScreenId.Result: assetName = AssetName.UI.Result; break;
                default: _log.LogError("Not correct id"); break;
            }
            
            var screen = InstantiatePrefabForComponent<ScreenBase>(assetName, _uiRoot);
            
            return screen;
        }

        public ScoreItemText CreateScoreItemText(Transform parent) =>
            InstantiatePrefabForComponent<ScoreItemText>(AssetName.UI.ScoreItemText, parent);

        public VignetteDamage CreateVignetteDamage() =>
            InstantiatePrefabForComponent<VignetteDamage>(AssetName.UI.VignetteDamage, CreateHUD().transform);

        private ScreenBase CreateHUD()
        {
            if(_hud == null)
                _hud = InstantiatePrefabForComponent<ScreenBase>(AssetName.UI.HUD, _uiRoot);
            
            return _hud;
        }

        private GameObject InstantiatePrefab(string assetName)
        {
            var prefab = _assets.Get<GameObject>(assetName);
            return _instantiator.InstantiatePrefab(prefab);
        }
        
        private TComponent InstantiatePrefabForComponent<TComponent>(string assetName, Transform parent = null)
            where TComponent : MonoBehaviour
        {
            var prefab = _assets.Get<GameObject>(assetName);
            return _instantiator.InstantiatePrefabForComponent<TComponent>(prefab, parent);
        }
    }
}