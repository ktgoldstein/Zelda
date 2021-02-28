using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class Water : IObject
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }

        private ISprite water;
        private readonly int height;
        private readonly int width;

        public Water(Vector2 location)
        {
            water = ObjectSpriteFactory.Instance.CreateWater();
            Location = location;
            height = 16;
            width = 16;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            water.Draw(spriteBatch, Location);
        }
    }
}