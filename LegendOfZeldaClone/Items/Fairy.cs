using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Fairy : IItem
    {
        private ISprite fairy;
        private Vector2 location;
        private int yDirection;
        private int xDirection;
        private int speed;

        public Fairy(Vector2 location)
        {
            fairy = ItemSpriteFactory.Instance.CreateFairy();
            this.location = location;
            this.yDirection = 1;
            this.xDirection = 1;
            this.speed = 2;
        }
        public void Update()
        {
            location.Y += 2 * yDirection;
            location.X += 2 * xDirection;
            if (location.Y > (LoZHelpers.GameHeight / 2 + 30))
            {
                yDirection = -1;
            }
            if (location.Y < (LoZHelpers.GameHeight / 2 - 30))
            {
                yDirection = 1;
            }
            if (location.X > (LoZHelpers.GameWidth / 2 + 50))
            {
                xDirection = -1;
            }
            if (location.X < (LoZHelpers.GameWidth / 2 - 50))
            {
                xDirection = 1;
            }

            fairy.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            fairy.Draw(spriteBatch, location);
        }
    }
}
