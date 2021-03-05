using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Bow : IItem
    {
        private ISprite bow;
        private Vector2 location;
        private int height;
        private int width;
        private readonly LegendOfZeldaDungeon game;
        public bool Alive { get; set; }

        public Bow(Vector2 location)
        {
            bow = ItemSpriteFactory.Instance.CreateBow();
            this.location = location;
            this.width = 8;
            this.height = 16;
            Alive = true;
        }
        public void Update() {}
        public void Draw(SpriteBatch spriteBatch)
        {
            bow.Draw(spriteBatch, location);
        }
    }
}
