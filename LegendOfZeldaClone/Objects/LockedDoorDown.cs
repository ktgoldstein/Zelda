using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class LockedDoorDown : IObject
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }

        private ISprite lockedDoorDown;
        private readonly int height;
        private readonly int width;

        public LockedDoorDown(Vector2 location)
        {
            lockedDoorDown = ObjectSpriteFactory.Instance.CreateLockedDoorDown();
            Location = location;
            height = 16;
            width = 32;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            lockedDoorDown.Draw(spriteBatch, Location);
        }
    }
}