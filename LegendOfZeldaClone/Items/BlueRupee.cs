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

        public BlueRupee(Vector2 location)
        {
            blueRupee = ItemSpriteFactory.Instance.CreateBlueRupee();
            Location = location;
            width = 8;
            height = 16;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => blueRupee.Draw(spriteBatch, Location);
        public void BeCollected()
        {
            Die();
            new RupeePickupSoundEffect().Play();
        }
        public void Die() => Alive = false;
    }
}
