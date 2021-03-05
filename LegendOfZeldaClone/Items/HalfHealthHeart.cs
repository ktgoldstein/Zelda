using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class HalfHealthHeart : IItem
    {
        private ISprite halfHealthHeart;
        private Vector2 location;
        public bool Alive { get; set; }

        public HalfHealthHeart(Vector2 location)
        {
            halfHealthHeart = ItemSpriteFactory.Instance.CreateHalfHealthHeart();
            this.location = location;
            Alive = true;
        }
        public void Update() {}
        public void Draw(SpriteBatch spriteBatch)
        {
            halfHealthHeart.Draw(spriteBatch, location);
        }
    }
}
