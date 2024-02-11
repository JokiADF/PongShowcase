using _Project.CodeBase.Data.Configs;
using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Services.StaticData
{
    public interface IStaticDataService
    {
        UniTask InitializeAsync();
        PlayerConfig Player { get; }
        BotConfig Bot { get; }
        LevelConfig Level { get; }
        BallConfig Ball { get; }
    }
}