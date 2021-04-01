using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class FairyPickupSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public FairyPickupSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetFairyPickupSoundEffect();
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
