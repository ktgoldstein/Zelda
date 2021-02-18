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
        private Direction direction;
        private Vector2 location;
        private int lifeSpan;

        public SwordProjectile(Vector2 startingLocation, SwordSkinType skinType, Direction direction)
        {
            this.direction = direction; 
            location = startingLocation;
            this.skinType = skinType;
            lifeSpan = 8;
        }

        public bool Update()
        {
            if (lifeSpan == 0)
                return true;
            switch (lifeSpan)
            {
                case 8:
                    break;
                case 7:
                    location += DirectedMovement() * 11;
                    break;
                case 6:
                case 5:
                    break;
                case 4:
                    location -= DirectedMovement() * 4;
                    break;
                case 3:
                    break;
                case 2:
                    location -= DirectedMovement() * 4;
                    break;
                case 1:
                    break;

            }
            lifeSpan--;
            return false;
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
