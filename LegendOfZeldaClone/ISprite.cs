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
            Rectangle sourceRectangle = new Rectangle(242, 148, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


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
            Rectangle sourceRectangle = new Rectangle(260, 129, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
    public class DragonStatue : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public DragonStatue(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(318, 129, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
    public class DragonStatueBlue : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public DragonStatueBlue(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(299, 129, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }

    public class GargoyleStatue : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public GargoyleStatue(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(337, 129, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }

    public class GargoyleStatueBlue : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public GargoyleStatueBlue(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(280, 129, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }

    public class DottedBlock : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public DottedBlock(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(356, 148, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }

    public class Stairs : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public Stairs(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(299, 148, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
    public class DarkBlock : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public DarkBlock(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(280, 148, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
    public class Water : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public Water(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(261, 148, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }

    public class TunnelOpeningUp : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public TunnelOpeningUp(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(242, 110, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }

    public class TunnelOpeningDown : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public TunnelOpeningDown(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(261, 110, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }

    public class KeyDoorUp : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public KeyDoorUp(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(243, 86, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }

    public class KeyDoorDown : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public KeyDoorDown(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(279, 86, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }

    public class KeyDoorRight : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public KeyDoorRight(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(314, 74, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }

    public class KeyDoorLeft : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public KeyDoorLeft(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(337, 74, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }

    public class LockedDoorUp : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public LockedDoorUp(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(243, 49, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }

    public class LockedDoorDown : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public LockedDoorDown(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(279, 49, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }

    public class LockedDoorRight : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public LockedDoorRight(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(314, 37, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }

    public class LockedDoorLeft : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public LockedDoorLeft(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(337, 37, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }

    public class OpenDoorUp : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public OpenDoorUp(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(243, 12, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
    public class OpenDoorDown : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public OpenDoorDown(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(279, 12, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
    public class OpenDoorRight : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public OpenDoorRight(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(314, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
    public class OpenDoorLeft : ISprite
    {
        private Texture2D texture;
        private int height;
        private int width;

        public OpenDoorLeft(Texture2D texture, int height, int width)
        {
            this.texture = texture;
            this.height = height;
            this.width = width;
        }
        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(337, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);


            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);

        }
    }
}