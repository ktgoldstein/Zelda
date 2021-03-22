using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public interface IDoor : IObject
    {
        public Vector2 SpawnLocation { get; }
        public Direction DoorDirection { get; }
        public bool ActiveCamera { get; set; }
        public void ChangeRoom() { }
    }
}
