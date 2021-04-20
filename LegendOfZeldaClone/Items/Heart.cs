using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Heart : IItem
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

        private ISprite heart;
        private readonly int height;
        private readonly int width;
        private int lifespan;
        private int animationSpeed;

        public Heart(Vector2 location, int lifespan = -1)
        {
            heart = ItemSpriteFactory.Instance.CreateHeart();
            Location = location;
            width = 7;
            height = 8;
            Alive = true;
            this.lifespan = lifespan;
            animationSpeed = 0;
        }

        public void Update()
        {
            if (lifespan > 0 && Alive)
            {
                lifespan--;
                if (lifespan == 0)
                {
                    Alive = false;
                }
            }
            animationSpeed++;
            if (animationSpeed % 2 == 0)
                heart.Update();
        }
        public void Draw(SpriteBatch spriteBatch) => heart.Draw(spriteBatch, Location);
        public void Die()
        {
            Alive = false;
            new HeartPickupSoundEffect().Play();
        }
    }
}
