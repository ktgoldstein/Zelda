using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class HalfHealthHeart : IItem
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

        private ISprite halfHealthHeart;
        private readonly int width;
        private readonly int height;

        public HalfHealthHeart(Vector2 location)
        {
            halfHealthHeart = ItemSpriteFactory.Instance.CreateHalfHealthHeart();
            Location = location;
            width = 7;
            height = 8;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => halfHealthHeart.Draw(spriteBatch, Location);
        public void BeCollected() { }
    }
}
