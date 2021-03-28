using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class BoomerangProjectile : IPlayerProjectile
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

        private readonly LegendOfZeldaDungeon game;
        private readonly ISprite sprite;
        private readonly int speed;
        private Vector2 velocity;
        private readonly int width;
        private readonly int height;
        private int lifeSpan;
        private int soundEffectLoopHelper;

        public IPlayer link;

        public BoomerangProjectile(Vector2 startingLocation, Direction direction, BoomerangSkinType skinType, LegendOfZeldaDungeon game, IPlayer link)
        {
            Alive = true;
            width = 8;
            height = 8;

            this.game = game;
            this.link = link;
            Location = startingLocation;
            speed = 8;
            lifeSpan = 10;
            sprite = PlayerProjectileSpriteFactory.Instance.CreateBoomerangSprite(skinType);
            soundEffectLoopHelper = 1000;

            DirectionBasedSetUp(direction);
        }

        public void Update()
        {
            sprite.Update();
            if (lifeSpan == 0)
            {
                velocity = game.Player.Location - Location;
                velocity.Normalize();
                velocity *= speed;

            }
            else
                lifeSpan--; 
            if (soundEffectLoopHelper % 4 == 0 && Alive)
                new BoomerangFlyingSoundEffect().Play();
            soundEffectLoopHelper--;
            Location += velocity;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);

        private void DirectionBasedSetUp(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    velocity = new Vector2(0, LoZHelpers.Scale(speed));
                    Location += new Vector2(LoZHelpers.Scale(5), link.Height);
                    break;
                case Direction.Up:
                    velocity = new Vector2(0, -LoZHelpers.Scale(speed));
                    Location += new Vector2(LoZHelpers.Scale(3), -LoZHelpers.Scale(1));
                    break;
                case Direction.Left:
                    velocity = new Vector2(-LoZHelpers.Scale(speed), 0);
                    Location += new Vector2(0, LoZHelpers.Scale(7));
                    break;
                case Direction.Right:
                    velocity = new Vector2(LoZHelpers.Scale(speed), 0);
                    Location += new Vector2(link.Width, LoZHelpers.Scale(7));
                    break;
            }
        }
        public void Die() => Alive = false;
    }
}
