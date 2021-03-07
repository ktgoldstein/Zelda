using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class AnimatedItemSprite : ISprite
    {
        private Texture2D texture;
        private int leftCornerX;
        private int leftCornerY;
        private int itemWidth;
        private int itemHeight;
        private int secondFrameLeftCornerY;
        private int currentFrame;
        private int totalFrames;

        public AnimatedItemSprite(Texture2D texture, int leftCornerX, int leftCornerY, int itemWidth, int itemHeight)
        {
            this.texture = texture;
            this.leftCornerX = leftCornerX;
            this.leftCornerY = leftCornerY;
            this.itemWidth = itemWidth;
            this.itemHeight = itemHeight;
            secondFrameLeftCornerY = leftCornerY + itemHeight + 2;
            currentFrame = 0;
            totalFrames = 2;
        }

        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            if (currentFrame == 1)
                sourceRectangle = new Rectangle(leftCornerX, secondFrameLeftCornerY, itemWidth, itemHeight);
            else
                sourceRectangle = new Rectangle(leftCornerX, leftCornerY, itemWidth, itemHeight);
            
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(itemWidth), LoZHelpers.Scale(itemHeight));

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

}
