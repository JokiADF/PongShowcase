using _Project.CodeBase.UI.Elements;
using UnityEngine;

namespace _Project.CodeBase.UI.Screens
{
    public class ScoreboardScreen : ScreenBase
    {
        [SerializeField] private ScoreboardContainer container;
        
        public override void Open()
        {
            container.Open();
            base.Open();
        }
    }
}