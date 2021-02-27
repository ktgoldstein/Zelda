using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Compass : IItem
    {
        private ISprite compass;
        private Vector2 location;
        private int height;
        private int width;

        public Compass(Vector2 location)
        {
            compass = ItemSpriteFactory.Instance.CreateCompass();
            this.location = location;
            this.width = 12;
            this.height = 12;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            compass.Draw(spriteBatch, location);
        }
    }
}
