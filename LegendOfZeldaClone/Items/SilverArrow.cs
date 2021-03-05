using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class SilverArrow : IItem
    {
        private ISprite silverArrow;
        private Vector2 location;
        private int height;
        private int width;
        private readonly LegendOfZeldaDungeon game;
        public bool Alive { get; set; }

        public SilverArrow(Vector2 location)
        {
            silverArrow = ItemSpriteFactory.Instance.CreateSilverArrow();
            this.location = location;
            this.width = 5;
            this.height = 16;
            Alive = true;
        }
        public void Update() {}
        public void Draw(SpriteBatch spriteBatch)
        {
            silverArrow.Draw(spriteBatch, location);
        }
    }
}
