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

        public GoldRupee(Vector2 location)
        {
            goldRupee = ItemSpriteFactory.Instance.CreateGoldRupee();
            Location = location;
            width = 8;
            height = 16;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => goldRupee.Draw(spriteBatch, Location);
        public void BeCollected()
        {
            Alive = false;
            new RupeePickupSoundEffect().Play();
        }
    }
}
