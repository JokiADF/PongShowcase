using UnityEngine;

namespace _Project.CodeBase.Data.Configs
{
    [CreateAssetMenu(menuName = "Configs/Level", fileName = "LevelConfig", order = 2)]
    public class LevelConfig: ScriptableObject
    {
        public int playerAttempts = 10;
        public Vector2 bounds = new(11f, 4.5f);

        public bool IsPosOutOfHorizontalBounds(Vector3 pos)
        {
            const float refAspectRatio = 16f / 9;
            var currentAspectRatio = Screen.width / (float)Screen.height;
            
            var boundX = bounds.x * (currentAspectRatio / refAspectRatio);

            return pos.x > boundX || pos.x < -boundX;
        }
    
        public bool IsPosOutOfVerticalBounds(Vector3 pos)
        {
            const float refAspectRatio = 9 / 16f;
            var currentAspectRatio = (float)Screen.height / Screen.width;
            
            var boundY = bounds.y * (currentAspectRatio / refAspectRatio);
            
            return pos.y > boundY || pos.y < -boundY;
        }
    }
}