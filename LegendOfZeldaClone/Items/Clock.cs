using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Clock : IItem
    {
        private ISprite clock;
        private Vector2 location;
        private int width;
        private int height;

        public Clock(Vector2 location)
        {
            clock = ItemSpriteFactory.Instance.CreateClock();
            this.location = location;
            this.width = 12;
            this.height = 16;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            clock.Draw(spriteBatch, location);
        }
    }
}
