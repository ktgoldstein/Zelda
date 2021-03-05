using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Bomb : IItem
    {
        private ISprite bomb;
        private Vector2 location;
        private int height;
        private int width;
        private readonly LegendOfZeldaDungeon game;
        public bool Alive { get; set; }

        public Bomb(Vector2 location)
        {
            bomb = ItemSpriteFactory.Instance.CreateBomb();
            this.location = location;
            this.width = 8;
            this.height = 14;
            Alive = true;
        }
        public void Update() {}
        public void Draw(SpriteBatch spriteBatch)
        {
            bomb.Draw(spriteBatch, location);
        }
    }
}
