using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Boomerang : IItem
    {
        private ISprite boomerang;
        private Vector2 location;
        private int height;
        private int width;

        public Boomerang(Vector2 location)
        {
            boomerang = ItemSpriteFactory.Instance.CreateBoomerang();
            this.location = location;
            this.width = 12;
            this.height = 12;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            boomerang.Draw(spriteBatch, location);
        }
    }
}
