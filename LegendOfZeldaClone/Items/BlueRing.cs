using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class BlueRing : IItem
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite blueRing;
        private readonly int height;
        private readonly int width;

        public BlueRing(Vector2 location)
        {
            blueRing = ItemSpriteFactory.Instance.CreateBlueRing();
            Location = location;
            width = 7;
            height = 9;
            Alive = true;
        }

        public void Update() {}
        public void Draw(SpriteBatch spriteBatch) => blueRing.Draw(spriteBatch, Location);
    }
}
