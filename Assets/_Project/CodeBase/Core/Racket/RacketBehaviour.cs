using _Project.CodeBase.Data.Configs;
using UnityEngine;

namespace _Project.CodeBase.Core.Racket
{
    public class RacketBehaviour : MonoBehaviour
    {
        private IRocketMovement _movement;
    
        private Vector3 _position;

        private RacketConfig _racketConfig;
        private LevelConfig _levelConfig;

        public void Initialize(RacketConfig racketConfig, LevelConfig levelConfig, IRocketMovement movement)
        {
            _racketConfig = racketConfig;
            _levelConfig = levelConfig;
            _movement = movement;

            transform.position = _racketConfig.spawnPosition;
        
            _movement.Initialize(_levelConfig, _racketConfig.speed);
        }

        public void ResetPosition() => 
            transform.position = _racketConfig.spawnPosition;

        private void Update() => 
            transform.position = _movement.Move(transform.position);
    }
}