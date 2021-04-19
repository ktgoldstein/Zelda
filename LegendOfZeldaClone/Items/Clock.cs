using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Clock : IItem
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite clock;
        private readonly int width;
        private readonly int height;
        private int lifespan;

        public Clock(Vector2 location, int lifespan = -1)
        {
            clock = ItemSpriteFactory.Instance.CreateClock();
            Location = location;
            width = 11;
            height = 16;
            Alive = true;
            this.lifespan = lifespan;
        }

        public void Update()
        {
            if (lifespan > 0 && Alive)
            {
                lifespan--;
                if (lifespan == 0)
                {
                    Alive = false;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch) => clock.Draw(spriteBatch, Location);
        public void Die()
        {
            Alive = false;
            new ClockPickupSoundEffect().Play();
        }
        public void BuyItem() { }
    }
}
