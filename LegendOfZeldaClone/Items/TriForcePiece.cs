using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class TriForcePiece : IItem
    {
        private ISprite triforcePiece;
        private Vector2 location;
        private int height;
        private int width;

        public TriForcePiece(Vector2 location)
        {
            triforcePiece = ItemSpriteFactory.Instance.CreateTriforcePiece();
            this.location = location;
            this.width = 12;
            this.height = 12;
        }
        public void Update()
        {
            triforcePiece.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            triforcePiece.Draw(spriteBatch, location);
        }
    }
}
