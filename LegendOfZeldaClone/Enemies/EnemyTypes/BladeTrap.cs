using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Enemy
{
    public class BladeTrap : IEnemy
    {
        public Vector2 Location { get; set; }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite bladeTrapSprite;
        private float speed = 2;
        private int direction = 1;
        private readonly int width;
        private readonly int height;

        public BladeTrap(Vector2 location)
        {
            bladeTrapSprite = EnemySpriteFactory.Instance.CreateBladeTrapSprite();
            width = 16;
            height = 16;

            Location = location;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            bladeTrapSprite.Draw(spritebatch, Location);
        }

        public void Update()
        {
            bladeTrapSprite.Update();

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
