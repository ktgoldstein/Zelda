using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class WalkingOnStairsSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public WalkingOnStairsSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetWalkingOnStairsSoundEffect();
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
