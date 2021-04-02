using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class CyclingProjectileSprite : ISprite
    {
        private readonly Texture2D texture;
        private readonly int height;
        private readonly int width;
        private int currentFrame;
        private Point[] frameLocations;
        private Color color;

        public CyclingProjectileSprite(Texture2D texture, int spriteWidth, int spriteHeight, Point[] frameLocations, Color? color = null)
        {
            this.texture = texture;
            width = spriteWidth;
            height = spriteHeight;
            currentFrame = 0;
            this.frameLocations = frameLocations;
            this.color = color ?? Color.White;
        }

        public void Update() => currentFrame = (currentFrame + 1) % frameLocations.Length;

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(frameLocations[currentFrame].X, frameLocations[currentFrame].Y, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
    }
}
