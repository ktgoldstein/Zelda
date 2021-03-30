using Microsoft.Xna.Framework;
using LegendOfZeldaClone.Enemy;

namespace LegendOfZeldaClone.Collisions
{
    class EnemyCollisionHandler : ICollisionHandler
    {
        public IEnemy CurrentEnemy { get; set; }

        public static EnemyCollisionHandler Instance { get; } = new EnemyCollisionHandler();
        private EnemyCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player, Direction direction) { }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            bool projectileDealsEnemyDamage = !(playerProjectile is BombProjectile 
                                                || playerProjectile is ArrowImpactProjectile 
                                                || playerProjectile is SwordBeamExplosionProjectile);
            if (projectileDealsEnemyDamage)
            {
                Vector2 projectileDirection = CurrentEnemy.Location - playerProjectile.Location;
                projectileDirection.Normalize();
                CurrentEnemy.TakeDamage(projectileDirection);
            }
        }
        public void HandleEnemyCollision(IEnemy enemy, Direction direction) { }
        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction)
        {
            if (enemyProjectile is EnemyBoomerang && ((EnemyBoomerang) enemyProjectile).goriya == CurrentEnemy)
                ((Goriya) CurrentEnemy).HasBoomerang = false;
        }
        public void HandleItemCollision(IItem item, Direction direction) { }
        public void HandleObjectCollision(IObject block, Direction direction)
        {
            //they should stop and have to move around it (except keese if the object is not impassable)
            if (!(CurrentEnemy is Wallmaster && block is Objects.InvisibleBlock))
            {
                if (CurrentEnemy is Keese && block.BlockHeight != ObjectHeight.Impassable) return;

                CurrentEnemy.Direction = -LoZHelpers.DirectionToVector(direction);
                Rectangle enemyRectangle = new Rectangle((int)CurrentEnemy.Location.X, (int)CurrentEnemy.Location.Y, CurrentEnemy.Width, CurrentEnemy.Height);
                Rectangle blockRectangle = new Rectangle((int)block.Location.X, (int)block.Location.Y, block.Width, block.Height);
                Rectangle overlap = Rectangle.Intersect(enemyRectangle, blockRectangle);
                Vector2 vector = -LoZHelpers.DirectionToVector(direction);
                if (vector.X == 0)
                {
                    CurrentEnemy.Location += vector * overlap.Height;
                }
                else
                {
                    CurrentEnemy.Location += vector * overlap.Width;
                }
            }
        }
    }
}
