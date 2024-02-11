using System;
using _Project.CodeBase.Core.Ball;

namespace _Project.CodeBase.Core.Services.BallTracker
{
    public interface IBallTrackerService
    {
        event Action PlayerScored;
        event Action BotScored;
        
        void SetBall(BallBehaviour ball);
    }
}