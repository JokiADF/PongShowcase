using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Infrastructure.States
{
    public interface IPayloadedState<TPayload> : IExitableState
    {
        UniTask Enter(TPayload payload);
    }
}