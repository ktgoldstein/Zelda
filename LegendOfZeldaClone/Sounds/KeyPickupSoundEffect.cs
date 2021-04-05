using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class KeyPickupSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public KeyPickupSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetKeyPickupSoundEffect();
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
