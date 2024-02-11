using _Project.CodeBase.Data.Configs;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.CodeBase.Core.Ball
{
    public class BallBehaviour : MonoBehaviour
    {
        private Vector3 _velocity;
        private BallConfig _ballConfig;

        public Vector3ReactiveProperty Position { get; } = new(); 

        public void Initialize(BallConfig ballConfig)
        {
            _ballConfig = ballConfig;
        
            transform.position = _ballConfig.spawnPosition;
        }

        public void TakeFly()
        {
            ResetPosition();
            _velocity = Vector3.zero;
        
            AddStartingForce();
        }

        public void ResetPosition() => 
            transform.position = _ballConfig.spawnPosition;

        private void FixedUpdate() => 
            Move();

        private void OnCollisionEnter(Collision collision) => 
            Clash(collision.GetContact(0).normal);

        private void AddStartingForce()
        {
            var x = Random.value < 0.5f 
                ? -1f 
                : 1f;
            var y = Random.value < 0.5f 
                ? Random.Range(-1f, -0.5f)
                : Random.Range(0.5f, 1f);
            
            var direction = new Vector3(x, y);
            _velocity += direction * _ballConfig.speed;
        }
    
        private void Move()
        {
            var deltaPos = _velocity * (_ballConfig.speed * Time.fixedDeltaTime);
        
            transform.position += deltaPos;
            Position.Value = transform.position;
        }

        private void Clash(Vector3 normal) => 
            _velocity += normal.normalized * _ballConfig.bounceStrength;
    }
}