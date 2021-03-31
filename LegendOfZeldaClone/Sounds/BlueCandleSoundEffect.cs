using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class BlueCandleSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public BlueCandleSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetBlueCandleSoundEffect();
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
