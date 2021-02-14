using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface ISprite
    {
        public void Update();
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
    }

    public class FlatBlock : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public FlatBlock(Texture2D texture, int height, int width)
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
    public class RaisedBlock : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public RaisedBlock(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(260, 128, height, width);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, height, width);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
    public class Statue : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public Statue(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(318, 129, height, width);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, height, width);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
    public class Statue2 : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public Statue2(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(337, 129, height, width);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, height, width);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
    public class blueStatue : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public blueStatue(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(299, 129, height, width);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, height, width);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
}
