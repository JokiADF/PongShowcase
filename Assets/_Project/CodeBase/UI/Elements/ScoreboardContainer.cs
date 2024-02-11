using System.Collections.Generic;
using _Project.CodeBase.UI.Services.Factory;
using _Project.CodeBase.UI.Services.Scoreboard;
using UnityEngine;
using Zenject;

namespace _Project.CodeBase.UI.Elements
{
    public class ScoreboardContainer : MonoBehaviour
    {
        [SerializeField] private Transform parentForTexts;

        private readonly List<ScoreItemText> _texts = new();
        
        private IScoreboardService _scoreboardService;
        private IUIFactory _uiFactory;

        [Inject]
        private void Construct(IScoreboardService scoreboardService, IUIFactory uiFactory)
        {
            _scoreboardService = scoreboardService;
            _uiFactory = uiFactory;
        }
        
        public void Open()
        {
            var scoreboard = _scoreboardService.Scoreboard;
            var count = scoreboard.Count;
            
            for (var i = 0; i < count; i++)
            {
                var scoreItem = scoreboard[i];

                if (i >= _texts.Count) 
                    _texts.Add(_uiFactory.CreateScoreItemText(parentForTexts));
                _texts[i].SetText(scoreItem.score, scoreItem.date);
            }
        }
    }
}