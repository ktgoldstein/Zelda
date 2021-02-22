using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class StaticProjectileSprite : ISprite
    {
        private readonly Texture2D texture;
        private readonly int xOffset;
        private readonly int yOffset;
        private readonly int height;
        private readonly int width;

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
