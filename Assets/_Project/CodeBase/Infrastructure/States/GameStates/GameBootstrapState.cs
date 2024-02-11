using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Services.StaticData;
using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Infrastructure.States.GameStates
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
            
            _gameStateMachine.Enter<GameLoadingState>();
        }

        public void Exit() {}

        private async UniTask InitializeServices()
        {
            await _assetProvider.InitializeAsync();
            await _staticDataService.InitializeAsync();
        }
    }
}