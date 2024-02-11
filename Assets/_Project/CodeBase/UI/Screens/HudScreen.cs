using _Project.CodeBase.Core;
using _Project.CodeBase.Infrastructure.Factory;
using Zenject;

namespace _Project.CodeBase.UI.Screens
{
    public class HudScreen : ScreenBase
    {
        private GameplayController _gameplayController;
        
        [Inject]
        private void Construct(IGameFactory gameFactory) => 
            _gameplayController = gameFactory.CreateGameplayController();

        public override void Open()
        {
            base.Open();
            
            _gameplayController.StartGame();
        }
        
        public override void Close()
        {
            base.Close();
            
            _gameplayController.EndGame();
        }
    }
}