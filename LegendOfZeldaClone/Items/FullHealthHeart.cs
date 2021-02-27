using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class FullHealthHeart : IItem
    {
        private ISprite fullHealthHeart;
        private Vector2 location;

        public FullHealthHeart(Vector2 location)
        {
            fullHealthHeart = ItemSpriteFactory.Instance.CreateFullHealthHeart();
            this.location = location;
        }
    }
}
