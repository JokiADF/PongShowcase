using _Project.CodeBase.Services.Pool;
using Zenject;

public class GameLoopInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .BindInterfacesAndSelfTo<PoolingService>()
            .AsSingle();
    }
}