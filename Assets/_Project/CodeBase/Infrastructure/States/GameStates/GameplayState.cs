using _Project.CodeBase.Infrastructure.SceneManagement.UI;
using _Project.CodeBase.Services.Pool;
using _Project.Scripts.Infrastructure.SceneManagement;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Services.AssetManagement;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public class GameplayState : IState
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly IAssetProvider _assetProvider;
        private readonly IPoolingService _poolingService;

        public GameplayState(ILoadingCurtain loadingCurtain, 
            ISceneLoader sceneLoader,
            IAssetProvider assetProvider,
            IPoolingService poolingService)
        {
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _assetProvider = assetProvider;
            _poolingService = poolingService;
        }
        
        public async void Enter()
        {
            _loadingCurtain.Show();
            
            await _assetProvider.WarmupAssetsByLabel(AssetName.Lables.GameLoopState);
            await _sceneLoader.Load(AssetName.Scenes.GameLoopScene);
            
            _loadingCurtain.Hide();
        }

        public async UniTask Exit()
        {
            _loadingCurtain.Show();
            
            _poolingService.Cleanup();
            await _assetProvider.ReleaseAssetsByLabel(AssetName.Lables.GameLoopState);
        }
    }
}