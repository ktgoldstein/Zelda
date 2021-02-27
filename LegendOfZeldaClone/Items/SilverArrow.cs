using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class SilverArrow : IItem
    {
        private ISprite silverArrow;
        private Vector2 location;
        private int height;
        private int width;

        public SilverArrow(Vector2 location)
        {
            silverArrow = ItemSpriteFactory.Instance.CreateSilverArrow();
            this.location = location;
            this.width = 8;
            this.height = 16;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            silverArrow.Draw(spriteBatch, location);
        }
    }
}
