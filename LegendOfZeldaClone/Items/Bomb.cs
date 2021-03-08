using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Bomb : IItem
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation { get { return Location; } }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite bomb;
        private readonly int height;
        private readonly int width;

        public Bomb(Vector2 location)
        {
            bomb = ItemSpriteFactory.Instance.CreateBomb();
            Location = location;
            width = 8;
            height = 14;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => bomb.Draw(spriteBatch, Location);
    }
}
