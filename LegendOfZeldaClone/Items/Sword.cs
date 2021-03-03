using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Sword : IItem
    {
        private ISprite sword;
        private Vector2 location;
        private int height;
        private int width;

        public Sword(Vector2 location)
        {
            sword = ItemSpriteFactory.Instance.CreateSword();
            this.location = location;
            this.width = 8;
            this.height = 16;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sword.Draw(spriteBatch, location);
        }
    }
}
