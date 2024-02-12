namespace _Project.CodeBase.Infrastructure.AssetManagement
{
    public static class AssetName
    {
        public class Lables
        {
            public const string Configs = "Configs";
            public const string GameplayState = "GameplayState";
            public const string Ui = "UI";
            public const string Audio = "Audio";
        }

        public class Scenes
        {
            public const string GameplayScene = "1.Gameplay";
        }
        
        public class Objects
        {
            public const string GameplayController = "GameplayController";
            public const string Player = "Player";
            public const string Bot = "Bot";
            public const string Ball = "Ball";
            public const string Explosion = "ExplosionObject";
        }

        public class UI
        {
            public const string Root = "Root";
            public const string Menu = "Menu";
            public const string Scoreboard = "Scoreboard";
            public const string HUD = "HUD";
            public const string Result = "Result";
            public const string ScoreItemText = "ScoreItemText";
        }

        public class Audio
        {
            public const string Music = "Music";
            public const string Clash = "Clash";
            public const string Click = "Click";
            public const string Explosion = "ExplosionSound";
        }
    }
}
