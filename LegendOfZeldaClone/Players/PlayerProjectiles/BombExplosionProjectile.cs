using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class BombExplosionProjectile : IPlayerProjectile
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private readonly ISprite sprite;
        private readonly int width;
        private readonly int height;
        private readonly int maxLifeSpan;
        private int lifeSpan;

        public BombExplosionProjectile(Vector2 startingLocation)
        {
            Alive = true;
            width = 16;
            height = 16;

            Location = startingLocation;
            maxLifeSpan = 16;
            lifeSpan = maxLifeSpan;
            sprite = PlayerProjectileSpriteFactory.Instance.CreateBombExplosionSprite();
        }

        public void Update()
        {
            if (lifeSpan == 0)
                Die();
            else if (lifeSpan == (int)(maxLifeSpan / 2.0))
                sprite.Update();
            else if (lifeSpan == (int)(maxLifeSpan / 4.0))
                sprite.Update();
            lifeSpan--;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);
        public void Die() => Alive = false;
    }
}
