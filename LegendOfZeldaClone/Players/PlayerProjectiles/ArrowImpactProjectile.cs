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

        private readonly ArrowSkinType skinType;
        private ISprite sprite;
        private int width;
        private int height;
        private int lifeSpan;

        public ArrowImpactProjectile(Vector2 startingLocation, ArrowSkinType skinType)
        {
            Alive = true;

            this.skinType = skinType;
            Location = startingLocation;
            lifeSpan = 3;
            sprite = PlayerProjectileSpriteFactory.Instance.CreateArrowDeathSprite(skinType);
        }

        public void Update()
        {
            if (lifeSpan == 0)
            {
                Alive = false;
            }
            lifeSpan--;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);
    }
}
