using UnityEngine;

namespace _Project.CodeBase.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        public GameBootstrapper prefab;
        
        private void Awake()
        {
            var bootstrapper = FindObjectOfType<GameBootstrapper>();
      
            if(bootstrapper != null) return;
            
            Instantiate(prefab);
        }
    }
}