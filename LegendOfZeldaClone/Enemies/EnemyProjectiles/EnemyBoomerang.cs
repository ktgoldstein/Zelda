using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Enemy
{
    class EnemyBoomerang : IEnemyProjectile
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite boomerangSprite;
        private Vector2 direction;
        private int speed = LoZHelpers.Scale(4);
        private int timer = 0;
        public Goriya goriya;
        private readonly int width;
        private readonly int height;

        public EnemyBoomerang(Vector2 location, Vector2 direction, Goriya goriya)
        {
            boomerangSprite = EnemySpriteFactory.Instance.CreateBoomerangSprite();
            width = 8;
            height = 8;

            Alive = true;
            Location = location;
            this.direction = direction;
            this.direction.Normalize();
            this.goriya = goriya;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            boomerangSprite.Draw(spritebatch, Location);
        }

        public void Update()
        {
            timer++;
            if(timer > 20)
            {
                direction = goriya.Location - Location;
                direction.Normalize();
            }

            Location += direction * speed;
            boomerangSprite.Update();
        }
    }
}
