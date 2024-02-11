using Cysharp.Threading.Tasks;

namespace CodeBase.Services.StaticDataService
{
    public interface IStaticDataService
    {
        UniTask InitializeAsync();
    }
}