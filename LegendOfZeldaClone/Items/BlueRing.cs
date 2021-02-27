using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class BlueRing : IItem
    {
        private ISprite blueRing;
        private Vector2 location;

        public BlueRing(Vector2 location)
        {
            blueRing = ItemSpriteFactory.Instance.CreateBlueRing();
            this.location = location;
        }
    }
}
