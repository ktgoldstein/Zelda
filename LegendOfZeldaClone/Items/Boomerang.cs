using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Boomerang : IItem
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

        private ISprite boomerang;
        private readonly int height;
        private readonly int width;

        public Boomerang(Vector2 location)
        {
            boomerang = ItemSpriteFactory.Instance.CreateBoomerang();
            Location = location;
            width = 5;
            height = 8;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => boomerang.Draw(spriteBatch, Location);
        public void BeCollected()
        {
            Die();
            new InventoryItemPickupSoundEffect().Play();
            new NewImportantItemAcquiredFanfareSoundEffect().Play();
        }
        public void Die() => Alive = false;
    }
}
