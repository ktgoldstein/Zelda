using LegendOfZeldaClone.Enemy;
using LegendOfZeldaClone.Players.LinkPlayer.LinkStates;

namespace LegendOfZeldaClone.Collisions
{
    class EnemyProjectileCollisionHandler : ICollisionHandler
    {
        public IEnemyProjectile CurrentEnemyProjectile { get; set; }

        public static EnemyProjectileCollisionHandler Instance { get; } = new EnemyProjectileCollisionHandler();
        private EnemyProjectileCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            if( player is LinkPlayer && ((LinkPlayer)player).linkState is LinkSpin && CurrentEnemyProjectile is Fireball)
            {
               ( CurrentEnemyProjectile as Fireball ).Reflect(CurrentEnemyProjectile.Location - player.Location);
            }
            if (CurrentEnemyProjectile is Enemy.EnemyBoomerang)
                ((EnemyBoomerang) CurrentEnemyProjectile).ComeBack();
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction) {}
        public void HandleEnemyCollision(IEnemy enemy, Direction direction)
        {
            if( CurrentEnemyProjectile is Fireball && ((Fireball)CurrentEnemyProjectile).reflected)
            {
                enemy.TakeDamage(enemy.Location - CurrentEnemyProjectile.Location);
                CurrentEnemyProjectile.Die();
            }
            if (CurrentEnemyProjectile is EnemyBoomerang)
            {
                EnemyBoomerang boomerang = CurrentEnemyProjectile as EnemyBoomerang;
                if (enemy is Goriya && enemy == boomerang.goriya)
                    CurrentEnemyProjectile.Die();
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
