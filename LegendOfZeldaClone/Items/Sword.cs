using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class Sword : IItem
    {
        private ISprite sword;
        private Vector2 location;

        public Sword(Vector2 location)
        {
            sword = ItemSpriteFactory.Instance.CreateSword();
            this.location = location;
        }
    }
}
