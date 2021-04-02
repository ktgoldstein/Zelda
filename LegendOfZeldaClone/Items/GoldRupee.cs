using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class GoldRupee : IItem
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

        private ISprite goldRupee;
        private readonly int height;
        private readonly int width;
        private int lifespan;

        public GoldRupee(Vector2 location, int lifespan = -1)
        {
            goldRupee = ItemSpriteFactory.Instance.CreateGoldRupee();
            Location = location;
            width = 8;
            height = 16;
            Alive = true;
            this.lifespan = lifespan;
        }

        public void Update()
        {
            if( lifespan > 0 && Alive)
            {
                lifespan--;
                if( lifespan == 0 )
                {
                    Alive = false;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch) => goldRupee.Draw(spriteBatch, Location);
    }
}
