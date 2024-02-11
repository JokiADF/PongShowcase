using _Project.CodeBase.Core.Ball;
using _Project.CodeBase.Core.Racket;
using _Project.CodeBase.Core.Services.BallTracker;
using _Project.CodeBase.Core.Services.Scores;
using _Project.CodeBase.Services.StaticData;
using UnityEngine;
using Zenject;

namespace _Project.CodeBase.Core
{
    public class GameplayController : MonoBehaviour
    {
        private RacketBehaviour _player;
        private RacketBehaviour _bot;
        private BallBehaviour _ball;

        private IBallTrackerService _ballTracker;
        private IStaticDataService _staticData;
        private IGameScoringService _gameScoringService;

        [Inject]
        private void Construct(IBallTrackerService ballTracker, 
            IStaticDataService staticData,
            IGameScoringService gameScoringService)
        {
            _ballTracker = ballTracker;
            _staticData = staticData;
            _gameScoringService = gameScoringService;
        }

        public void Initialize(RacketBehaviour player, RacketBehaviour bot, BallBehaviour ball)
        {
            _player = player;
            _bot = bot;
            _ball = ball;
            
            _ballTracker.SetBall(_ball);
        }

        public void StartGame()
        {
            _gameScoringService.ResetScores();
            ResetObjectsPosition();
            
            SetActiveObjects(true);
            Subscribe();
            
            _ball.TakeFly();
        }

        public void EndGame()
        {
            SetActiveObjects(false);
            Unsubscribe();
        }

        private void ResetObjectsPosition()
        {
            _player.ResetPosition();
            _bot.ResetPosition();
            _ball.ResetPosition();
        }

        private void SetActiveObjects(bool value)
        {
            _player.gameObject.SetActive(value);
            _bot.gameObject.SetActive(value);
            _ball.gameObject.SetActive(value);
        }

        private void Subscribe()
        {
            _gameScoringService.OnUpdateBotScore += CheckAttempts;
            _ballTracker.PlayerScored += RetakeFlyBall;
            _ballTracker.BotScored += RetakeFlyBall;
        }

        private void Unsubscribe()
        {
            _gameScoringService.OnUpdateBotScore -= CheckAttempts;
            _ballTracker.PlayerScored -= RetakeFlyBall;
            _ballTracker.BotScored -= RetakeFlyBall;
        }

        private void RetakeFlyBall()
        {
            _ball.TakeFly();
        }

        private void CheckAttempts(int score)
        {
            if (score >= _staticData.Level.playerAttempts)
                OnPlayerLose();
        }

        private void OnPlayerLose()
        {
            EndGame();
        }
        
    }
}