using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public interface ItemInterface
    {
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
    class Compass : ItemInterface
    {
        private Texture2D texture;
        public Compass(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(256, 0, 14, 13);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    class Key : ItemInterface
    {
        private Texture2D texture;
        public Key(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(240, 0, 7, 15);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 16);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    class Boomerang : ItemInterface
    {
        private Texture2D texture;
        public Boomerang(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(174, 0, 10, 15);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 12, 16);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
