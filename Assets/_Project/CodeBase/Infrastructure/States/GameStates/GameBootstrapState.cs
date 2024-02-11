using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Services.StaticDataService;
using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public class GameBootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;

        public GameBootstrapState(GameStateMachine gameStateMachine,
            IAssetProvider assetProvider,
            IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }

        public async void Enter()
        {
            await InitializeServices();
            
            _gameStateMachine.Enter<GameHubState>();
        }

        private async UniTask InitializeServices()
        {
            await _assetProvider.InitializeAsync();
            await _staticDataService.InitializeAsync();
        }

        public UniTask Exit() =>
            default;
    }
}