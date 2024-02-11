using System;
using _Project.CodeBase.Core.Services.GameScoring;
using _Project.CodeBase.Data;
using _Project.CodeBase.UI.Elements;
using _Project.CodeBase.UI.Services.Scoreboard;
using UnityEngine;
using Zenject;

namespace _Project.CodeBase.UI.Screens
{
    public class ResultScreen : ScreenBase
    {
        [SerializeField] private ScoreOnResult score;
        
        private IGameScoringService _scoringService;
        private IScoreboardService _scoreboardService;

        [Inject]
        private void Construct(IGameScoringService scoringService, IScoreboardService scoreboardService)
        {
            _scoringService = scoringService;
            _scoreboardService = scoreboardService;
        }
        
        public override void Open()
        {
            score.UpdateValueScore(_scoringService.PlayerScore);
            
            if(_scoringService.PlayerScore > 0)
                _scoreboardService.Add(new ScoreItem
                {
                    score = _scoringService.PlayerScore,
                    date = DateTime.Now.ToString("MM/dd/yyyy HH:mm")
                });
            
            base.Open();
        }
    }
}