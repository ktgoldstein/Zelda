using System;
using System.Collections.Generic;
using System.Text;

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
        }
        public void HandleEnemyCollision(IEnemy enemy, Direction direction)
        {
            //nothing will happen (they can walk through each other)
        }
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile, Direction direction)
        {
            //projectile should disappear (assuming this is the enemy that threw it otherwise nothing will happen)
        }
        public void HandleItemCollision(IItem item, Direction direction)
        {
            //nothing will happen
        }

        public void HandleObjectCollision(IObject block, Direction direction)
        {
            //they should stop and have to move around it (except keese)
        }
        public void HandleBoundaryCollision(Boundary boundary, Direction direction)
        {
            //all enemies except wallmaster are stopped
            //wallmaster spawns from the boundary and phases through the outer walls
        }
    }
}
