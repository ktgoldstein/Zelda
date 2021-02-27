using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class FlashingRupee: IItem
    {
        private ISprite rupee;
        private Vector2 location;
        private int height;
        private int width;

        public FlashingRupee(Vector2 location)
        {
            rupee = ItemSpriteFactory.Instance.CreateFlashingRupee();
            this.location = location;
            this.width = 12;
            this.height = 16;
        }
        public void Update()
        {
            rupee.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            rupee.Draw(spriteBatch, location);
        }
    }
}
