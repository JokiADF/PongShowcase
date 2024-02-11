using _Project.CodeBase.Data;

namespace CodeBase.Services.PlayerProgressService
{
    public interface IProgressSaver : IProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }
}