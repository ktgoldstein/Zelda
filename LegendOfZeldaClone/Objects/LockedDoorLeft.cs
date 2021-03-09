using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class LockedDoorLeft : IObject
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }

        private ISprite lockedDoorLeft;
        private readonly int height;
        private readonly int width;

        public LockedDoorLeft(Vector2 location)
        {
            lockedDoorLeft = ObjectSpriteFactory.Instance.CreateLockedDoorLeft();
            Location = location;
            height = 32;
            width = 16;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            lockedDoorLeft.Draw(spriteBatch, Location);
        }
    }
}