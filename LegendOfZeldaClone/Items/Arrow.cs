using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Arrow : IItem
    {
        private ISprite arrow;
        private Vector2 location;
        private int height;
        private int width;
        private readonly LegendOfZeldaDungeon game;
        public bool Alive { get; set; }

        public Arrow(Vector2 location)
        {
            arrow = ItemSpriteFactory.Instance.CreateArrow();
            this.height = 16;
            this.width = 5;
            this.location = location;
            Alive = true;
        }

        public void Update() {}

        public void Draw(SpriteBatch spriteBatch)
        {
            arrow.Draw(spriteBatch, location);
        }
    }
}
