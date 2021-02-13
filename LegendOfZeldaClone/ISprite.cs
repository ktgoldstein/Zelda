using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface ISprite
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
    }

    public class LinkStandingSprite : ISprite
    {
        private Texture2D texture;
        private int xCoordStart;
        private int yCoordStart;
        private int width;
        private int height;
        private int atlasGap;
  
        public LinkStandingSprite(Texture2D texture, int x, int y, int spriteWidth, int spriteHeight, int spriteAtlasGap)
        {
            this.texture = texture;
            this.xCoordStart = x;
            this.yCoordStart = y;
            width = spriteWidth;
            height = spriteHeight;
            atlasGap = spriteAtlasGap;
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(xCoordStart, yCoordStart, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * 2, height * 2);

            spriteBatch.Begin(); //saw a comment about leaving Begin() and End() only to be -
            //called in the main Game1/LegendOfZeldaDungeon class

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    public class LinkWalkingSprite : ISprite
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        private int xCoordStart;
        private int yCoordStart;
        private int width;
        private int height;
        private int atlasGap;

        public LinkWalkingSprite(Texture2D texture, int x, int y, int spriteWidth, int spriteHeight, int spriteAtlasGap)
        {
            this.texture = texture;
            currentFrame = 0;
            totalFrames = 2;
            xCoordStart = x;
            yCoordStart = y;
            width = spriteWidth;
            height = spriteHeight;
            atlasGap = spriteAtlasGap;

        }

        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * 2, height * 2);


            //Alternative single-line solution:
            xCoordStart += (atlasGap * currentFrame) + (width * (currentFrame-1));

            switch (currentFrame)
            {
                case 1:
                    xCoordStart += atlasGap;
                    break;
                case 2:
                    xCoordStart += (atlasGap * currentFrame) + (width*(currentFrame-1));
                    break;

            }

            sourceRectangle = new Rectangle(xCoordStart, yCoordStart, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    public class LinkUsingItemSprite : ISprite
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        private int xCoordStart;
        private int yCoordStart;
        private int width;
        private int height;
        private int atlasGap;

        public LinkUsingItemSprite(Texture2D texture, int x, int y, int spriteWidth, int spriteHeight, int spriteAtlasGap)
        {
            this.texture = texture;
            currentFrame = 0;
            totalFrames = 2;
            xCoordStart = x;
            yCoordStart = y;
            width = spriteWidth;
            height = spriteHeight;
            atlasGap = spriteAtlasGap;

        }

        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * 2, height * 2);


            //Alternative single-line solution:
            xCoordStart += (atlasGap * currentFrame) + (width * (currentFrame - 1));

            switch (currentFrame)
            {
                case 1:
                    xCoordStart += atlasGap;
                    break;
                case 2:
                    xCoordStart += (atlasGap * currentFrame) + (width * (currentFrame - 1));
                    break;
                case 3:
                    xCoordStart += (atlasGap * currentFrame) + (width * (currentFrame - 1));
                    break;
                case 4:
                    xCoordStart += (atlasGap * currentFrame) + (width * (currentFrame - 1));
                    break;

            }

            sourceRectangle = new Rectangle(xCoordStart, yCoordStart, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    public class LinkPickingUpItemSprite : ISprite
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        private int xCoordStart;
        private int yCoordStart;
        private int width;
        private int height;
        private int atlasGap;

        public LinkPickingUpItemSprite(Texture2D texture, int x, int y, int spriteWidth, int spriteHeight, int spriteAtlasGap)
        {
            this.texture = texture;
            currentFrame = 0;
            totalFrames = 2;
            xCoordStart = x;
            yCoordStart = y;
            width = spriteWidth;
            height = spriteHeight;
            atlasGap = spriteAtlasGap;

        }

        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * 2, height * 2);


            //Alternative single-line solution:
            xCoordStart += (atlasGap * currentFrame) + (width * (currentFrame - 1));

            switch (currentFrame)
            {
                case 1:
                    xCoordStart += atlasGap;
                    break;
                case 2:
                    xCoordStart += (atlasGap * currentFrame) + (width * (currentFrame - 1));
                    break;

            }

            sourceRectangle = new Rectangle(xCoordStart, yCoordStart, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

   
}
