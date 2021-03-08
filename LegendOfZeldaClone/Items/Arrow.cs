using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Arrow : IItem
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation { get { return Location; } }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite arrow;
        private readonly int height;
        private readonly int width;

        public Arrow(Vector2 location)
        {
            arrow = ItemSpriteFactory.Instance.CreateArrow();
            height = 16;
            width = 5;
            Location = location;
            Alive = true;
        }

        public void Update() {}
        public void Draw(SpriteBatch spriteBatch) => arrow.Draw(spriteBatch, Location);
    }
}
