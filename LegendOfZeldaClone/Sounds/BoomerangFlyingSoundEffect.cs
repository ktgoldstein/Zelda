using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class BoomerangFlyingSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public BoomerangFlyingSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetBoomerangFlyingSoundEffect();
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
