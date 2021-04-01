using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class GameOverThemeMusic : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public GameOverThemeMusic()
        {
            Sound = GameSoundFactory.Instance.GetGameOverThemeMusic();
            SoundInstance = Sound.CreateInstance();
            SoundInstance.IsLooped = false;
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
