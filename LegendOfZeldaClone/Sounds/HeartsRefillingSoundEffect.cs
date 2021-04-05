using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class HeartsRefillingSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public HeartsRefillingSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetHeartsRefillingSoundEffect();
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
