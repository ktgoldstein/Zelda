using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class BlueRupee : IItem
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

        private ISprite blueRupee;
        private readonly int height;
        private readonly int width;
        private int lifespan;

        public BlueRupee(Vector2 location, int lifespan = -1)
        {
            blueRupee = ItemSpriteFactory.Instance.CreateBlueRupee();
            Location = location;
            width = 8;
            height = 16;
            Alive = true;
            this.lifespan = lifespan;
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
        }
        public void Draw(SpriteBatch spriteBatch) => blueRupee.Draw(spriteBatch, Location);
        public void Die()
        {
            Alive = false;
            new RupeePickupSoundEffect().Play();
        }
    }
}
