using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class ArrowProjectile : IPlayerProjectile
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
        private readonly ArrowSkinType skinType;
        private ISprite sprite;
        private Vector2 velocity;
        private int width;
        private int height;

        public ArrowProjectile(Vector2 startingLocation, Direction direction, ArrowSkinType skinType, LegendOfZeldaDungeon game)
        {
            Alive = true;

            this.skinType = skinType;
            Location = startingLocation;
            DirectionBasedSetUp(direction);
            this.game = game;
        }

        public void Update()
        {
            Location += velocity;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);

        private void DirectionBasedSetUp(Direction direction)
        {
            int speed = 6;
            switch (direction)
            {
                case Direction.Down:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateArrowDownSprite(skinType);
                    velocity = new Vector2(0, LoZHelpers.Scale(speed));
                    Location += new Vector2(LoZHelpers.Scale(5), 0);
                    width = 8;
                    height = 16;
                    break;
                case Direction.Up:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateArrowUpSprite(skinType);
                    velocity = new Vector2(0, -LoZHelpers.Scale(speed));
                    Location += new Vector2(LoZHelpers.Scale(3), -LoZHelpers.Scale(1));
                    width = 8;
                    height = 16;
                    break;
                case Direction.Left:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateArrowLeftSprite(skinType);
                    velocity = new Vector2(-LoZHelpers.Scale(speed), 0);
                    Location += new Vector2(0, LoZHelpers.Scale(7));
                    width = 16;
                    height = 8;
                    break;
                case Direction.Right:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateArrowRightSprite(skinType);
                    velocity = new Vector2(LoZHelpers.Scale(speed), 0);
                    Location += new Vector2(0, LoZHelpers.Scale(7));
                    width = 16;
                    height = 8;
                    break;
            }
        }
        public void SpawnArrowExplosion()
        {
            game.PlayerProjectilesQueue.Add(new ArrowImpactProjectile(Location, skinType));
            Alive = false;
        }
    }
}
