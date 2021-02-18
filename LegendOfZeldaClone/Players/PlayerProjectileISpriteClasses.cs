using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class WoodenSwordSprite : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;
        private Direction direction;

        public WoodenSwordSprite(Texture2D texture, int height, int width, Direction direction)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(242, 148, height, width);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, height, width);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }


        public class WhiteSwordSprite : ISprite
        {
            private Texture2D texture;
            private int height;
            private int width;

            public WhiteSwordSprite(Texture2D texture, int height, int width)
            {
                this.texture = texture;
                this.height = height;
                this.width = width;
            }
            public void Update() { }
            public void Draw(SpriteBatch spriteBatch, Vector2 location)
            {
                Rectangle sourceRectangle = new Rectangle(242, 148, height, width);
                Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, height, width);


                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

            }
        }


    }
