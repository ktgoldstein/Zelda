using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public abstract class DoorKernel : BlockKernel
    {
        public DoorKernel(Vector2 location, ISprite sprite, int height, int width)
            : base(location, sprite, height, width, ObjectHeight.Impassable, false, true) { }

        public abstract void ChangeRoom();
    }
}
