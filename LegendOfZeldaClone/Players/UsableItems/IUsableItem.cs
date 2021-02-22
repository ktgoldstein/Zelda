using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public interface IUsableItem
    {
        public void Use(Vector2 location, Direction direction);
    }
}
