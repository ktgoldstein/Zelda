using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Bow : IItem
    {
        private ISprite bow;
        private Vector2 location;
        private int height;
        private int width;

        public Bow(Vector2 location)
        {
            bow = ItemSpriteFactory.Instance.CreateBow();
            this.location = location;
            this.width = 12;
            this.height = 16;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            bow.Draw(spriteBatch, location);
        }
    }
}
