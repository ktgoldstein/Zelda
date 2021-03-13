using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using LegendOfZeldaClone.Enemy;

namespace LegendOfZeldaClone.Collisions
{
    class EnemyCollisionHandler : ICollisionHandler
    {
        public IEnemy CurrentEnemy { get; set; }

        public static EnemyCollisionHandler Instance { get; } = new EnemyCollisionHandler();
        private EnemyCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            //nothing will happen
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            //enemy should take damage depending on the projectile
            Vector2 projectileDirection = CurrentEnemy.Location - playerProjectile.Location;
            projectileDirection.Normalize();
            if( !CurrentEnemy.Invincible)
            {
                CurrentEnemy.Invincible = true;
                if( !( CurrentEnemy is BladeTrap ))
                {
                    CurrentEnemy.Health -= 1;
                    if( CurrentEnemy.Health <= 0)
                    {
                        CurrentEnemy.Alive = false;
                    }
                }
                CurrentEnemy.Knockback(projectileDirection);
            }
        }
        public void HandleEnemyCollision(IEnemy enemy, Direction direction)
        {
            //nothing will happen (they can walk through each other)
        }
        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction)
        {
            //projectile should disappear (assuming this is the enemy that threw it otherwise nothing will happen)
            if( enemyProjectile is EnemyBoomerang && ((EnemyBoomerang) enemyProjectile).goriya == CurrentEnemy)
            {
                enemyProjectile.Alive = false;
                ((Goriya) CurrentEnemy).HasBoomerang = false;
            }
        }
        public void HandleItemCollision(IItem item, Direction direction)
        {
            //nothing will happen
        }

        public void HandleObjectCollision(IObject block, Direction direction)
        {
            //they should stop and have to move around it (except keese if the object is not impassable)
            if (CurrentEnemy is Keese && block.BlockHeight != ObjectHeight.Impassable) return;
            CurrentEnemy.Direction = -LoZHelpers.DirectionToVector(direction);
            Rectangle enemyRectangle = new Rectangle((int) CurrentEnemy.Location.X, (int) CurrentEnemy.Location.Y, CurrentEnemy.Width, CurrentEnemy.Height);
            Rectangle blockRectangle = new Rectangle((int) block.Location.X, (int) block.Location.Y, block.Width, block.Height);
            Rectangle overlap = Rectangle.Intersect(enemyRectangle, blockRectangle);
            Vector2 vector = -LoZHelpers.DirectionToVector(direction);
            if( vector.X == 0)
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
