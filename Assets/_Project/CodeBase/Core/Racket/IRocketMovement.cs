using _Project.CodeBase.Data.Configs;
using UnityEngine;

namespace _Project.CodeBase.Core.Racket
{
    public interface IRocketMovement
    {
        void Initialize(LevelConfig levelConfig, float speed);
        Vector3 Move(Vector3 position);
    }
}