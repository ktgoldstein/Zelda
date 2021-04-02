using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class AnimatedInventorySprite: ISprite
    {
        private readonly Texture2D texture;
        private readonly int xOffset;
        private readonly int yOffset;
        private readonly int nextXOffset;
        private readonly int width;
        private readonly int height;
        private int currentFrame;
        private int totalFrames;

        public AnimatedInventorySprite(Texture2D texture, int xOffset, int yOffset, int width, int height)
        {
            this.texture = texture;
            this.xOffset = xOffset;
            this.yOffset = yOffset;
            this.width = width;
            this.height = height;
            currentFrame = 0;
            totalFrames = 2;
            nextXOffset = this.xOffset - 17;
        }
        
        public void Update() 
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }

        public void Draw(SpriteBatch spritebatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            if (currentFrame == 1)
                sourceRectangle = new Rectangle(xOffset, yOffset, width, height);
            else
                sourceRectangle = new Rectangle(nextXOffset, yOffset, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));

            spritebatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
