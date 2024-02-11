using _Project.CodeBase.Core;
using _Project.CodeBase.Core.Ball;
using _Project.CodeBase.Core.Racket;

namespace _Project.CodeBase.Infrastructure.Factory
{
    public interface IGameFactory
    {
        GameplayController CreateGameplayController();
        BallBehaviour CreateBall();
        RacketBehaviour CreatePlayer();
        RacketBehaviour CreateBot();
    }
}