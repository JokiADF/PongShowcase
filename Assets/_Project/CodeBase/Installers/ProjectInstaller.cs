using _Project.CodeBase.Core.Services.BallTracker;
using _Project.CodeBase.Core.Services.GameScoring;
using _Project.CodeBase.Core.Services.Vignette;
using _Project.CodeBase.Gameplay.Services.CameraShake;
using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Infrastructure.Factory;
using _Project.CodeBase.Infrastructure.SceneManagement;
using _Project.CodeBase.Infrastructure.SceneManagement.UI;
using _Project.CodeBase.Infrastructure.States;
using _Project.CodeBase.Infrastructure.States.GameStates;
using _Project.CodeBase.Services.Audio;
using _Project.CodeBase.Services.Audio.Factory;
using _Project.CodeBase.Services.Input;
using _Project.CodeBase.Services.Log;
using _Project.CodeBase.Services.Pool;
using _Project.CodeBase.Services.StaticData;
using _Project.CodeBase.Services.Storage;
using _Project.CodeBase.UI.Services.Factory;
using _Project.CodeBase.UI.Services.Scoreboard;
using _Project.CodeBase.UI.Services.Screens;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Zenject;

namespace _Project.CodeBase.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private PostProcessVolume postProcessVolume;
        [SerializeField] private LoadingCurtain prefab;
    
        public override void InstallBindings()
        {
            BindSceneLoader();
            BindLoadingCurtains();

            BindAssetProvider();
            BindFactory();
            
            BindServices();
        
            BindGameStateMachine();

            BindCamera();
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

        private void BindFactory()
        {
            Container
                .BindInterfacesAndSelfTo<GameFactory>()
                .AsSingle();
            Container
                .BindInterfacesAndSelfTo<UIFactory>()
                .AsSingle();
            Container
                .BindInterfacesAndSelfTo<AudioFactory>()
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
                .BindInterfacesAndSelfTo<StorageService>()
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
            Container
                .BindInterfacesAndSelfTo<CameraShakerService>()
                .AsSingle();
            Container
                .BindInterfacesAndSelfTo<VignetteSystem>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<ScreenService>()
                .AsSingle();
            Container
                .BindInterfacesAndSelfTo<ScoreboardService>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<AudioService>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<PoolingService>()
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

        private void BindCamera()
        {
            Container
                .Bind<Camera>()
                .FromInstance(mainCamera)
                .AsSingle();
            Container
                .Bind<PostProcessVolume>()
                .FromInstance(postProcessVolume)
                .AsSingle();
        }
    }
}