using _Project.CodeBase.Data.Configs;
using UnityEngine;

namespace _Project.CodeBase.Core.Racket
{
    public class BotMovement : IRocketMovement
    {
        private readonly Transform _target;
    
        private LevelConfig _levelConfig;
        private float _speed;

        public BotMovement(Transform target) => 
            _target = target;

        public void Initialize(LevelConfig levelConfig, float speed)
        {
            _levelConfig = levelConfig;
            _speed = speed;
        }

        public Vector3 Move(Vector3 position)
        {
            Vector3 pos = default;
            
            if (_target.transform.position.x > position.x)
                pos = Vector2.right;
            else if (_target.transform.position.x < position.x) 
                pos = Vector2.left;
            
            var deltaPos = pos * (_speed * Time.deltaTime);

            if (_levelConfig.IsPosOutOfHorizontalBounds(position + deltaPos))
                return position;

            return position + deltaPos;
        }
    }
}