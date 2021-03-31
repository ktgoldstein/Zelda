using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class ArrowShootingSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public ArrowShootingSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetArrowShootingSoundEffect();
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
