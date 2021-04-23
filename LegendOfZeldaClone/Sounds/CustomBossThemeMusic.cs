using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class CustomBossThemeMusic : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;
        private static bool songHasAlreadyStartedPlaying;

        public CustomBossThemeMusic()
        {
            Sound = GameSoundFactory.Instance.GetCustomBossThemeMusic();
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
            songHasAlreadyStartedPlaying = false;
        }
    }
}
