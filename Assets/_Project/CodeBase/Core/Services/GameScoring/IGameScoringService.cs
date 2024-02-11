using System;

namespace _Project.CodeBase.Core.Services.Scores
{
    public interface IGameScoringService
    {
        int PlayerScore { get; }
        int BotScore { get; }
        event Action<int> OnUpdatePlayerScore;
        event Action<int> OnUpdateBotScore;
        void ResetScores();
    }
}