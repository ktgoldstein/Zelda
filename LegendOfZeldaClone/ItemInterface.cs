using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public interface ItemInterface
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
    public class Compass : ItemInterface
    {
        private Texture2D texture;
        public Compass(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(256, 0, 14, 13);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    class Key : ItemInterface
    {
        private Texture2D texture;
        public Key(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(240, 0, 7, 15);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    class Boomerang : ItemInterface
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        public Boomerang(Texture2D texture)
        {
            this.texture = texture;
            currentFrame = 0;
            totalFrames = 2;
        }
        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(128, 0, 7, 12);
            }
            else
            {
                sourceRectangle = new Rectangle(128, 18, 7, 9);
            }
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 12);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    class Bow : ItemInterface
    {
        private Texture2D texture;
        public Bow(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(144, 0, 9, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 12, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    class Heart : ItemInterface
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        public Heart(Texture2D texture)
        {
            this.texture = texture;
            currentFrame = 0;
            totalFrames = 2;
        }
        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            if (currentFrame == 1) 
            {
                sourceRectangle = new Rectangle(0, 0, 7, 7);
            }
            else
            {
                sourceRectangle = new Rectangle(0, 7, 7, 7);
            }
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 8);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    class Rupee : ItemInterface
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        public Rupee(Texture2D texture)
        {
            this.texture = texture;
            currentFrame = 0;
            totalFrames = 2;
        }
        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(70, 0, 10, 16);
            }
            else
            {
                sourceRectangle = new Rectangle(70, 16, 10, 16);
            }
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 12, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    class Arrow : ItemInterface
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        public Arrow(Texture2D texture)
        {
            this.texture = texture;
            currentFrame = 0;
            totalFrames = 2;
        }
        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(152, 0, 8, 16);
            }
            else
            {
                sourceRectangle = new Rectangle(152, 16, 8, 16);
            }
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    class Bomb : ItemInterface
    {
        private Texture2D texture;
        public Bomb(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(134, 0, 10, 15);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 12, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    class Fairy : ItemInterface
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        public Fairy(Texture2D texture)
        {
            this.texture = texture;
            currentFrame = 0;
            totalFrames = 2;
        }
        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(39, 0, 8, 16);
            }
            else
            {
                sourceRectangle = new Rectangle(47, 0, 8, 16);
            }
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    class Clock : ItemInterface
    {
        private Texture2D texture;
        public Clock(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(57, 0, 12, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 12, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    class TriforcePiece : ItemInterface
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        public TriforcePiece(Texture2D texture)
        {
            this.texture = texture;
            currentFrame = 0;
            totalFrames = 2;
        }
        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(274, 1, 12, 14);
            }
            else
            {
                sourceRectangle = new Rectangle(274, 15, 12, 14);
            }
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 12, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    class HeartContainer : ItemInterface
    {
        private Texture2D texture;
        public HeartContainer(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(24, 0, 14, 14);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 16, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    class Map : ItemInterface
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        public Map(Texture2D texture)
        {
            this.texture = texture;
            currentFrame = 0;
            totalFrames = 2;
        }
        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(88, 0, 7, 15);
            }
            else
            {
                sourceRectangle = new Rectangle(88, 15, 7, 15);
            }
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    class Potion : ItemInterface
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        public Potion(Texture2D texture)
        {
            this.texture = texture;
            currentFrame = 0;
            totalFrames = 2;
        }
        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(80, 0, 8, 15);
            }
            else
            {
                sourceRectangle = new Rectangle(80, 15, 8, 15);
            }
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    class Sword : ItemInterface
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        public Sword(Texture2D texture)
        {
            this.texture = texture;
            currentFrame = 0;
            totalFrames = 2;
        }
        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(104, 0, 7, 16);
            }
            else
            {
                sourceRectangle = new Rectangle(104, 16, 7, 16);
            }
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    public class Shield : ItemInterface
    {
        private Texture2D texture;
        public Shield(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(120, 0, 8, 15);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    class Candle : ItemInterface
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        public Candle(Texture2D texture)
        {
            this.texture = texture;
            currentFrame = 0;
            totalFrames = 2;
        }
        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(160, 0, 8, 16);
            }
            else
            {
                sourceRectangle = new Rectangle(160, 16, 8, 16);
            }
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    class Ring : ItemInterface
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        public Ring(Texture2D texture)
        {
            this.texture = texture;
            currentFrame = 0;
            totalFrames = 2;
        }
        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            if (currentFrame == 1)
            {
                sourceRectangle = new Rectangle(169, 0, 7, 12);
            }
            else
            {
                sourceRectangle = new Rectangle(169, 17, 8, 11);
            }
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    public class Staff : ItemInterface
    {
        private Texture2D texture;
        public Staff(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(225, 0, 5, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 8, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }

    public class Book : ItemInterface
    {
        private Texture2D texture;
        public Book(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(231, 0, 9, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 12, 16);

            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
