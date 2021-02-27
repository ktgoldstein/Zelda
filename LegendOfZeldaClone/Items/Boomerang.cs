using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class Boomerang : IItem
    {
        private ISprite boomerang;
        private Vector2 location;

        public Boomerang(Vector2 location)
        {
            boomerang = ItemSpriteFactory.Instance.CreateBoomerang();
            this.location = location;
        }
    }
}
