using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class SwordBeamSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public SwordBeamSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetSwordBeamSoundEffect();
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
