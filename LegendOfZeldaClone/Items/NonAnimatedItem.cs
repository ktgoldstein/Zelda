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
        public NonAnimatedItem(Texture2D texture, int leftCornerX, int leftCornerY, int itemWidth, int itemHeight, int destWidth, int destHeight)
        {
            this.texture = texture;
            this.leftCornerX = leftCornerX;
            this.leftCornerY = leftCornerY;
            this.itemWidth = itemWidth;
            this.itemHeight = itemHeight;
            this.destWidth = destWidth;
            this.destHeight = destHeight;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(leftCornerX, leftCornerY, itemWidth, itemHeight);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, destWidth, destHeight);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

}
