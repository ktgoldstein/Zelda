using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class DarkBlock : IObject
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }

        private ISprite darkBlock;
        private readonly int height;
        private readonly int width;

        public DarkBlock(Vector2 location)
        {
            darkBlock = ObjectSpriteFactory.Instance.CreateDarkBlock();
            Location = location;
            height = 16;
            width = 16;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            darkBlock.Draw(spriteBatch, Location);
        }
    }
}