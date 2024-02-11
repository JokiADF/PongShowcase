namespace _Project.CodeBase.Services.Progress
{
    public interface IPersistentProgressService
    {
        Data.PlayerProgress Progress { get; set; }
    }
}