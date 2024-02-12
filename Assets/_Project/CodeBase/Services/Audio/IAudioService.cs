namespace _Project.CodeBase.Services.Audio
{
    public interface IAudioService
    {
        void Initialize();
        void PlaySfx(string key, float volume);
        void PlayMusic();
        void StopMusic();
        void DuckMusic(float targetVolume, float duration);
    }
}
