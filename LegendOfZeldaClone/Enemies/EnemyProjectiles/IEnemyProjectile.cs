namespace LegendOfZeldaClone
{
    public interface IEnemyProjectile : IGameObject
    {
        public int AttackStat { get; }
        public bool Alive { get; set; }
    }
}
