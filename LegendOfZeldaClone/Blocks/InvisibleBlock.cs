using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class InvisibleBlock : BlockKernel
    {
        public InvisibleBlock(Vector2 location, ISprite sprite, int height, int width, ObjectHeight objectHeight, bool isBorder, Direction direction) 
            : base(location, sprite, height, width, objectHeight, false, isBorder)        
        {
            DirectionBasedSetUp(direction);
        }

        private void DirectionBasedSetUp(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    width += 8;
                    Location -= new Vector2(LoZHelpers.Scale(8), 0);
                    break;
                case Direction.Right:
                    width += 8;
                    break;
                case Direction.None:
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch) { }
    }
}
