using UnityEngine.AddressableAssets;

namespace CodeBase.Services.AssetManagement
{
    public static class AssetName
    {
        public class Lables
        {
            public const string Configs = "Configs";
            public const string GameLoadingState = "GameLoadingState";
            public const string GameHubState = "GameHubState";
            public const string GameLoopState = "GameLoopState";
        }

        public class Scenes
        {
            public const string GameLoadingScene = "1GameLoading";
            public const string GameHubScene = "2GameHub";
            public const string GameLoopScene = "3GameLoop";
        }
        
        public class Objects
        {
            public const string Player = "Player";
            public const string Enemy = "Enemy";
        }

        public class UI
        {
            public static string HUD = "HUD";
        }

        public class Audio
        {
            public const string Click = "Click";
            public const string Music = "Music";
            public const string Clash = "Clash";
            public const string Explosion = "Explosion";
        }

        public class Materials
        {
            public const string Background = "Background";
        }
    }
}
