using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public interface IDoor : IObject
    {
        public Vector2 SpawnLocation { get; }
        public void ChangeRoom() { }
    }
}