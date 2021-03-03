using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class DottedBlock : IObject
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }

        private ISprite dottedBlock;
        private readonly int height;
        private readonly int width;

        public DottedBlock(Vector2 location)
        {
            dottedBlock = ObjectSpriteFactory.Instance.CreateDottedBlock();
            Location = location;
            height = 16;
            width = 16;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            dottedBlock.Draw(spriteBatch, Location);
        }
    }
}