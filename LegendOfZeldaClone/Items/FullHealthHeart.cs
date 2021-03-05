using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class FullHealthHeart : IItem
    {
        private ISprite fullHealthHeart;
        private Vector2 location;
        public bool Alive { get; set; }

        public FullHealthHeart(Vector2 location)
        {
            fullHealthHeart = ItemSpriteFactory.Instance.CreateFullHealthHeart();
            this.location = location;
            Alive = true;
        }
        public void Update() {}
        public void Draw(SpriteBatch spriteBatch)
        {
            fullHealthHeart.Draw(spriteBatch, location);
        }
    }
}
