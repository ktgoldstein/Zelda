using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class NoHealthHeart : IItem
    {
        private ISprite noHealthHeart;
        private Vector2 location;
        public bool Alive { get; set; }

        public NoHealthHeart(Vector2 location)
        {
            noHealthHeart = ItemSpriteFactory.Instance.CreateNoHealthHeart();
            this.location = location;
            Alive = true;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            noHealthHeart.Draw(spriteBatch, location);
        }
    }
}
