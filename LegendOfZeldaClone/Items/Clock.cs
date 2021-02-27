using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class Clock : IItem
    {
        private ISprite clock;
        private Vector2 location;

        public Clock(Vector2 location)
        {
            clock = ItemSpriteFactory.Instance.CreateClock();
            this.location = location;
        }
    }
}
