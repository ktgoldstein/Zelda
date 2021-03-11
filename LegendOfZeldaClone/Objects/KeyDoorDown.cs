using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class KeyDoorDown : IObject
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

        private ISprite keyDoorDown;
        private readonly int height;
        private readonly int width;

        public KeyDoorDown(Vector2 location)
        {
            keyDoorDown = ObjectSpriteFactory.Instance.CreateKeyDoorDown();
            Location = location;
            height = 16;
            width = 32;
            BlockHeight = ObjectHeight.Impassable;
            IsMovable = false;
            IsBombable = false;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            keyDoorDown.Draw(spriteBatch, Location);
        }
    }
}