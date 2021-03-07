using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Sword : IItem
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite sword;
        private readonly int height;
        private readonly int width;

        public Sword(Vector2 location)
        {
            sword = ItemSpriteFactory.Instance.CreateSword();
            Location = location;
            width = 7;
            height = 16;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => sword.Draw(spriteBatch, Location);
    }
}
