using _Project.CodeBase.UI.Screens;
using _Project.CodeBase.UI.Services.Screens;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.CodeBase.UI.Services.Factory
{
  public interface IUIFactory
  {
    void CreateUIRoot();
    
    ScreenBase CreateWindow(ScreenId screenId);
  }
}