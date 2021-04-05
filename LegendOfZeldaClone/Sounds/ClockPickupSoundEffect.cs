using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class ClockPickupSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public ClockPickupSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetClockPickupSoundEffect();
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
