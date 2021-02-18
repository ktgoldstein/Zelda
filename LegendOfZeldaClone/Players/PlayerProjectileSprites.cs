using Microsoft.Xna.Framework;
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
    public class CyclingProjectileSprite : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;
        private int currentFrame;
        private Point[] frameLocations;

        public CyclingProjectileSprite(Texture2D texture, int spriteWidth, int spriteHeight, Point[] frameLocations)
        {
            this.texture = texture;
            width = spriteWidth;
            height = spriteHeight;
            currentFrame = 0;
            this.frameLocations = frameLocations;
        }

        public void Update() => currentFrame = (currentFrame + 1) % frameLocations.Length;

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(frameLocations[currentFrame].X, frameLocations[currentFrame].Y, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    public class MultipleCyclingProjectileSprite : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;
        private int currentFrame;
        private Point[] frameLocations;


        public MultipleCyclingProjectileSprite(Texture2D texture, int spriteWidth, int spriteHeight, Point[] frameLocations) //for the bomb explosion sprite
        {
            this.texture = texture;
            width = spriteWidth;
            height = spriteHeight;
            currentFrame = 0;
            this.frameLocations = frameLocations;
        }

        public void Update() => currentFrame = (currentFrame + 1) % frameLocations.Length;

        public void Draw(SpriteBatch spriteBatch, Vector2 location) //does not yet randomize which of the two versions of the explosion to draw
        {
            int halfWidthAdjustmentX = (int).5 * LoZHelpers.Scale(width); //only used twice

            Rectangle sourceRectangle = new Rectangle(frameLocations[currentFrame].X, frameLocations[currentFrame].Y, width, height);
            Rectangle destinationRectangleCenter = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));
            Rectangle destinationRectangleUpper = new Rectangle((int)location.X - halfWidthAdjustmentX, (int)location.Y - LoZHelpers.Scale(height), LoZHelpers.Scale(width), LoZHelpers.Scale(height));
            Rectangle destinationRectangleMiddle = new Rectangle((int)location.X + LoZHelpers.Scale(width), (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));
            Rectangle destinationRectangleLower = new Rectangle((int)location.X + halfWidthAdjustmentX, (int)location.Y + LoZHelpers.Scale(height), LoZHelpers.Scale(width), LoZHelpers.Scale(height));
            spriteBatch.Draw(texture, destinationRectangleCenter, sourceRectangle, Color.White);
            spriteBatch.Draw(texture, destinationRectangleUpper, sourceRectangle, Color.White);
            spriteBatch.Draw(texture, destinationRectangleMiddle, sourceRectangle, Color.White);
            spriteBatch.Draw(texture, destinationRectangleLower, sourceRectangle, Color.White);
        }
    }

}
