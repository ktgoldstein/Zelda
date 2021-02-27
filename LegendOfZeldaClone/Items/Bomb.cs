using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Bomb : IItem
    {
        private ISprite bomb;
        private Vector2 location;
        private int height;
        private int width;

        public Bomb(Vector2 location)
        {
            bomb = ItemSpriteFactory.Instance.CreateBomb();
            this.location = location;
            this.width = 12;
            this.height = 16;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            bomb.Draw(spriteBatch, location);
        }
    }
}
