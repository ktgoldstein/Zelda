using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class TriForcePiece : IItem
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

        private ISprite triforcePiece;
        private readonly int height;
        private readonly int width;
        private int animationSpeed;

        public TriForcePiece(Vector2 location)
        {
            triforcePiece = ItemSpriteFactory.Instance.CreateTriforcePiece();
            Location = location;
            width = 10;
            height = 10;
            Alive = true;
            animationSpeed = 0;
        }

        public void Update()
        {
            animationSpeed++;
            if (animationSpeed % 2 == 0)
                triforcePiece.Update();
        }
        public void Draw(SpriteBatch spriteBatch) => triforcePiece.Draw(spriteBatch, Location);
    }
}
