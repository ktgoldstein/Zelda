using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class HeartContainer : IItem
    {
        private ISprite heartContainer;
        private Vector2 location;
        private int height;
        private int width;
        private readonly LegendOfZeldaDungeon game;
        public bool Alive { get; set; }

        public HeartContainer(Vector2 location)
        {
            heartContainer = ItemSpriteFactory.Instance.CreateHeartContainer();
            this.location = location;
            this.width = 13;
            this.height = 13;
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
            heartContainer.Draw(spriteBatch, location);
        }
    }
}
