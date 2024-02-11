using System.Collections.Generic;
using _Project.CodeBase.Data;

namespace _Project.CodeBase.UI.Services.Scoreboard
{
    public interface IScoreboardService
    {
        List<ScoreItem> Scoreboard { get; }
        void Add(ScoreItem scoreItem);
    }
}