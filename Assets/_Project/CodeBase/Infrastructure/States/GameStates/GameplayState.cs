using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Infrastructure.SceneManagement.UI;
using _Project.CodeBase.UI.Services.Screens;

namespace _Project.CodeBase.Infrastructure.States.GameStates
{
    public class GameplayState : IState
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly IAssetProvider _assetProvider;
        private readonly IScreenService _screenService;

        public GameplayState(ILoadingCurtain loadingCurtain,
            IAssetProvider assetProvider,
            IScreenService screenService)
        {
            _loadingCurtain = loadingCurtain;
            _assetProvider = assetProvider;
            _screenService = screenService;
        }
        
        public void Enter()
        {
            _loadingCurtain.Show();
            
            _screenService.Open(ScreenId.Menu);
            
            _loadingCurtain.Hide();
        }

        public async void Exit()
        {
            _loadingCurtain.Show();
            _assetProvider.Cleanup();
            
            await _assetProvider.ReleaseAssetsByLabel(AssetName.Lables.GameplayState);
            await _assetProvider.ReleaseAssetsByLabel(AssetName.Lables.Ui);
            await _assetProvider.ReleaseAssetsByLabel(AssetName.Lables.Audio);
        }
    }
}