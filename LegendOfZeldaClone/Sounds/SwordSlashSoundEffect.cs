using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class SwordSlashSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public SwordSlashSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetSwordSlashSoundEffect();
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
