using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class SilverArrow : IItem
    {
        private ISprite silverArrow;
        private Vector2 location;

        public SilverArrow(Vector2 location)
        {
            silverArrow = ItemSpriteFactory.Instance.CreateSilverArrow();
            this.location = location;
        }
    }
}
