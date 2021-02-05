using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{

    public interface ISprite
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
    }

    public class NonMovingNonAnimatedSprite : ISprite
    {
        private Texture2D texture;
  
        public NonMovingNonAnimatedSprite(Texture2D texture)
        {
            this.texture = texture;
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(1, 11, 16, 16);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 32);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    public class NonMovingAnimatedSprite : ISprite
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;

        public NonMovingAnimatedSprite(Texture2D texture)
        {
            this.texture = texture;
            currentFrame = 0;
            totalFrames = 6;
        }

        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if(currentFrame == 1)
            {
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 32);
                sourceRectangle = new Rectangle(94, 47, 16, 16);
            }
            else if(currentFrame == 2)
            {

                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 54);
                sourceRectangle = new Rectangle(111, 47, 16, 27);
            }
            else if(currentFrame == 3)
            {

                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 46);
                sourceRectangle = new Rectangle(128, 47, 16, 23);
            }
            else if(currentFrame == 4)
            {

                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 38);
                sourceRectangle = new Rectangle(145, 47, 16, 19);
            }
            else
            {
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 32, 32);
                sourceRectangle = new Rectangle(1, 11, 16, 16);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    public class MovingNonAnimatedSprite : ISprite
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;

        public MovingNonAnimatedSprite(Texture2D texture)
        {
            this.texture = texture;
            currentFrame = 0;
            totalFrames = 8;
        }

        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(1, 11, 16, 16);
            Rectangle destinationRectangle;

            if(currentFrame < 4)
            {
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y + currentFrame, 32, 32);
            }
            else
            {
                destinationRectangle = new Rectangle((int)location.X, (int)location.Y + totalFrames - currentFrame, 32, 32);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
}

    public class MovingAnimatedSprite : ISprite
    {
        private Texture2D texture;
        private int currentFrame;
        private int totalFrames;
        private int displacement;
        private int maxDisplacement;

        public MovingAnimatedSprite(Texture2D texture, int gameWidth)
        {
            this.texture = texture;
            currentFrame = 0;
            totalFrames = 2;
            displacement = 0;
            maxDisplacement = gameWidth /2;
        }

        public void Update()
        {
            currentFrame++;
            currentFrame %= totalFrames;
            displacement += 4;
            if(displacement > maxDisplacement)
            {
                displacement = -maxDisplacement;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle = new Rectangle((int)location.X + displacement, (int)location.Y, 32, 32);

            if(currentFrame % 2 == 0)
            {
                sourceRectangle = new Rectangle(35, 11, 16, 16);
            }
            else
            {
                sourceRectangle = new Rectangle(52, 11, 16, 16);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }

    public class TextSprite : ISprite
    {
        private string content;
        private SpriteFont font;

        public TextSprite(SpriteFont font, string text)
        {
            this.font = font;
            content = text;
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, content, location, Color.White);
            spriteBatch.End();
        }
    }
}
