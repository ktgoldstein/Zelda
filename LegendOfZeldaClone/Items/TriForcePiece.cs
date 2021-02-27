using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class TriForcePiece : IItem
    {
        private ISprite triforcePiece;
        private Vector2 location;

        public TriForcePiece(Vector2 location)
        {
            triforcePiece = ItemSpriteFactory.Instance.CreateTriforcePiece();
            this.location = location;
        }
    }
}
