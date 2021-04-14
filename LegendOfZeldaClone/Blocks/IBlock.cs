namespace LegendOfZeldaClone
{
    public interface IBlock : IGameObject
    {
        public ObjectHeight BlockHeight { get; }
        public bool IsBombable { get; }
        public bool IsBorder { get; }
    }
}
