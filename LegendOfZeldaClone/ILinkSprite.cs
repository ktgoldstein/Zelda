using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone
{
    public interface ILinkSprite : ISprite
    {
        public int CurrentFrame { get; set; }
        public bool AnimationDone();
    }

    public class LinkStandingSprite : ILinkSprite
    {
        public int CurrentFrame { get; set; }

        private Texture2D texture;
        private int xCoordStart;
        private int yCoordStart;
        private int width;
        private int height;
        private int atlasGap;

        public LinkStandingSprite(Texture2D texture, int x, int y, int spriteWidth, int spriteHeight, int spriteAtlasGap, int currentFrame = 0)
        {
            CurrentFrame = currentFrame;

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
        public int CurrentFrame { get; set; }

        private Texture2D texture;
        private int totalFrames;
        private int xCoordStart;
        private int yCoordStart;
        private int width;
        private int height;
        private int atlasGap;

        public LinkWalkingSprite(Texture2D texture, int x, int y, int spriteWidth, int spriteHeight, int spriteAtlasGap, int currentFrame = 0)
        {
            CurrentFrame = currentFrame;

            this.texture = texture;
            totalFrames = 2;
            xCoordStart = x;
            yCoordStart = y;
            width = spriteWidth;
            height = spriteHeight;
            atlasGap = spriteAtlasGap;

        }

        public void Update()
        {
            CurrentFrame += CurrentFrame < totalFrames ? 1 : 0;
        }

        public bool AnimationDone() => CurrentFrame == totalFrames;

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));
            Rectangle sourceRectangle = CurrentFrame switch
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
        public int CurrentFrame { get; set; }

        private Texture2D texture;
        private int totalFrames;
        private int xCoordStart;
        private int yCoordStart;
        private int width;
        private int height;
        private int atlasGap;

        public LinkUsingItemSprite(Texture2D texture, int x, int y, int spriteWidth, int spriteHeight, int spriteAtlasGap, int currentFrame = 0)
        {
            CurrentFrame = currentFrame;

            this.texture = texture;
            totalFrames = 4;
            xCoordStart = x;
            yCoordStart = y;
            width = spriteWidth;
            height = spriteHeight;
            atlasGap = spriteAtlasGap;

        }

        public void Update()
        {
            CurrentFrame += CurrentFrame < totalFrames ? 1 : 0;
        }

        public bool AnimationDone() => CurrentFrame == totalFrames;

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));
            Rectangle sourceRectangle = new Rectangle(xCoordStart, yCoordStart, LoZHelpers.Scale(width), LoZHelpers.Scale(height));

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    public class LinkPickingUpItemSprite : ILinkSprite
    {
        public int CurrentFrame { get; set; }

        private Texture2D texture;
        private int totalFrames;
        private int xCoordStart;
        private int yCoordStart;
        private int width;
        private int height;
        private int atlasGap;

        public LinkPickingUpItemSprite(Texture2D texture, int x, int y, int spriteWidth, int spriteHeight, int spriteAtlasGap, int currentFrame = 0)
        {
            CurrentFrame = currentFrame;

            this.texture = texture;
            totalFrames = 2;
            xCoordStart = x;
            yCoordStart = y;
            width = spriteWidth;
            height = spriteHeight;
            atlasGap = spriteAtlasGap;

        }

        public void Update()
        {
            CurrentFrame += CurrentFrame < totalFrames ? 1 : 0;
        }

        public bool AnimationDone() => CurrentFrame == totalFrames;

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));
            Rectangle sourceRectangle = CurrentFrame switch
            {
                0 => new Rectangle(xCoordStart, yCoordStart, LoZHelpers.Scale(width), LoZHelpers.Scale(height)),
                1 => new Rectangle(xCoordStart + (atlasGap + width), yCoordStart, LoZHelpers.Scale(width), LoZHelpers.Scale(height)),
                _ => new Rectangle(0, 0, LoZHelpers.Scale(width), LoZHelpers.Scale(height))
            };

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
