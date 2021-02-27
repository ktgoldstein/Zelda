using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class GoldRupee : IItem
    {
        private ISprite goldRupee;
        private Vector2 location;
        private int height;
        private int width;

        public GoldRupee(Vector2 location)
        {
            goldRupee = ItemSpriteFactory.Instance.CreateGoldRupee();
            this.location = location;
            this.width = 12;
            this.height = 16;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            goldRupee.Draw(spriteBatch, location);
        }
    }
}
