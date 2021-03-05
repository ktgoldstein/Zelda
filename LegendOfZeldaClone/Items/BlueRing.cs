using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class BlueRing : IItem
    {
        private ISprite blueRing;
        private Vector2 location;
        private int height;
        private int width;
        private readonly LegendOfZeldaDungeon game;
        public bool Alive { get; set; }

        public BlueRing(Vector2 location)
        {
            blueRing = ItemSpriteFactory.Instance.CreateBlueRing();
            this.location = location;
            this.width = 7;
            this.height = 9;
            Alive = true;
        }
        public void Update() {}
        public void Draw(SpriteBatch spriteBatch)
        {
            blueRing.Draw(spriteBatch, location);
        }
    }
}
