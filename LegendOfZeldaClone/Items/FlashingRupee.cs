using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class FlashingRupee: IItem
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite rupee;
        private readonly int height;
        private readonly int width;

        public FlashingRupee(Vector2 location)
        {
            rupee = ItemSpriteFactory.Instance.CreateFlashingRupee();
            Location = location;
            width = 8;
            height = 16;
            Alive = true;
        }

        public void Update() => rupee.Update();
        public void Draw(SpriteBatch spriteBatch) => rupee.Draw(spriteBatch, Location);
    }
}
