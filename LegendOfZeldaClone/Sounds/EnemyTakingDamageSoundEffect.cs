using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class EnemyTakingDamageSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public EnemyTakingDamageSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetEnemyTakingDamageSoundEffect();
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
