using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class DungeonThemeMusic : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;
        private bool songHasAlreadyStartedPlaying = false;

        public DungeonThemeMusic()
        {
            Sound = GameSoundFactory.Instance.GetDungeonThemeMusic();
            SoundInstance = Sound.CreateInstance();
            SoundInstance.IsLooped = true;
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
