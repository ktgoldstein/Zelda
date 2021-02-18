using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class StaticProjectileSprite : ISprite
    {
        private Texture2D texture;
        private int xOffset;
        private int yOffset;
        private int height;
        private int width;

        public StaticProjectileSprite(Texture2D texture, int xOffset, int yOffset, int spriteWidth, int spriteHeight)
        {
            this.texture = texture;
            this.xOffset = xOffset;
            this.yOffset = yOffset;
            width = spriteWidth;
            height = spriteHeight;
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(xOffset, yOffset, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
