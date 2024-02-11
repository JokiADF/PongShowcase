using _Project.CodeBase.Infrastructure.SceneManagement.UI;
using _Project.CodeBase.Services.InputService;
using _Project.CodeBase.Services.Log;
using _Project.CodeBase.Services.SaveLoad;
using _Project.Scripts.Infrastructure.SceneManagement;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.States;
using CodeBase.Services.PlayerProgressService;
using CodeBase.Services.StaticDataService;
using UnityEngine;
using UnityEngine.ResourceManagement.ResourceProviders;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private LoadingCurtain prefab;
    
    public override void InstallBindings()
    {
        BindSceneLoader();
        BindLoadingCurtains();

        BindAssetProvider();
        BindGameFactory();

        BindServices();
        
        BindGameStateMachine();
    }

    private void BindSceneLoader()
    {
        Container
            .BindInterfacesAndSelfTo<SceneLoader>()
            .AsSingle();
    }

    private void BindLoadingCurtains()
    {
        var loadingCurtain = Instantiate(prefab);
        
        Container
            .BindInterfacesAndSelfTo<LoadingCurtain>()
            .FromInstance(loadingCurtain)
            .AsSingle();
    }

    private void BindAssetProvider()
    {
        Container
            .BindInterfacesAndSelfTo<AssetProvider>()
            .AsCached();
    }

    private void BindGameFactory()
    {
        Container
            .BindInterfacesAndSelfTo<GameFactory>()
            .AsSingle();
    }

    private void BindServices()
    {
        Container
            .BindInterfacesAndSelfTo<LogService>()
            .AsSingle();
        
        Container
            .BindInterfacesAndSelfTo<StandaloneInputService>()
            .AsSingle();
        Container
            .BindInterfacesAndSelfTo<PersistentProgressService>()
            .AsSingle();
        Container
            .BindInterfacesAndSelfTo<SaveLoadService>()
            .AsSingle();
        Container
            .BindInterfacesAndSelfTo<StaticDataService>()
            .AsSingle();
    }

    private void BindGameStateMachine()
    {
        Container
            .Bind<GameStateMachine>()
            .AsSingle();
        Container
            .Bind<StatesFactory>()
            .AsSingle();
    }
}