using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class BombableWall : BlockKernel 
    {
        public Direction Orientation { get; }

        public BombableWall(Vector2 location, ISprite sprite, int height, int width, ObjectHeight objectHeight, Direction orientation) 
            : base(location, sprite, height, width, objectHeight, true, true)
        {
            Orientation = orientation;
        }
    }
}