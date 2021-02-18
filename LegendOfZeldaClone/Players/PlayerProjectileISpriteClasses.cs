using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class SwordProjectileSprite : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;
        private Direction direction;
        private int xOffset;
        private int yOffset;

        public SwordProjectileSprite(Texture2D texture, int height, int width, Direction direction)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
            this.direction = direction;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(242, 148, height, width);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, height, width);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }


       
        


    }
