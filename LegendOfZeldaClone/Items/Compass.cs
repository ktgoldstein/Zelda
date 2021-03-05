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
        private readonly LegendOfZeldaDungeon game;
        public bool Alive { get; set; }

        public Compass(Vector2 location)
        {
            compass = ItemSpriteFactory.Instance.CreateCompass();
            this.location = location;
            this.width = 11;
            this.height = 12;
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
            compass.Draw(spriteBatch, location);
        }
    }
}
