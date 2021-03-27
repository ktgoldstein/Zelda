namespace LegendOfZeldaClone
{
    public interface IPlayerProjectile : IGameObject
    {
        public bool Alive { get; set; }
        public void Die();
    }
}
