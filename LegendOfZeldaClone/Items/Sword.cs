using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Sword : IItem
    {
        private ISprite sword;
        private Vector2 location;
        private int height;
        private int width;
        private readonly LegendOfZeldaDungeon game;
        public bool Alive { get; set; }

        public Sword(Vector2 location)
        {
            sword = ItemSpriteFactory.Instance.CreateSword();
            this.location = location;
            this.width = 7;
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
            sword.Draw(spriteBatch, location);
        }
    }
}
