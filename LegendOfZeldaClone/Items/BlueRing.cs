using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class BlueRing : IItem
    {
        private ISprite blueRing;
        private Vector2 location;
        private int height;
        private int width;

        public BlueRing(Vector2 location)
        {
            blueRing = ItemSpriteFactory.Instance.CreateBlueRing();
            this.location = location;
            this.width = 8;
            this.height = 8;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            blueRing.Draw(spriteBatch, location);
        }
    }
}
