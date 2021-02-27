using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class Heart : IItem
    {
        private ISprite heart;
        private Vector2 location;

        public Heart(Vector2 location)
        {
            heart = ItemSpriteFactory.Instance.CreateHeart();
            this.location = location;
        }
    }
}
