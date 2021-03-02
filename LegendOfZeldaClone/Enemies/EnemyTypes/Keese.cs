using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Enemy
{
    public class Keese : IEnemy
    {
        public Vector2 Location { get; set; }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite keeseSprite;
        private float speed = 2;
        private int direction = 1;
        private readonly int width;
        private readonly int height;

        public Keese(Vector2 location)
        {
            keeseSprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
            width = 16;
            height = 8;

            Location = location;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            keeseSprite.Draw(spritebatch, Location);
        }

        public void Update()
        {
            keeseSprite.Update();

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
