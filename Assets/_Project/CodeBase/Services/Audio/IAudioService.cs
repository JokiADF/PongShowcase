namespace _Project.CodeBase.Services.Audio
{
    public interface IAudioService
    {
        void Initialize();
        void PlayMusic();
        void StopMusic();
        void DuckMusic(float targetVolume, float duration);
    }
}
