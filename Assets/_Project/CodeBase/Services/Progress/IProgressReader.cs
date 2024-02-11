using _Project.CodeBase.Data;

namespace CodeBase.Services.PlayerProgressService
{
    public interface IProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
}