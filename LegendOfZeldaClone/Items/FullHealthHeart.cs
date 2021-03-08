using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class FullHealthHeart : IItem
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

        private ISprite fullHealthHeart;
        private readonly int width;
        private readonly int height;

        public FullHealthHeart(Vector2 location)
        {
            fullHealthHeart = ItemSpriteFactory.Instance.CreateFullHealthHeart();
            Location = location;
            width = 7;
            height = 8;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => fullHealthHeart.Draw(spriteBatch, Location);
    }
}
