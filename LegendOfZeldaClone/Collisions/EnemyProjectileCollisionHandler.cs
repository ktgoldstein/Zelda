using LegendOfZeldaClone.Enemy;

namespace LegendOfZeldaClone.Collisions
{
    class EnemyProjectileCollisionHandler : ICollisionHandler
    {
        public IEnemyProjectile CurrentEnemyProjectile { get; set; }

        public static EnemyProjectileCollisionHandler Instance { get; } = new EnemyProjectileCollisionHandler();
        private EnemyProjectileCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            if (CurrentEnemyProjectile is Enemy.EnemyBoomerang)
                ((EnemyBoomerang) CurrentEnemyProjectile).ComeBack();
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction) {}
        public void HandleEnemyCollision(IEnemy enemy, Direction direction)
        {
            if (CurrentEnemyProjectile is Enemy.EnemyBoomerang)
            {
                Enemy.EnemyBoomerang boomerang = CurrentEnemyProjectile as Enemy.EnemyBoomerang;
                if (enemy is Enemy.Goriya && enemy == boomerang.goriya)
                {
                    CurrentEnemyProjectile.Die();
                    Enemy.Goriya goriya = boomerang.goriya as Enemy.Goriya;
                    goriya.HasBoomerang = false;
                }
            }
        }
        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction) {}
        public void HandleItemCollision(IItem item, Direction direction) {}

        public void HandleObjectCollision(IObject block, Direction direction)
        {
            if (block.BlockHeight == ObjectHeight.Impassable)
            {
                if (CurrentEnemyProjectile is EnemyBoomerang)
                    ((EnemyBoomerang) CurrentEnemyProjectile).ComeBack();
                else
                    CurrentEnemyProjectile.Die();
            }
        }
    }
}
