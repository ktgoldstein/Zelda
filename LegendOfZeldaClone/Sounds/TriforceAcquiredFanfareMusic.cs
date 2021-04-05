using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class TriforceAcquiredFanfareMusic : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public TriforceAcquiredFanfareMusic()
        {
            Sound = GameSoundFactory.Instance.GetTriforceAcquiredFanfareMusic();
            SoundInstance = Sound.CreateInstance();
            SoundInstance.IsLooped = false;
        }
        public void Play()
        {
            SoundInstance.Play();
        }
        public void StopPlaying()
        {
            SoundInstance.Dispose();
        }
    }
}
