using System;
using _Project.CodeBase.Core.Services.BallTracker;

namespace _Project.CodeBase.Core.Services.GameScoring
{
    public class GameScoringService : IGameScoringService
    {
        private readonly IBallTrackerService _ballTracker;
        
        private int _playerScore;
        private int _botScore;
        public int PlayerScore => _playerScore;
        public int BotScore => _botScore;

        public event Action<int> OnUpdatePlayerScore;
        public event Action<int> OnUpdateBotScore;

        public GameScoringService(IBallTrackerService ballTracker)
        {
            _ballTracker = ballTracker;

            _ballTracker.PlayerScored += IncrementPlayerScore;
            _ballTracker.BotScored += IncrementBotScore;
        }

        ~GameScoringService()
        {
            _ballTracker.PlayerScored -= IncrementPlayerScore;
            _ballTracker.BotScored -= IncrementBotScore;
        }

        private void IncrementPlayerScore()
        {
            _playerScore++;
            OnUpdatePlayerScore?.Invoke(_playerScore);
        }

        private void IncrementBotScore()
        {
            _botScore++;
            OnUpdateBotScore?.Invoke(_botScore);
        }

        public void ResetScores()
        {
            _playerScore = 0;
            _botScore = 0;
            
            OnUpdatePlayerScore?.Invoke(_playerScore);
            OnUpdateBotScore?.Invoke(_botScore);
        }
    }
}