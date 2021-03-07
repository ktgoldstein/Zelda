using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class BlueCandle : IItem
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite blueCandle;
        private readonly int height;
        private readonly int width;

        public BlueCandle(Vector2 location)
        {
            blueCandle = ItemSpriteFactory.Instance.CreateBlueCandle();
            Location = location;
            height = 16;
            width = 8;
            Alive = true;
        }

        public void Update() {}
        public void Draw(SpriteBatch spriteBatch) => blueCandle.Draw(spriteBatch, Location);
    }
}
