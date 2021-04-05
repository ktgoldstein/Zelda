using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class LinkTakingDamageSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public LinkTakingDamageSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetLinkTakingDamageSoundEffect();
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
