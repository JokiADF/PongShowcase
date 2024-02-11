using _Project.CodeBase.Data;
using _Project.CodeBase.Services.Progress;

namespace CodeBase.Services.PlayerProgressService
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}