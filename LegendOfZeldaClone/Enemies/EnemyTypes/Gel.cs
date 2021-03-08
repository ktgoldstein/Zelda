using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Enemy
{
    public class Gel : IEnemy
    {
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation { get { return Location; } }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite gelSprite;
        private float speed = 2;
        private int direction = 1;
        private readonly int width;
        private readonly int height;

        public Gel(Vector2 location)
        {
            gelSprite = EnemySpriteFactory.Instance.CreateGelSprite();
            width = 8;
            height = 9;

            Location = location;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            gelSprite.Draw(spritebatch, Location);
        }

        public void Update()
        {
            gelSprite.Update();

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
