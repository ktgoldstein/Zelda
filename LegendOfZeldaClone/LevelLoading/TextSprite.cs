using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class TextSprite : ISprite
    {
        private readonly Texture2D texture;
        private readonly int xOffset;
        private readonly int yOffset;
        private readonly int width;
        private readonly int height;

        public TextSprite(Texture2D texture, int xOffset, int yOffset, int width, int height)
        {
            this.texture = texture;
            this.xOffset = xOffset;
            this.yOffset = yOffset;
            this.width = width;
            this.height = height;
        }

        public void Update() { }

        public void Draw(SpriteBatch spritebatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(xOffset, yOffset, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));

            spritebatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
