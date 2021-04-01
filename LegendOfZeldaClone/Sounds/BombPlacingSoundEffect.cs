using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class BombPlacingSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public BombPlacingSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetBombPlacingSoundEffect();
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
