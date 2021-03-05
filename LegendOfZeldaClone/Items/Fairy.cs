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
        private int height;
        private int width;
        private int speed;
        private readonly LegendOfZeldaDungeon game;
        public bool Alive { get; set; }

        public Fairy(Vector2 location)
        {
            fairy = ItemSpriteFactory.Instance.CreateFairy();
            this.location = location;
            this.width = 8;
            this.height = 16;
            this.yDirection = 1;
            this.xDirection = 1;
            this.speed = 2;
            Alive = true;
        }
        public void Update()
        {
            location.Y += speed * yDirection;
            location.X += speed * xDirection;
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
