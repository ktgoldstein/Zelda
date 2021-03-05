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
        private readonly LegendOfZeldaDungeon game;
        public bool Alive { get; set; }

        public Map(Vector2 location)
        {
            map = ItemSpriteFactory.Instance.CreateMap();
            this.location = location;
            this.width = 8;
            this.height = 16;
            Alive = true;
        }
        public void Update() {}
        public void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch, location);
        }
    }
}
