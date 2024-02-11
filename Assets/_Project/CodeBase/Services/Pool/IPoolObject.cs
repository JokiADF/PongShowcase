using _Project.CodeBase.Services.Pool;

namespace _Project.Scripts.Infrastructure.PoolManagement
{
    public interface IPoolObject
    {
        void Register(Pool pool);
    }
}