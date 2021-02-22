using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone
{
    public class LinkUsingItemSprite : ILinkSprite
    {
        public int CurrentFrame { get; set; }

        private readonly Texture2D texture;
        private readonly int totalFrames;
        private readonly int xCoordStart;
        private readonly int yCoordStart;
        private readonly int width;
        private readonly int height;
        private readonly int atlasGap;

        public LinkUsingItemSprite(Texture2D texture, int x, int y, int spriteWidth, int spriteHeight, int spriteAtlasGap, int currentFrame)
        {
            CurrentFrame = currentFrame;

            this.texture = texture;
            totalFrames = 8;
            xCoordStart = x;
            yCoordStart = y;
            width = spriteWidth;
            height = spriteHeight;
            atlasGap = spriteAtlasGap;
        }

        public bool AnimationDone() => CurrentFrame == totalFrames;
        public void Reset() => CurrentFrame = 0;
        public void Update() => CurrentFrame += CurrentFrame < totalFrames ? 1 : 0;

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));
            Rectangle sourceRectangle = new Rectangle(xCoordStart, yCoordStart, width, height);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
