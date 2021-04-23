using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class AnimatedBlockSprite : ISprite
    {
        public Texture2D Texture;
        private readonly int height;
        private readonly int width;
        private readonly int sourcePosX;
        private readonly int sourcePosY;
        private readonly int atlasWidth;
        private int currentFrame;

        public AnimatedBlockSprite(Texture2D texture, int height, int width, int sourcePosX, int sourcePosY, int atlasWidth, int startingFrame)
        {
            Texture = texture;
            this.height = height;
            this.width = width;
            this.sourcePosX = sourcePosX;
            this.sourcePosY = sourcePosY;
            this.atlasWidth = atlasWidth;

            currentFrame = startingFrame;
        }

        public void Update() => currentFrame = (currentFrame + 1) % 2;
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(sourcePosX + (width + atlasWidth) * currentFrame, sourcePosY, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }    
}