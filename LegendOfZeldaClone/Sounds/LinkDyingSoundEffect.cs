using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class LinkDyingSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public LinkDyingSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetLinkDyingSoundEffect();
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
