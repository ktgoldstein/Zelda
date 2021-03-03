using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class FullHealthHeart : IItem
    {
        private ISprite fullHealthHeart;
        private Vector2 location;

        public FullHealthHeart(Vector2 location)
        {
            fullHealthHeart = ItemSpriteFactory.Instance.CreateFullHealthHeart();
            this.location = location;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            fullHealthHeart.Draw(spriteBatch, location);
        }
    }
}
