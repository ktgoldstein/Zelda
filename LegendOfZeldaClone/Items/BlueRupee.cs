using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class BlueRupee : IItem
    {
        private ISprite blueRupee;
        private Vector2 location;
        private int height;
        private int width;
        private readonly LegendOfZeldaDungeon game;
        public bool Alive { get; set; }

        public BlueRupee(Vector2 location)
        {
            blueRupee = ItemSpriteFactory.Instance.CreateBlueRupee();
            this.location = location;
            this.width = 8;
            this.height = 16;
            Alive = true;
        }
        public void Update() {}
        public void Draw(SpriteBatch spriteBatch)
        {
            blueRupee.Draw(spriteBatch, location);
        }
    }
}
