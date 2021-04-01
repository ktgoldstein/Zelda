using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class HeartPickupSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public HeartPickupSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetHeartPickupSoundEffect();
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
