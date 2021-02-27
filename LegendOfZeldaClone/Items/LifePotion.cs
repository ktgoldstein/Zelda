using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class LifePotion : IItem
    {
        private ISprite lifePotion;
        private Vector2 location;

        public LifePotion(Vector2 location)
        {
            lifePotion = ItemSpriteFactory.Instance.CreateLifePotion();
            this.location = location;
        }
    }
}
