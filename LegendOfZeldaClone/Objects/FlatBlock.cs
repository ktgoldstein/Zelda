using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class FlatBlock : IObject
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation { get { return Location; } }

        private ISprite flatBlock;
        private readonly int height;
        private readonly int width;

        public FlatBlock(Vector2 location)
        {
            flatBlock = ObjectSpriteFactory.Instance.CreateFlatBlock();
            Location = location;
            height = 16;
            width = 16;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            flatBlock.Draw(spriteBatch, Location);
        }
    }
}