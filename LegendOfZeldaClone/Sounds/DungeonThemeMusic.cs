using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class DungeonThemeMusic : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public DungeonThemeMusic()
        {
            Sound = GameSoundFactory.Instance.GetDungeonThemeMusic();
            SoundInstance = Sound.CreateInstance();
            SoundInstance.IsLooped = true;
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
