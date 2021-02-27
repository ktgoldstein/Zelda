using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class HalfHealthHeart : IItem
    {
        private ISprite halfHealthHeart;
        private Vector2 location;

        public HalfHealthHeart(Vector2 location)
        {
            halfHealthHeart = ItemSpriteFactory.Instance.CreateHalfHealthHeart();
            this.location = location;
        }
    }
}
