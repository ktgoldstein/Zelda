using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface IPlayerProjectile
    {
        public bool Update();
        public void Draw(SpriteBatch spriteBatch);
    }

    public class SwordProjectile : IPlayerProjectile
    {
        private SwordSkinType skinType;
        private ISprite sprite;
        private Direction direction;
        private Vector2 location;
        private int lifeSpan;

        public SwordProjectile(Vector2 startingLocation, SwordSkinType skinType, Direction direction)
        {
            this.direction = direction; 
            location = startingLocation;
            this.skinType = skinType;
            lifeSpan = 8;
            DirectionBasedSetUp(direction);
        }

        public bool Update()
        {
            if (lifeSpan == 0)
                return true;
            switch (lifeSpan)
            {
                case 8:
                    location += DirectedMovement() * LoZHelpers.Scale(2);
                    break;
                case 7:
                    location += DirectedMovement() * LoZHelpers.Scale(9);
                    break;
                case 6:
                case 5:
                    break;
                case 4:
                    location -= DirectedMovement() * LoZHelpers.Scale(4);
                    break;
                case 3:
                    break;
                case 2:
                    location -= DirectedMovement() * LoZHelpers.Scale(4);
                    break;
                case 1:
                    break;
            }
            lifeSpan--;
            return false;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, location);

        private void DirectionBasedSetUp(Direction direction)
        {            
            switch(direction)
            {
                case Direction.Down:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateSwordDownSprite(skinType);
                    location += new Vector2(LoZHelpers.Scale(5), 0);
                    break;
                case Direction.Up:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateSwordUpSprite(skinType);
                    location += new Vector2(LoZHelpers.Scale(3), -LoZHelpers.Scale(1));
                    break;
                case Direction.Left:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateSwordLeftSprite(skinType);
                    location += new Vector2(0, LoZHelpers.Scale(7));
                    break;
                case Direction.Right:
                    sprite = PlayerProjectileSpriteFactory.Instance.CreateSwordRightSprite(skinType);
                    location += new Vector2(0, LoZHelpers.Scale(7));
                    break;
            };
        }

        private Vector2 DirectedMovement()
        {
            return direction switch
            {
                Direction.Down => new Vector2(0, 1),
                Direction.Up => new Vector2(0, -1),
                Direction.Left => new Vector2(-1, 0),
                Direction.Right => new Vector2(1, 0),
                _ => new Vector2(0, 0)
            };
        }
    }
}
