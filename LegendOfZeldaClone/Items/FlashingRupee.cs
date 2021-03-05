using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class FlashingRupee: IItem
    {
        private ISprite rupee;
        private Vector2 location;
        private int height;
        private int width;
        private readonly LegendOfZeldaDungeon game;
        public bool Alive { get; set; }

        public FlashingRupee(Vector2 location)
        {
            rupee = ItemSpriteFactory.Instance.CreateFlashingRupee();
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
            rupee.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            rupee.Draw(spriteBatch, location);
        }
    }
}
