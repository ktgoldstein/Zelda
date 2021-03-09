using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public interface IEnemy : IGameObject
    {
        public int AttackStat { get; }
        public int Health { get; set; }
        public Vector2 Direction { get; set; }
        public bool Invincible { get; set; }
        public bool Alive { get; set; }
        public void Knockback(Vector2 direction);
    }
}
