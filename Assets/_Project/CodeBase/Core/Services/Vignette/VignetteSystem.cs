using _Project.CodeBase.UI.Services.Factory;

namespace _Project.CodeBase.Core.Services.Vignette
{
    public class VignetteSystem : IVignetteSystem
    {
        private readonly IUIFactory _uiFactory;
        
        private VignetteDamage _vignetteDamage;

        public VignetteSystem(IUIFactory uiFactory) => 
            _uiFactory = uiFactory;

        public void Initialize() => 
            _vignetteDamage = _uiFactory.CreateVignetteDamage();

        public void OnDamage(float duration) => 
            _vignetteDamage.PlayVignette(duration);
    }
}