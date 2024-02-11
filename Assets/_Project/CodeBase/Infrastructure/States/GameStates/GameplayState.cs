using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Infrastructure.Factory;
using _Project.CodeBase.Infrastructure.SceneManagement.UI;

namespace _Project.CodeBase.Infrastructure.States.GameStates
{
    public class GameplayState : IState
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly IAssetProvider _assetProvider;
        private readonly IGameFactory _gameFactcory;

        public GameplayState(ILoadingCurtain loadingCurtain,
            IAssetProvider assetProvider,
            IGameFactory gameFactcory)
        {
            _loadingCurtain = loadingCurtain;
            _assetProvider = assetProvider;
            _gameFactcory = gameFactcory;
        }
        
        public void Enter()
        {
            _loadingCurtain.Show();
            
            _loadingCurtain.Hide();
            
            _gameFactcory.CreateGameplayController().StartGame();
        }

        public async void Exit()
        {
            _loadingCurtain.Show();
            _assetProvider.Cleanup();
            
            await _assetProvider.ReleaseAssetsByLabel(AssetName.Lables.GameplayState);
        }
    }
}