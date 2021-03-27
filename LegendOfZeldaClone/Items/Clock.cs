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

        public Clock(Vector2 location)
        {
            clock = ItemSpriteFactory.Instance.CreateClock();
            Location = location;
            width = 11;
            height = 16;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => clock.Draw(spriteBatch, Location);
        public void BeCollected()
        {
            Alive = false;
            new ClockPickupSoundEffect().Play();
        }
    }
}
