using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class OrbSprite : ISprite
    {
        public Texture2D Texture;
        private readonly int height;
        private readonly int width;
        public int SourcePosX { get; }
        public int SourcePosY { get; }

        public OrbSprite(Texture2D texture, int height, int width, int sourcePosX, int sourcePosY)
        {
            this.Texture = texture;
            this.height = height;
            this.width = width;
            this.SourcePosX = sourcePosX;
            this.SourcePosY = sourcePosY;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(SourcePosX, SourcePosY, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, LoZHelpers.Scale(width), LoZHelpers.Scale(height));

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }    
}