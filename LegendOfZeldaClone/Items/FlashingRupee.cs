using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class FlashingRupee: IItem
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

        private ISprite rupee;
        private readonly int height;
        private readonly int width;
        private int animationSpeed;
        private int lifespan;

        public FlashingRupee(Vector2 location, int lifespan = -1)
        {
            rupee = ItemSpriteFactory.Instance.CreateFlashingRupee();
            Location = location;
            width = 8;
            height = 16;
            Alive = true;
            animationSpeed = 0;
            this.lifespan = lifespan;
        }

        public void Update()
        {
            animationSpeed++;
            if (animationSpeed % 2 == 0)
                rupee.Update();
            if (lifespan > 0 && Alive)
            {
                lifespan--;
                if (lifespan == 0)
                {
                    Alive = false;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch) => rupee.Draw(spriteBatch, Location);
        public void Die()
        {
            Alive = false;
            new RupeePickupSoundEffect().Play();
        }
    }
}
