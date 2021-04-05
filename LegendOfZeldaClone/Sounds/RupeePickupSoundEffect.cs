using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class RupeePickupSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public RupeePickupSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetRupeePickupSoundEffect();
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
