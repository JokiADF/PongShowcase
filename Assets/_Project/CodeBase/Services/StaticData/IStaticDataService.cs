using _Project.CodeBase.Configs;
using _Project.CodeBase.Data.Configs;
using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Services.StaticData
{
    public interface IStaticDataService
    {
        UniTask InitializeAsync();
        PlayerConfig Player { get; }
        BotConfig Bot { get; }
        BallConfig Ball { get; }
        LevelConfig Level { get; }
        AudioConfig Audio { get; }
    }
}