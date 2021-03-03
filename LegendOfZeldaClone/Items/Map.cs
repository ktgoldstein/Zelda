using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Map : IItem
    {
        private ISprite map;
        private Vector2 location;
        private int height;
        private int width;

        public Map(Vector2 location)
        {
            map = ItemSpriteFactory.Instance.CreateMap();
            this.location = location;
            this.width = 12;
            this.height = 16;
        }
        public void Update()
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch, location);
        }
    }
}
