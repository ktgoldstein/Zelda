using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class TextAppearingSlowlySoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public TextAppearingSlowlySoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetTextAppearingSlowlySoundEffect();
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
