using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class Arrow : IItem
    {
        private ISprite arrow;
        private Vector2 location;

        public Arrow(Vector2 location)
        {
            arrow = ItemSpriteFactory.Instance.CreateArrow();
            this.location = location;
        }
    }
}
