using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class NoHealthHeart : IItem
    {
        private ISprite noHealthHeart;
        private Vector2 location;

        public NoHealthHeart(Vector2 location)
        {
            noHealthHeart = ItemSpriteFactory.Instance.CreateNoHealthHeart();
            this.location = location;
        }
    }
}
