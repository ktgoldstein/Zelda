using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class MagicalKey : IItem
    {
        private ISprite magicKey;
        private Vector2 location;
        private int height;
        private int width;

        public MagicalKey(Vector2 location)
        {
            magicKey = ItemSpriteFactory.Instance.CreateMagicalKey();
            this.location = location;
            this.width = 8;
            this.height = 16;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            magicKey.Draw(spriteBatch, location);
        }
    }
}
