using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Compass : IItem
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

        private ISprite compass;
        private readonly int height;
        private readonly int width;

        public Compass(Vector2 location)
        {
            compass = ItemSpriteFactory.Instance.CreateCompass();
            Location = location;
            width = 11;
            height = 12;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => compass.Draw(spriteBatch, Location);
        public void Die()
        {
            Alive = false;
            new InventoryItemPickupSoundEffect().Play();
        }
        public void BuyItem() { }
    }
}
