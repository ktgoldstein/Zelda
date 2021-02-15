using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class NonAnimatedItem : ISprite
    {
        private Texture2D texture;
        private int leftCornerX;
        private int leftCornerY;
        private int itemWidth;
        private int itemHeight;
        private int destWidth;
        private int destHeight;
        public NonAnimatedItem(Texture2D texture, int x, int y, int width, int height, int newWidth, int newHeight)
        {
            this.texture = texture;
            this.leftCornerX = x;
            this.leftCornerY = y;
            this.itemWidth = width;
            this.itemHeight = height;
            this.destWidth = newWidth;
            this.destHeight = newHeight;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(leftCornerX, leftCornerY, itemWidth, itemHeight);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, destWidth, destHeight);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    class AnimatedItem : ISprite
    {
        private Texture2D texture;
        private int leftCornerX;
        private int leftCornerY;
        private int itemWidth;
        private int itemHeight;
        private int destWidth;
        private int destHeight;
        private int secondLeftCornerY;
        private int currentFrame;
        private int totalFrames;
        public AnimatedItem(Texture2D texture, int x, int y, int width, int height, int newWidth, int newHeight)
        {
            this.texture = texture;
            this.leftCornerX = x;
            this.leftCornerY = y;
            this.itemWidth = width;
            this.itemHeight = height;
            this.destWidth = newWidth;
            this.destHeight = newHeight;
            this.secondLeftCornerY = leftCornerY + itemHeight + 2;
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
            {
                sourceRectangle = new Rectangle(leftCornerX, leftCornerY, itemWidth, itemHeight);
            }
            else
            {
                sourceRectangle = new Rectangle(leftCornerX, secondLeftCornerY, itemWidth, itemHeight);
            }
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, destWidth, destHeight);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

}
