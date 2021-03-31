using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class KeyAppearingSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public KeyAppearingSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetKeyAppearingSoundEffect();
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
