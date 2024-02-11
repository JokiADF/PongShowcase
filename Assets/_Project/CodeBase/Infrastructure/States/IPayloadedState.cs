using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.States
{
    public interface IPayloadedState<TPayload> : IExitableState
    {
        UniTask Enter(TPayload payload);
    }
}