using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class BombExplodingSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public BombExplodingSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetBombExplodingSoundEffect();
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
