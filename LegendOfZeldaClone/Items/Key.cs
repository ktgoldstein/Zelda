using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Key : IItem
    {
        private ISprite key;
        private Vector2 location;
        private int height;
        private int width;
        private readonly LegendOfZeldaDungeon game;
        public bool Alive { get; set; }

        public Key(Vector2 location)
        {
            key = ItemSpriteFactory.Instance.CreateKey();
            this.location = location;
            this.width = 8;
            this.height = 16;
            Alive = true;
        }
        public void Update()
        {
            if ((location - game.Link.Location).Length() < 5)
            {
                Alive = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            key.Draw(spriteBatch, location);
        }
    }
}
