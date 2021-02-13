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
            Rectangle sourceRectangle = new Rectangle(128, 0, 7, 12);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 12);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    class Bow : ItemInterface
    {
        private Texture2D texture;
        public Bow(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(144, 0, 9, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 12, 16);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    class Heart : ItemInterface
    {
        private Texture2D texture;
        public Heart(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 7, 7);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 8);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    class Rupee : ItemInterface
    {
        private Texture2D texture;
        public Rupee(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(70, 0, 10, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 12, 16);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    class Arrow : ItemInterface
    {
        private Texture2D texture;
        public Arrow(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(152, 0, 8, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 16);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    class Bomb : ItemInterface
    {
        private Texture2D texture;
        public Bomb(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(134, 0, 10, 15);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 12, 16);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    class Fairy : ItemInterface
    {
        private Texture2D texture;
        public Fairy(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(39, 0, 8, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 16);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    class Clock : ItemInterface
    {
        private Texture2D texture;
        public Clock(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(57, 0, 12, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 12, 16);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    class TriforcePiece : ItemInterface
    {
        private Texture2D texture;
        public TriforcePiece(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(274, 1, 12, 14);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 12, 16);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    class HeartContainer : ItemInterface
    {
        private Texture2D texture;
        public HeartContainer(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(24, 0, 14, 14);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    class Map : ItemInterface
    {
        private Texture2D texture;
        public Map(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(88, 0, 7, 15);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 16);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
