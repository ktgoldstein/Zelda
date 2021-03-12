using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class KeyDoorRight : IObject
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public ObjectHeight BlockHeight { get; }
        public bool IsMovable { get; }
        public bool IsBombable { get; }
        public bool IsAlive { get; set; }

        private ISprite keyDoorRight;
        private readonly int height;
        private readonly int width;

        public KeyDoorRight(Vector2 location)
        {
            keyDoorRight = ObjectSpriteFactory.Instance.CreateKeyDoorRight();
            Location = location;
            height = 32;
            width = 16;
            BlockHeight = ObjectHeight.Impassable;
            IsMovable = false;
            IsBombable = false;
            IsAlive = true;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            keyDoorRight.Draw(spriteBatch, Location);
        }
    }
}