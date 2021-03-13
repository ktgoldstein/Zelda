using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZeldaClone
{
    public interface ICollisionHandler
    {
        public void HandlePlayerCollision(IPlayer player, Direction direction);
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction);
        public void HandleEnemyCollision(IEnemy enemy, Direction direction);
        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction);
        public void HandleItemCollision(IItem item, Direction direction);
        public void HandleObjectCollision(IObject block, Direction direction);
    }
}

