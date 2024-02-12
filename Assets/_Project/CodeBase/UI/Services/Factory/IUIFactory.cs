using _Project.CodeBase.UI.Elements;
using _Project.CodeBase.UI.Screens;
using _Project.CodeBase.UI.Services.Screens;
using UnityEngine;

namespace _Project.CodeBase.UI.Services.Factory
{
  public interface IUIFactory
  {
    void CreateUIRoot();
    
    ScreenBase CreateWindow(ScreenId screenId);
    ScoreItemText CreateScoreItemText(Transform parent);
    VignetteDamage CreateVignetteDamage();
  }
}