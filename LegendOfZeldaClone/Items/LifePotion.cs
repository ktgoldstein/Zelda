using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class LifePotion : IItem
    {
        private ISprite lifePotion;
        private Vector2 location;
        private int height;
        private int width;
        private readonly LegendOfZeldaDungeon game;
        public bool Alive { get; set; }

        public LifePotion(Vector2 location)
        {
            lifePotion = ItemSpriteFactory.Instance.CreateLifePotion();
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
            lifePotion.Draw(spriteBatch, location);
        }
    }
}
