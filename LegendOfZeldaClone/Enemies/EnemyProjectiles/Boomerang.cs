using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Enemy
{
    class Boomerang : IEnemyProjectile
    {
        public Vector2 Location { get; set; }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite boomerangSprite;
        private Vector2 direction;
        private float speed = 10;
        private int timer = 0;
        private Goriya goriya;
        private readonly int width;
        private readonly int height;

        public Boomerang(Vector2 location, Vector2 direction, Goriya goriya)
        {
            boomerangSprite = EnemySpriteFactory.Instance.CreateBoomerangSprite();
            width = 8;
            height = 8;

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
                direction = goriya.GetGoriyaLocation() - Location;
                direction.Normalize();
            }

            Location += direction * speed;
            if (Vector2.Distance(Location, goriya.GetGoriyaLocation()) < 5)
            {
                goriya.CatchBoomerang();
            }
            boomerangSprite.Update();
        }
    }
}
