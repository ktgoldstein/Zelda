using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class LowHealthBeepingSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public LowHealthBeepingSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetLowHealthBeepingSoundEffect();
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
