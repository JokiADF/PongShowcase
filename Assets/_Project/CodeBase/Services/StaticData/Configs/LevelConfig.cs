using UnityEngine;

namespace CodeBase.Services.StaticDataService.Configs
{
    [CreateAssetMenu(menuName = "Configs/Game/Level")]
    public class LevelConfig : ScriptableObject
    {
        public int level;
    }
}