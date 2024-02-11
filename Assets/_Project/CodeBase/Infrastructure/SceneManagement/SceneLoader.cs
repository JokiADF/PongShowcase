using System;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace _Project.CodeBase.Infrastructure.SceneManagement
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask Load(string name, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                
                return;
            }
            
            var handler = Addressables.LoadSceneAsync(name, LoadSceneMode.Single, false);

            await handler.ToUniTask();
            await handler.Result.ActivateAsync().ToUniTask();
            
            onLoaded?.Invoke();
        }
    }
}