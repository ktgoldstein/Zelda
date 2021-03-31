using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class ShieldDeflectingSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public ShieldDeflectingSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetShieldDeflectingSoundEffect();
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
