using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class LockedDoor : BlockKernel
    {
        public Direction Orientation { get; }

        public LockedDoor(Vector2 location, ISprite sprite, int height, int width, ObjectHeight objectHeight, Direction orientation)
            : base(location, sprite, height, width, objectHeight, false, true)
        {
            Orientation = orientation;
        }
    }
}
