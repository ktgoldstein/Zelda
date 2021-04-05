using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class DoorUnlockingSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public DoorUnlockingSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetDoorUnlockingSoundEffect();
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
