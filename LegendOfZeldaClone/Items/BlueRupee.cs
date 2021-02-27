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

        public BlueRupee(Vector2 location)
        {
            blueRupee = ItemSpriteFactory.Instance.CreateBlueRupee();
            this.location = location;
            this.width = 12;
            this.height = 16;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            blueRupee.Draw(spriteBatch, location);
        }
    }
}
