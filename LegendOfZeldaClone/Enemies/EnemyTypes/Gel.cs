using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Enemy
{
    public class Gel : IEnemy
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
        public int Health { get; set; } = LoZHelpers.GelHP;
        private Vector2 direction;
        public Vector2 Direction { get { return direction;} set { direction = value;} }

        private ISprite gelSprite;
        private float speed = 2;
        private readonly int width;
        private readonly int height;
        private Vector2 knockbackForce = Vector2.Zero;
        public bool Invincible { get; set; }
        public bool Alive { get; set; }
        private int invincibleFrames = 0;

        public Gel(Vector2 location)
        {
            gelSprite = EnemySpriteFactory.Instance.CreateGelSprite();
            width = 8;
            height = 9;

            Location = location;
            Direction = Vector2.UnitY;
            Alive = true;
            AttackStat = 1;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            gelSprite.Draw(spritebatch, Location);
        }

        public void Update()
        {
            gelSprite.Update();

            Location += speed * direction + knockbackForce;
            knockbackForce *= .8f;
            if (Location.Y > 192)
            {
                direction = new Vector2(0, -1);
            }
            if (Location.Y < 64)
            {
                direction = new Vector2(0, 1);
            }
            if(Invincible)
            {
                invincibleFrames++;
                if(invincibleFrames > 10)
                {
                    Invincible = false;
                    invincibleFrames = 0;
                }
            }
        }
        public void Knockback(Vector2 direction)
        {
            knockbackForce = direction * 10;
        }
    }
}
