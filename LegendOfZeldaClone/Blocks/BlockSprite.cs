using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class BlockSprite : ISprite
    {
        private readonly Texture2D texture;
        private readonly int height;
        private readonly int width;
        private readonly int sourcePosX;
        private readonly int sourcePosY;

        public BlockSprite(Texture2D texture, int height, int width, int sourcePosX, int sourcePosY)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
            this.sourcePosX = sourcePosX;
            this.sourcePosY = sourcePosY;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(sourcePosX, sourcePosY, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }    
}