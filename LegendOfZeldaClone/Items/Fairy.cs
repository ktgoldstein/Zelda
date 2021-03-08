using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Fairy : IItem
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation { get { return Location; } }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite fairy;
        public Vector2 FairyDirection { get; set; }
        private readonly int height;
        private readonly int width;
        private readonly int speed;

        public Fairy(Vector2 location)
        {
            fairy = ItemSpriteFactory.Instance.CreateFairy();
            Location = location;
            width = 8;
            height = 16;
            FairyDirection = new Vector2(1, 1);
            speed = 2;
            Alive = true;
        }

        public void Update()
        {
            Location += speed * FairyDirection;

            if (Location.Y > LoZHelpers.GameHeight)
            {
                FairyDirection = new Vector2(1, -1);
            }
            else if (Location.Y < LoZHelpers.Scale(0))
            {
                FairyDirection = new Vector2(1, 1);
            }

            if (Location.X > LoZHelpers.GameWidth)
            {
                FairyDirection = new Vector2(-1, 1);
            }
            else if (Location.X < LoZHelpers.Scale(0))
            {
                FairyDirection = new Vector2(1, 1);
            }

            fairy.Update();
        }

        public void Draw(SpriteBatch spriteBatch) => fairy.Draw(spriteBatch, Location);
    }
}
