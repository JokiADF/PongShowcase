using System;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Infrastructure.SceneManagement
{
    public interface ISceneLoader
    {
        UniTask Load(string name, Action onLoaded = null);
    }
}