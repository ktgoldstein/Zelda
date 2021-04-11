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
        public void Play()
        {
            if (!songHasAlreadyStartedPlaying)
                SoundInstance.Play();
            songHasAlreadyStartedPlaying = true;
        }
        public void StopPlaying()
        {
            SoundInstance.Dispose();
        }
    }
}
