using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class GameOverThemeMusic : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;
        private static bool songHasAlreadyStartedPlaying;

        public GameOverThemeMusic()
        {
            Sound = GameSoundFactory.Instance.GetGameOverThemeMusic();
            SoundInstance = Sound.CreateInstance();
            SoundInstance.IsLooped = true;
            songHasAlreadyStartedPlaying = false;
        }
        public void ConditionalPlay() //allows the theme to be initialized in an Update() method without it endlessly being duplicated
        {
            if (!songHasAlreadyStartedPlaying)
                Play();
            songHasAlreadyStartedPlaying = true;
        }
        public void Play()
        {
            SoundInstance.Play();
        }
        public void StopPlaying()
        {
            Sound.Dispose();
        }
    }
}
