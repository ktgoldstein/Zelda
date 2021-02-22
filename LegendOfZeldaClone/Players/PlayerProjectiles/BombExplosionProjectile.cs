using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class BombExplosionProjectile : IPlayerProjectile
    {
        private readonly ISprite sprite;
        private readonly Vector2 location;
        private readonly int maxLifeSpan;
        private int lifeSpan;

        public BombExplosionProjectile(Vector2 startingLocation)
        {
            location = startingLocation;
            maxLifeSpan = 16;
            lifeSpan = maxLifeSpan;
            sprite = PlayerProjectileSpriteFactory.Instance.CreateBombExplosionSprite();
        }

        public bool Update()
        {
            if (lifeSpan == 0)
                return true;
            else if (lifeSpan == (int)(maxLifeSpan / 2.0))
                sprite.Update();
            else if (lifeSpan == (int)(maxLifeSpan / 4.0))
                sprite.Update();
            lifeSpan--;
            return false;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, location);
    }
}
