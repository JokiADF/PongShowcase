using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Infrastructure.Factory;
using _Project.CodeBase.Infrastructure.SceneManagement;
using _Project.CodeBase.Infrastructure.SceneManagement.UI;

namespace _Project.CodeBase.Infrastructure.States.GameStates
{
    public class GameLoadingState : IState
    {
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly ISceneLoader _sceneLoader;
        private readonly IAssetProvider _assetProvider;
        private readonly IGameFactory _gameFactory;
        private readonly GameStateMachine _gameStateMachine;

        public GameLoadingState(GameStateMachine gameStateMachine,
            ILoadingCurtain loadingCurtain, 
            ISceneLoader sceneLoader, 
            IAssetProvider assetProvider,
            IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _loadingCurtain = loadingCurtain;
            _sceneLoader = sceneLoader;
            _assetProvider = assetProvider;
            _gameFactory = gameFactory;
        }
        
        public async void Enter()
        {
            _loadingCurtain.Show();
            
            await _assetProvider.WarmupAssetsByLabel(AssetName.Lables.GameplayState);
            InitializeGameWorld();
            await _sceneLoader.Load(AssetName.Scenes.GameplayScene, EnterGameplayState);

            _loadingCurtain.Hide();
        }

        public void Exit()
        {
            _loadingCurtain.Show();
        }
        
        private void InitializeGameWorld()
        {
            var ball = _gameFactory.CreateBall();
            ball.gameObject.SetActive(false);

            var player = _gameFactory.CreatePlayer();
            player.gameObject.SetActive(false);

            var bot = _gameFactory.CreateBot();
            bot.gameObject.SetActive(false);
            
            _gameFactory.CreateGameplayController();
        }

        private void EnterGameplayState() => _gameStateMachine.Enter<GameplayState>();
    }
}