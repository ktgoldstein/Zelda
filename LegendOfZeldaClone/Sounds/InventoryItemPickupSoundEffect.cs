using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class InventoryItemPickupSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public InventoryItemPickupSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetInventoryItemPickupSoundEffect();
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
