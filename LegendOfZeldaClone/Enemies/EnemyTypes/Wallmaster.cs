using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Enemy
{
    public class Wallmaster : IEnemy
    {
        public Vector2 Location { get; set; }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        private int health;
        public int Health { get { return LoZHelpers.WallmasterHP; } set { health = value; } }

        private ISprite wallmasterSprite;
        private float speed = 2;
        private int direction = 1;
        private readonly int width;
        private readonly int height;

        public Wallmaster(Vector2 location)
        {
            wallmasterSprite = EnemySpriteFactory.Instance.CreateWallmasterSprite();
            width = 16;
            height = 16;

            Location = location;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            wallmasterSprite.Draw(spritebatch, Location);
        }

        public void Update()
        {
            wallmasterSprite.Update();

            Location += speed * direction * Vector2.UnitY;
            if (Location.Y > 192)
            {
                direction = -1;
            }
            if (Location.Y < 64)
            {
                direction = 1;
            }
        }
    }
}
