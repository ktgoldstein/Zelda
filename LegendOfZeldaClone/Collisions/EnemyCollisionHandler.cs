using Microsoft.Xna.Framework;
using LegendOfZeldaClone.Enemy;
using LegendOfZeldaClone.Objects;
using System;
using LegendOfZeldaClone.Players.LinkPlayer.LinkStates;

namespace LegendOfZeldaClone.Collisions
{
    class EnemyCollisionHandler : ICollisionHandler
    {
        public IEnemy CurrentEnemy { get; set; }
        public static EnemyCollisionHandler Instance { get; } = new EnemyCollisionHandler();
        private EnemyCollisionHandler() { }
        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            if (CurrentEnemy is Wallmaster)
                (CurrentEnemy as Wallmaster).game.GoToTheStart();

            if( player is LinkPlayer && ((LinkPlayer)player).linkState is LinkSpin)
            {
                Vector2 hitDirection = CurrentEnemy.Location - player.Location;
                hitDirection.Normalize();
                CurrentEnemy.TakeDamage(hitDirection);
            }
        }
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
            if (block.BlockHeight == ObjectHeight.CanWalkOver) return;

            //they should stop and have to move around it (except keese if the object is not impassable)
            if(CurrentEnemy is Wallmaster && (block is WallDown || block is WallUp || block is WallLeft || block is WallRight || (block.GetType().ToString().Contains("Door")) ))
            {
                return;
            }
            if (!(CurrentEnemy is Wallmaster && block is Objects.InvisibleBlock))
            {
                if (CurrentEnemy is Keese && block.BlockHeight != ObjectHeight.Impassable) return;
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
                if ( !( CurrentEnemy is Aquamentus) && !( CurrentEnemy is BladeTrap ) && !(block is WallDown) && !(block is WallUp) && !(block is WallLeft) && !(block is WallRight))
                {
                    CurrentEnemy.ChangeDirection(direction);
                }
                else
                {
                    CurrentEnemy.Direction = -LoZHelpers.DirectionToVector(direction);
                }
            }
        }
    }
}
