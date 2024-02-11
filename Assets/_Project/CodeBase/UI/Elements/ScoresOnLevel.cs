using _Project.CodeBase.Core.Services.GameScoring;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.CodeBase.UI.Elements
{
    public class ScoresOnLevel : MonoBehaviour
    {
        [SerializeField] private TextMeshPro playerScore;
        [SerializeField] private TextMeshPro botScore;

        private IGameScoringService _scoringService;
        
        [Inject] 
        private void Construct(IGameScoringService scoringService) => 
            _scoringService = scoringService;
        
        private void SetValuePlayerScore(int value) => 
            playerScore.text = value.ToString();
        
        private void SetValueBotScore(int value) => 
            botScore.text = value.ToString();

        private void OnEnable()
        {
            _scoringService.OnUpdatePlayerScore += SetValuePlayerScore;
            _scoringService.OnUpdateBotScore += SetValueBotScore;
        }
        
        private void OnDisable()
        {
            _scoringService.OnUpdatePlayerScore -= SetValuePlayerScore;
            _scoringService.OnUpdateBotScore -= SetValueBotScore;
        }
    }
}