using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class OrbSwitch : BlockKernel
    {
        public bool WasHit { get => wasHit; }
        private bool wasHit = false;

        public OrbSwitch(Vector2 location, ISprite sprite, int height, int width, ObjectHeight objectHeight)
            : base(location, sprite, height, width, objectHeight, false, false)
        { }

        public void Reset() => wasHit = false;
        public void Hit()
        {
            wasHit = !wasHit;
            sprite.Update();
        }
    }
}
