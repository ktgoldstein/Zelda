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

        private readonly ArrowSkinType skinType;
        private ISprite sprite;
        private Vector2 velocity;
        private int width;
        private int height;
        private int lifeSpan;

        public ArrowProjectile(Vector2 startingLocation, Direction direction, ArrowSkinType skinType)
        {
            Alive = true;

            this.skinType = skinType;
            Location = startingLocation;
            lifeSpan = 20;
            DirectionBasedSetUp(direction);
        }

        public void Update()
        {
            if (lifeSpan == 0)
                Alive = false;
            Location += velocity;
            lifeSpan--;
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
                    width = 8;
                    height = 16;
                    break;
                case Direction.Right:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateArrowRightSprite(skinType);
                    velocity = new Vector2(LoZHelpers.Scale(speed), 0);
                    Location += new Vector2(0, LoZHelpers.Scale(7));
                    width = 8;
                    height = 16;
                    break;
            }
        }
    }
}
