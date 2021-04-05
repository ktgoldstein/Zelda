using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class EnemyDyingSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public EnemyDyingSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetEnemyDyingSoundEffect();
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
