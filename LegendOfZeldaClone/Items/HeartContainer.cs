using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class HeartContainer : IItem
    {
        private ISprite heartContainer;
        private Vector2 location;
        private int height;
        private int width;

        public HeartContainer(Vector2 location)
        {
            heartContainer = ItemSpriteFactory.Instance.CreateHeartContainer();
            this.location = location;
            this.width = 16;
            this.height = 16;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            heartContainer.Draw(spriteBatch, location);
        }
    }
}
