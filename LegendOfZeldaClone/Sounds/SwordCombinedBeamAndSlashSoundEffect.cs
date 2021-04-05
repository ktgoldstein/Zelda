using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class SwordCombinedBeamAndSlashSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public SwordCombinedBeamAndSlashSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetSwordCombinedBeamAndSlashSoundEffect();
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
