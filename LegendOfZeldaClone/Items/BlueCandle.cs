using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class BlueCandle : IItem
    {
        private ISprite blueCandle;
        private Vector2 location;
        private int height;
        private int width;
        private readonly LegendOfZeldaDungeon game;
        public bool Alive { get; set; }

        public BlueCandle(Vector2 location)
        {
            blueCandle = ItemSpriteFactory.Instance.CreateBlueCandle();
            this.location = location;
            this.height = 16;
            this.width = 8;
            Alive = true;
        }
        public void Update() {}
        public void Draw(SpriteBatch spriteBatch)
        {
            blueCandle.Draw(spriteBatch, location);
        }
    }
}
