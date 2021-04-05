using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class BossTakingDamageSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public BossTakingDamageSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetBossTakingDamageSoundEffect();
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
