using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class NewImportantItemAcquiredFanfareSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public NewImportantItemAcquiredFanfareSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetNewImportantItemAcquiredFanfareSoundEffect();
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
