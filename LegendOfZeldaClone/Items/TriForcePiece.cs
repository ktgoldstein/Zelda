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
        private readonly LegendOfZeldaDungeon game;
        public bool Alive { get; set; }

        public TriForcePiece(Vector2 location)
        {
            triforcePiece = ItemSpriteFactory.Instance.CreateTriforcePiece();
            this.location = location;
            this.width = 10;
            this.height = 10;
            Alive = true;
        }
        public void Update()
        {
            if ((location - game.Link.Location).Length() < 5)
            {
                Alive = false;
            }
            triforcePiece.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            triforcePiece.Draw(spriteBatch, location);
        }
    }
}
