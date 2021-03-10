using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Enemy
{
    public class BladeTrap : IEnemy
    {
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public int AttackStat { get; }
        public int Health { get; set;}
        private Vector2 direction;
        public Vector2 Direction { get { return direction;} set { direction = value;} }

        private ISprite bladeTrapSprite;
        private float speed = 2;
        private readonly int width;
        private readonly int height;
        private Vector2 knockbackForce = Vector2.Zero;
        public bool Invincible { get; set; }
        public bool Alive { get; set; }

        public BladeTrap(Vector2 location)
        {
            bladeTrapSprite = EnemySpriteFactory.Instance.CreateBladeTrapSprite();
            width = 16;
            height = 16;

            Location = location;
            AttackStat = 1;
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
                direction = new Vector2(0, -1);
            }
            if (Location.Y < 64)
            {
                direction = new Vector2(0, 1);
            }
        }
        public void Knockback(Vector2 direction)
        {
            knockbackForce = direction * 100;
        }
    }
}
