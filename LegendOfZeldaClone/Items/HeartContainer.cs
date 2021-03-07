using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class HeartContainer : IItem
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite heartContainer;
        private readonly int height;
        private readonly int width;

        public HeartContainer(Vector2 location)
        {
            heartContainer = ItemSpriteFactory.Instance.CreateHeartContainer();
            Location = location;
            width = 13;
            height = 13;
            Alive = true;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) => heartContainer.Draw(spriteBatch, Location);
    }
}
