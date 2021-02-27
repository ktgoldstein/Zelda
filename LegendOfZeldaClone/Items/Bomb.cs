using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class Bomb : IItem
    {
        private ISprite bomb;
        private Vector2 location;

        public Bomb(Vector2 location)
        {
            bomb = ItemSpriteFactory.Instance.CreateBomb();
            this.location = location;
        }
    }
}
