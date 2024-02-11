using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Infrastructure.Factory;
using _Project.CodeBase.Infrastructure.SceneManagement;
using _Project.CodeBase.Infrastructure.SceneManagement.UI;
using _Project.CodeBase.UI.Services.Factory;

namespace _Project.CodeBase.Infrastructure.States.GameStates
{
    public class GameLoadingState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly IAssetProvider _assetProvider;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;

        public GameLoadingState(GameStateMachine gameStateMachine,
            ILoadingCurtain loadingCurtain, 
            ISceneLoader sceneLoader, 
            IAssetProvider assetProvider,
            IGameFactory gameFactory,
            IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _assetProvider = assetProvider;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
        }
        
        public async void Enter()
        {
            _loadingCurtain.Show();
            
            await _assetProvider.WarmupAssetsByLabel(AssetName.Lables.GameplayState);
            await _assetProvider.WarmupAssetsByLabel(AssetName.Lables.Ui);
            
            InitializeGameWorld();
            await _sceneLoader.Load(AssetName.Scenes.GameplayScene, EnterGameplayState);

            _loadingCurtain.Hide();
        }

        public void Exit() => 
            _loadingCurtain.Show();

        private void InitializeGameWorld()
        {
            var ball = _gameFactory.CreateBall();
            ball.gameObject.SetActive(false);

            var player = _gameFactory.CreatePlayer();
            player.gameObject.SetActive(false);

            var bot = _gameFactory.CreateBot();
            bot.gameObject.SetActive(false);
            
            _gameFactory.CreateGameplayController();
            _uiFactory.CreateUIRoot();
        }

        private void EnterGameplayState() => _gameStateMachine.Enter<GameplayState>();
    }
}