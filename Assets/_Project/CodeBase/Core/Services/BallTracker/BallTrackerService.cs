using System;
using _Project.CodeBase.Core.Ball;
using _Project.CodeBase.Services.StaticData;
using UniRx;
using UnityEngine;

namespace _Project.CodeBase.Core.Services.BallTracker
{
    public class BallTrackerService : IBallTrackerService
    {
        private readonly IStaticDataService _staticData;

        public event Action PlayerScored;
        public event Action BotScored;

        private BallTrackerService(IStaticDataService staticData) => 
            _staticData = staticData;

        public void SetBall(BallBehaviour ball) => 
            ball.Position
                .Subscribe(CheckBallPosition)
                .AddTo(ball);

        private void CheckBallPosition(Vector3 position)
        {
            if (_staticData.Level.IsPosOutOfVerticalBounds(position))
            {
                if (position.y < 0)
                    BotScored?.Invoke();
                else
                    PlayerScored?.Invoke();
            }
        }
    }
}