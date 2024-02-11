using _Project.CodeBase.Data.Configs;
using UnityEngine;

namespace _Project.CodeBase.Core.Racket
{
    public class PlayerMovement : IRocketMovement
    {
        private float _speed;
    
        private LevelConfig _levelConfig;
    
        public void Initialize(LevelConfig levelConfig, float speed)
        {
            _levelConfig = levelConfig;
            _speed = speed;
        }
    
        public Vector3 Move(Vector3 position)
        {
            var deltaPos = Vector3.right * (Input.GetAxis("Horizontal") * _speed * Time.deltaTime);
        
            if (_levelConfig.IsPosOutOfHorizontalBounds(position + deltaPos))
                return position;
        
            return position + deltaPos;
        }
    }
}