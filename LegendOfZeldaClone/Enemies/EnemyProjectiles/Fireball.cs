using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Enemy
{
    class Fireball : IEnemyProjectile
    {
        public bool Alive { get; set; }
        public int AttackStat { get; }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite fireballSprite;
        private Vector2 direction;
        private float speed = 5;
        private readonly int width;
        private readonly int height;

        public Fireball(Vector2 location, Vector2 direction)
        {
            fireballSprite = EnemySpriteFactory.Instance.CreateFireballSprite();
            width = 8;
            height = 10;

            Alive = true;
            AttackStat = 1;
            Location = location;
            this.direction = direction;
            this.direction.Normalize();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            fireballSprite.Draw(spritebatch, Location);
        }

        public void Update()
        {
            fireballSprite.Update();
            Location += direction * speed;
        }
    }
}
