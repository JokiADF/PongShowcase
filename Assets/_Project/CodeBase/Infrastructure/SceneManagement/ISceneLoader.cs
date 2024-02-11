using System;
using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Infrastructure.SceneManagement
{
    public interface ISceneLoader
    {
        UniTask Load(string name, Action onLoaded = null);
    }
}