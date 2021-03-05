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
        private readonly LegendOfZeldaDungeon game;
        public bool Alive { get; set; }

        public Clock(Vector2 location)
        {
            clock = ItemSpriteFactory.Instance.CreateClock();
            this.location = location;
            this.width = 11;
            this.height = 16;
            Alive = true;
        }
        public void Update()
        {
            if ((location - game.Link.Location).Length() < 5)
            {
                Alive = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            clock.Draw(spriteBatch, location);
        }
    }
}
