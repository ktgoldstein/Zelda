using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class Stairs : IObject
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }

        private ISprite stairs;
        private readonly int height;
        private readonly int width;

        public Stairs(Vector2 location)
        {
            stairs = ObjectSpriteFactory.Instance.CreateStairs();
            Location = location;
            height = 16;
            width = 16;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            stairs.Draw(spriteBatch, Location);
        }
    }
}