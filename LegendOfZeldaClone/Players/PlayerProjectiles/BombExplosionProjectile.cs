using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class BombExplosionProjectile : IPlayerProjectile
    {
        public bool Alive { get; set; }

        private readonly ISprite sprite;
        private readonly Vector2 location;
        private readonly int maxLifeSpan;
        private int lifeSpan;

        public BombExplosionProjectile(Vector2 startingLocation)
        {
            Alive = true;

            location = startingLocation;
            maxLifeSpan = 16;
            lifeSpan = maxLifeSpan;
            sprite = PlayerProjectileSpriteFactory.Instance.CreateBombExplosionSprite();
        }

        public void Update()
        {
            if (lifeSpan == 0)
                Alive = false;
            else if (lifeSpan == (int)(maxLifeSpan / 2.0))
                sprite.Update();
            else if (lifeSpan == (int)(maxLifeSpan / 4.0))
                sprite.Update();
            lifeSpan--;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, location);
    }
}
