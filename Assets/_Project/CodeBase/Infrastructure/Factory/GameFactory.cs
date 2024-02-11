using _Project.CodeBase.Core;
using _Project.CodeBase.Core.Ball;
using _Project.CodeBase.Core.Racket;
using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Services.StaticData;
using UnityEngine;
using Zenject;

namespace _Project.CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticData;

        private GameplayController _gameplayController;
        private RacketBehaviour _player;
        private RacketBehaviour _bot;
        private BallBehaviour _ball;

        public GameFactory(IInstantiator instantiator, 
            IAssetProvider assets, 
            IStaticDataService staticData)
        {
            _instantiator = instantiator;
            _assets = assets;
            _staticData = staticData;
        }

        public GameplayController CreateGameplayController()
        {
            if (_gameplayController == null)
            {
                _gameplayController = InstantiatePrefabForComponent<GameplayController>(AssetName.Objects.GameplayController);
                _gameplayController.Initialize(_player, _bot, _ball);
            }
            
            return _gameplayController;
        }

        public RacketBehaviour CreatePlayer()
        {
            if (_player == null)
            {
                _player = InstantiatePrefabForComponent<RacketBehaviour>(AssetName.Objects.Player);
                _player.Initialize(_staticData.Player, _staticData.Level, new PlayerMovement());
            }
            
            return _player;
        }

        public RacketBehaviour CreateBot()
        {
            if (_bot == null)
            {
                _bot = InstantiatePrefabForComponent<RacketBehaviour>(AssetName.Objects.Bot);
                _bot.Initialize(_staticData.Bot, _staticData.Level, new BotMovement(_ball.transform));
            }
            
            return _bot;
        }

        public BallBehaviour CreateBall()
        {
            if (_ball == null)
            {
                _ball = InstantiatePrefabForComponent<BallBehaviour>(AssetName.Objects.Ball);
                _ball.Initialize(_staticData.Ball);
            }
            
            return _ball;
        }

        private GameObject InstantiatePrefab(string assetName)
        {
            var prefab = _assets.Get<GameObject>(assetName);
            return _instantiator.InstantiatePrefab(prefab);
        }

        private TComponent InstantiatePrefabForComponent<TComponent>(string assetName)
            where TComponent : MonoBehaviour
        {
            var prefab = _assets.Get<GameObject>(assetName);
            return _instantiator.InstantiatePrefabForComponent<TComponent>(prefab);
        }
    }
}