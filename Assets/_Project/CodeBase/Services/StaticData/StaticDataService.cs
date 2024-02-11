using System.Collections.Generic;
using System.Linq;
using _Project.CodeBase.Data.Configs;
using _Project.CodeBase.Infrastructure.AssetManagement;
using _Project.CodeBase.Services.Log;
using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetProvider;
        private readonly ILogService _log;

        public PlayerConfig Player { get; private set; }
        public BotConfig Bot { get; private set; }
        public BallConfig Ball { get; private set; }
        public LevelConfig Level { get; private set; }
        
        public StaticDataService(IAssetProvider assetProvider, ILogService log)
        {
            _assetProvider = assetProvider;
            _log = log;
        }

        public async UniTask InitializeAsync()
        {
            var tasks = new List<UniTask>
            {
                LoadLevelConfig(),
                LoadPlayerConfig(),
                LoadBallConfig(),
                LoadBotConfig(),
            };

            await UniTask.WhenAll(tasks);
            
            _log.Log("Static data loaded");
        }

        private async UniTask LoadLevelConfig()
        {
            var configs = await GetConfigs<LevelConfig>();
            if(configs.Length > 0)
                Level = configs.First();
            else
                _log.LogError("There are no level config founded!");
        }

        private async UniTask LoadPlayerConfig()
        {
            var configs = await GetConfigs<PlayerConfig>();
            if(configs.Length > 0)
                Player = configs.First();
            else
                _log.LogError("There are no player config founded!");
        }

        private async UniTask LoadBallConfig()
        {
            var configs = await GetConfigs<BallConfig>();
            if(configs.Length > 0)
                Ball = configs.First();
            else
                _log.LogError("There are no ball config founded!");
        }

        private async UniTask LoadBotConfig()
        {
            var configs = await GetConfigs<BotConfig>();
            if(configs.Length > 0)
                Bot = configs.First();
            else
                _log.LogError("There are no bot config founded!");
        }

        private async UniTask<TConfig[]> GetConfigs<TConfig>() where TConfig : class
        {
            var keys = await GetConfigKeys<TConfig>();
            return await _assetProvider.LoadAll<TConfig>(keys);
        }

        private async UniTask<List<string>> GetConfigKeys<TConfig>() => 
            await _assetProvider.GetAssetsListByLabel<TConfig>(AssetName.Lables.Configs);
    }
}