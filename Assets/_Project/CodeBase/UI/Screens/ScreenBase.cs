using UnityEngine;

namespace _Project.CodeBase.UI.Screens
{
    public abstract class ScreenBase : MonoBehaviour
    {
        private void Awake()
        {
            Initialize();
            SubscribeUpdates();
        }

        private void OnDestroy() => 
            Cleanup();

        public virtual void Open() => 
            gameObject.SetActive(true);
        public virtual void Close() => 
            gameObject.SetActive(false);

        protected virtual void Initialize() {}
        protected virtual void SubscribeUpdates() {}
        protected virtual void Cleanup() {}
    }
}