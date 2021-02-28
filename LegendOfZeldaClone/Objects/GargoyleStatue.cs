using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class GargoyleStatue : IObject
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }

        private ISprite gargoyleStatue;
        private readonly int height;
        private readonly int width;

        public GargoyleStatue(Vector2 location)
        {
            gargoyleStatue = ObjectSpriteFactory.Instance.CreateGargoyleStatue();
            Location = location;
            height = 16;
            width = 16;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            gargoyleStatue.Draw(spriteBatch, Location);
        }
    }
}