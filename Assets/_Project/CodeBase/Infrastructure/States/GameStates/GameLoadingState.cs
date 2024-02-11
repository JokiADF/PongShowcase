using _Project.CodeBase.Infrastructure.SceneManagement.UI;
using _Project.Scripts.Infrastructure.SceneManagement;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Services.AssetManagement;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public class GameLoadingState : IState
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly IAssetProvider _assetProvider;
        private readonly GameStateMachine _gameStateMachine;

        public GameLoadingState(ILoadingCurtain loadingCurtain, 
            ISceneLoader sceneLoader, 
            IAssetProvider assetProvider,
            GameStateMachine gameStateMachine)
        {
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _assetProvider = assetProvider;
            _gameStateMachine = gameStateMachine;
        }
        
        public async void Enter()
        {
            _loadingCurtain.Show();
            
            await _assetProvider.WarmupAssetsByLabel(AssetName.Lables.GameLoadingState);
            await _sceneLoader.Load(AssetName.Scenes.GameLoadingScene);
            _gameStateMachine.Enter<GameHubState>();
            
            _loadingCurtain.Hide();
        }

        public async UniTask Exit()
        {
            _loadingCurtain.Show();
            
            await _assetProvider.ReleaseAssetsByLabel(AssetName.Lables.GameLoadingState);
        }
    }
}