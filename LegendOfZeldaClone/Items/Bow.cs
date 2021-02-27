using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class Bow : IItem
    {
        private ISprite bow;
        private Vector2 location;

        public Bow(Vector2 location)
        {
            bow = ItemSpriteFactory.Instance.CreateBow();
            this.location = location;
        }
    }
}
