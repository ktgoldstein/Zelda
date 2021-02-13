using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone
{
    public interface ILinkSprite : ISprite
    {
        public bool AnimationDone();
    }

    public class LinkStandingSprite : ILinkSprite
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
            xCoordStart = x;
            yCoordStart = y;
            width = spriteWidth;
            height = spriteHeight;
            atlasGap = spriteAtlasGap;
        }

        public void Update() { }

        public bool AnimationDone() => true;

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(xCoordStart, yCoordStart, LoZHelpers.Scale(width), LoZHelpers.Scale(height));
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    public class LinkWalkingSprite : ILinkSprite
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
            currentFrame += currentFrame < totalFrames ? 1 : 0;
        }

        public bool AnimationDone() => currentFrame == totalFrames;

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));
            Rectangle sourceRectangle = currentFrame switch
            {
                0 => new Rectangle(xCoordStart, yCoordStart, LoZHelpers.Scale(width), LoZHelpers.Scale(height)),
                1 => new Rectangle(xCoordStart + (atlasGap + width), yCoordStart, LoZHelpers.Scale(width), LoZHelpers.Scale(height)),
                _ => new Rectangle(0, 0, LoZHelpers.Scale(width), LoZHelpers.Scale(height))
            };

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    public class LinkUsingItemSprite : ILinkSprite
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
            totalFrames = 4;
            xCoordStart = x;
            yCoordStart = y;
            width = spriteWidth;
            height = spriteHeight;
            atlasGap = spriteAtlasGap;

        }

        public void Update()
        {
            currentFrame += currentFrame < totalFrames ? 1 : 0;
        }

        public bool AnimationDone() => currentFrame == totalFrames;

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));
            Rectangle sourceRectangle = new Rectangle(xCoordStart, yCoordStart, LoZHelpers.Scale(width), LoZHelpers.Scale(height));

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    public class LinkPickingUpItemSprite : ILinkSprite
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
            currentFrame += currentFrame < totalFrames ? 1 : 0;
        }

        public bool AnimationDone() => currentFrame == totalFrames;

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));
            Rectangle sourceRectangle = currentFrame switch
            {
                0 => new Rectangle(xCoordStart, yCoordStart, LoZHelpers.Scale(width), LoZHelpers.Scale(height)),
                1 => new Rectangle(xCoordStart + (atlasGap + width), yCoordStart, LoZHelpers.Scale(width), LoZHelpers.Scale(height)),
                _ => new Rectangle(0, 0, LoZHelpers.Scale(width), LoZHelpers.Scale(height))
            };

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
