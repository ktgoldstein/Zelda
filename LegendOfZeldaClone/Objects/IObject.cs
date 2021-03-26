namespace LegendOfZeldaClone
{
    public interface IObject : IGameObject
    {
        public ObjectHeight BlockHeight { get; }
        public bool IsMovable { get; }
        public bool IsBombable { get; }
    }
}
