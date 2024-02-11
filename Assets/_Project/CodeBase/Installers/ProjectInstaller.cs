using _Project.CodeBase.Core.Services.BallTracker;
using _Project.CodeBase.Core.Services.Scores;
using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Infrastructure.Factory;
using _Project.CodeBase.Infrastructure.SceneManagement;
using _Project.CodeBase.Infrastructure.SceneManagement.UI;
using _Project.CodeBase.Infrastructure.States;
using _Project.CodeBase.Infrastructure.States.GameStates;
using _Project.CodeBase.Services.Input;
using _Project.CodeBase.Services.Log;
using _Project.CodeBase.Services.StaticData;
using UnityEngine;
using Zenject;

namespace _Project.CodeBase.Installers
{
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
                .BindInterfacesAndSelfTo<StaticDataService>()
                .AsSingle();
        
            Container
                .BindInterfacesAndSelfTo<GameScoringService>()
                .AsSingle();
            Container
                .BindInterfacesAndSelfTo<BallTrackerService>()
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
}