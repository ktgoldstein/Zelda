using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Map : IItem
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

        private ISprite map;
        private readonly int height;
        private readonly int width;

        public Map(Vector2 location)
        {
            map = ItemSpriteFactory.Instance.CreateMap();
            Location = location;
            width = 8;
            height = 16;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => map.Draw(spriteBatch, Location);
        public void Die()
        {
            Alive = false;
            new InventoryItemPickupSoundEffect().Play();
        }
    }
}
