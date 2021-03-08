using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class FireProjectile : IPlayerProjectile
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation { get { return Location; } }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private readonly ISprite sprite;
        private readonly int speed;
        private Vector2 velocity;
        private readonly int width;
        private readonly int height;
        private int lifeSpan;

        public FireProjectile(Vector2 startingLocation, Direction direction)
        {
            Alive = true;
            width = 16;
            height = 16;

            Location = startingLocation;
            speed = 1;
            lifeSpan = 20;
            sprite = PlayerProjectileSpriteFactory.Instance.CreateFireSprite();
            DirectionBasedSetUp(direction);
        }

        public void Update()
        {
            sprite.Update();
            if (lifeSpan == 0)
                Alive = false;

            lifeSpan--;
            Location += velocity;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);

        private void DirectionBasedSetUp(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    velocity = new Vector2(0, LoZHelpers.Scale(speed));
                    Location += new Vector2(0, LoZHelpers.Scale(16));
                    break;
                case Direction.Up:
                    velocity = new Vector2(0, -LoZHelpers.Scale(speed));
                    Location += new Vector2(0, -LoZHelpers.Scale(16));
                    break;
                case Direction.Left:
                    velocity = new Vector2(-LoZHelpers.Scale(speed), 0);
                    Location += new Vector2(-LoZHelpers.Scale(16), 0);
                    break;
                case Direction.Right:
                    velocity = new Vector2(LoZHelpers.Scale(speed), 0);
                    Location += new Vector2(LoZHelpers.Scale(16), 0);
                    break;
            }
        }
    }
}
