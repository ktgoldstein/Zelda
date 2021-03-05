using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class BoomerangProjectile : IPlayerProjectile
    {
        public bool Alive { get; set; }

        private readonly LegendOfZeldaDungeon game;
        private readonly ISprite sprite;
        private readonly int speed;
        private Vector2 velocity;
        private Vector2 location;
        private int lifeSpan;

        public BoomerangProjectile(Vector2 startingLocation, Direction direction, BoomerangSkinType skinType, LegendOfZeldaDungeon game)
        {
            Alive = true;

            this.game = game;
            location = startingLocation;
            speed = 8;
            lifeSpan = 10;
            sprite = PlayerProjectileSpriteFactory.Instance.CreateBoomerangSprite(skinType);
            DirectionBasedSetUp(direction);
        }

        public void Update()
        {
            sprite.Update();
            if (lifeSpan == 0)
            {
                if ((location - game.Link.Location).Length() < 5)
                    Alive = false;

                velocity = game.Link.Location - location;
                velocity.Normalize();
                velocity *= speed;
            }
            else
                lifeSpan--;

            location += velocity;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, location);

        private void DirectionBasedSetUp(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    velocity = new Vector2(0, LoZHelpers.Scale(speed));
                    location += new Vector2(LoZHelpers.Scale(5), 0);
                    break;
                case Direction.Up:
                    velocity = new Vector2(0, -LoZHelpers.Scale(speed));
                    location += new Vector2(LoZHelpers.Scale(3), -LoZHelpers.Scale(1));
                    break;
                case Direction.Left:
                    velocity = new Vector2(-LoZHelpers.Scale(speed), 0);
                    location += new Vector2(0, LoZHelpers.Scale(7));
                    break;
                case Direction.Right:
                    velocity = new Vector2(LoZHelpers.Scale(speed), 0);
                    location += new Vector2(0, LoZHelpers.Scale(7));
                    break;
            }
        }
    }
}
