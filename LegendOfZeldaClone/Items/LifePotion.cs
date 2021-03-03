using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class LifePotion : IItem
    {
        private ISprite lifePotion;
        private Vector2 location;
        private int height;
        private int width;

        public LifePotion(Vector2 location)
        {
            lifePotion = ItemSpriteFactory.Instance.CreateLifePotion();
            this.location = location;
            this.width = 8;
            this.height = 16;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            lifePotion.Draw(spriteBatch, location);
        }
    }
}
