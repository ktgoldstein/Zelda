using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class NoHealthHeart : IItem
    {
        private ISprite noHealthHeart;
        private Vector2 location;

        public NoHealthHeart(Vector2 location)
        {
            noHealthHeart = ItemSpriteFactory.Instance.CreateNoHealthHeart();
            this.location = location;
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
