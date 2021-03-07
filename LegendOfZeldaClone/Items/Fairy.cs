using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Fairy : IItem
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite fairy;
        private Vector2 Direction;
        private readonly int height;
        private readonly int width;
        private readonly int speed;

        public Fairy(Vector2 location)
        {
            fairy = ItemSpriteFactory.Instance.CreateFairy();
            Location = location;
            width = 8;
            height = 16;
            Direction = new Vector2(1, 1);
            speed = 2;
            Alive = true;
        }

        public void Update()
        {
            Location += speed * Direction;

            if (Location.Y > (LoZHelpers.GameHeight / 2 + 30))
            {
                Direction.Y = -1;
            }
            else if (Location.Y < (LoZHelpers.GameHeight / 2 - 30))
            {
                Direction.Y = 1;
            }

            if (Location.X > (LoZHelpers.GameWidth / 2 + 50))
            {
                Direction.X = -1;
            }
            else if (Location.X < (LoZHelpers.GameWidth / 2 - 50))
            {
                Direction.X = 1;
            }

            fairy.Update();
        }

        public void Draw(SpriteBatch spriteBatch) => fairy.Draw(spriteBatch, Location);
    }
}
