using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Bow : IItem
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite bow;
        private readonly int height;
        private readonly int width;

        public Bow(Vector2 location)
        {
            bow = ItemSpriteFactory.Instance.CreateBow();
            Location = location;
            width = 8;
            height = 16;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => bow.Draw(spriteBatch, Location);
    }
}
