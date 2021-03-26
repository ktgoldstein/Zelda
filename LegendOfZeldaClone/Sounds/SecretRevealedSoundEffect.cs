using Microsoft.Xna.Framework.Audio;

namespace LegendOfZeldaClone
{
    public class SecretRevealedSoundEffect : IGameSound
    {
        public SoundEffect Sound { get; }
        private SoundEffectInstance SoundInstance;

        public SecretRevealedSoundEffect()
        {
            Sound = GameSoundFactory.Instance.GetSecretRevealedSoundEffect();
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
