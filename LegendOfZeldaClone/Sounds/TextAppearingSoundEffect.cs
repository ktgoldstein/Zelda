using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class TextAppearingSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public TextAppearingSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetTextAppearingSoundEffect();
            SoundInstance = Sound.CreateInstance();
            SoundInstance.IsLooped = true;
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
