using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class NoHealthHeart : IItem
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

        private ISprite noHealthHeart;
        private readonly int width;
        private readonly int height;

        public NoHealthHeart(Vector2 location)
        {
            noHealthHeart = ItemSpriteFactory.Instance.CreateNoHealthHeart();
            Location = location;
            width = 7;
            height = 8;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => noHealthHeart.Draw(spriteBatch, Location);
        public void BeCollected() { }
        public void Die() { }
    }
}
