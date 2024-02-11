using System.Collections.Generic;
using System.Linq;
using _Project.CodeBase.Data;
using _Project.CodeBase.Services.Storage;

namespace _Project.CodeBase.UI.Services.Scoreboard
{
    public class ScoreboardService : IScoreboardService
    {
        private const string StorageKey = "Scoreboard";
        
        public List<ScoreItem> Scoreboard { get; }

        private readonly IStorageService _storage;

        public ScoreboardService(IStorageService storage)
        {
            _storage = storage;

            Scoreboard = new List<ScoreItem>();
            Load();
        }

        public void Add(ScoreItem scoreItem)
        {
            var originalList = Scoreboard.ToList();
            originalList.Add(scoreItem);

            var orderedList = originalList
                .OrderByDescending(x => x.score)
                .Take(10).ToList();

            UpdateScoreboard(orderedList);
        }

        private void UpdateScoreboard(IList<ScoreItem> items)
        {
            if (items == null)
                return;

            Scoreboard.Clear();

            foreach (var item in items) 
                Scoreboard.Add(item);
            
            Save();
        }

        private void Load()
        {
            var scoreboard = _storage.Load<Data.Scoreboard>(StorageKey);

            if (scoreboard != null) 
                UpdateScoreboard(scoreboard.items);
        }

        private void Save()
        {
            _storage.Save(StorageKey, new Data.Scoreboard()
            {
                items = Scoreboard.ToArray()
            });
        }
    }
}