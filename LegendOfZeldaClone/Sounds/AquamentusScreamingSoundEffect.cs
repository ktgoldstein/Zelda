using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class AquamentusScreamingSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public AquamentusScreamingSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetAquamentusScreamingSoundEffect();
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
