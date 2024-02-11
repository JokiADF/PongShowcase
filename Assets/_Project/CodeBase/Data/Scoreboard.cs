using System;

namespace _Project.CodeBase.Data
{
    [Serializable]
    public class ScoreItem
    {
        public int score;
        public string date;
    }
    
    [Serializable]
    public class Scoreboard
    {
        public ScoreItem[] items;
    }
}