using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class ArrowProjectile : IPlayerProjectile
    {
        public bool Alive { get; set; }

        private readonly ArrowSkinType skinType;
        private ISprite sprite;
        private Vector2 velocity;
        private Vector2 location;
        private int lifeSpan;

        public ArrowProjectile(Vector2 startingLocation, Direction direction, ArrowSkinType skinType)
        {
            Alive = true;

            this.skinType = skinType;
            location = startingLocation;
            lifeSpan = 20;
            DirectionBasedSetUp(direction);
        }

        public void Update()
        {
            if (lifeSpan == 0)
                Alive = false;
            location += velocity;
            lifeSpan--;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, location);

        private void DirectionBasedSetUp(Direction direction)
        {
            int speed = 6;
            switch (direction)
            {
                case Direction.Down:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateArrowDownSprite(skinType);
                    velocity = new Vector2(0, LoZHelpers.Scale(speed));
                    location += new Vector2(LoZHelpers.Scale(5), 0);
                    break;
                case Direction.Up:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateArrowUpSprite(skinType);
                    velocity = new Vector2(0, -LoZHelpers.Scale(speed));
                    location += new Vector2(LoZHelpers.Scale(3), -LoZHelpers.Scale(1));
                    break;
                case Direction.Left:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateArrowLeftSprite(skinType);
                    velocity = new Vector2(-LoZHelpers.Scale(speed), 0);
                    location += new Vector2(0, LoZHelpers.Scale(7));
                    break;
                case Direction.Right:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateArrowRightSprite(skinType);
                    velocity = new Vector2(LoZHelpers.Scale(speed), 0);
                    location += new Vector2(0, LoZHelpers.Scale(7));
                    break;
            }
        }
    }
}
