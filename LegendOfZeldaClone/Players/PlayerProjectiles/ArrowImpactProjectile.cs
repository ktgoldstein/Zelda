using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    class ArrowImpactProjectile : IPlayerProjectile
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
        private int lifeSpan;

        public ArrowImpactProjectile(Vector2 startingLocation)
        {
            Alive = true;
            sprite = PlayerProjectileSpriteFactory.Instance.CreateArrowDeathSprite();
            width = 8;
            height = 8;
            Location = startingLocation;
            lifeSpan = 3;
        }

        public void Update()
        {
            if (lifeSpan == 0)
                Die();
            lifeSpan--;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);
        public void Die() => Alive = false;
    }
}
