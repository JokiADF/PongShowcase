using _Project.CodeBase.Data;

namespace _Project.CodeBase.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}