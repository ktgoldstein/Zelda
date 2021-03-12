using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class LockedDoorUp : IObject
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

        private ISprite lockedDoorUp;
        private readonly int height;
        private readonly int width;

        public LockedDoorUp(Vector2 location)
        {
            lockedDoorUp = ObjectSpriteFactory.Instance.CreateLockedDoorUp();
            Location = location;
            height = 32;
            width = 32;
            BlockHeight = ObjectHeight.Impassable;
            IsMovable = false;
            IsBombable = false;
            IsAlive = true;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            lockedDoorUp.Draw(spriteBatch, Location);
        }
    }
}