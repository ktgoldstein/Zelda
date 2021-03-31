using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class RupeeCountChangingSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public RupeeCountChangingSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetRupeeCountChangingSoundEffect();
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
