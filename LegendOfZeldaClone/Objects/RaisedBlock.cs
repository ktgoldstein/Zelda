using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class RaisedBlock: IObject
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }

        private ISprite raisedBlock;
        private readonly int height;
        private readonly int width;

        public RaisedBlock(Vector2 location)
        {
            raisedBlock = ObjectSpriteFactory.Instance.CreateRaisedBlock();
            Location = location;
            height = 16;
            width = 16;
        }
        public void Update() { }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            raisedBlock.Draw(spriteBatch, Location);
        }
    }
}
