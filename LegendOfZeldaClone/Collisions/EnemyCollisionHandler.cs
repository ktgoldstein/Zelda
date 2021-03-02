using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Collisions
{
    class EnemyCollisionHandler : ICollisionHandler
    {
        public static EnemyCollisionHandler Instance { get; } = new EnemyCollisionHandler();

        private EnemyCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player)
        {
            //player should take damage and move backward
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile)
        {
            //enemy should take damage (unsure if this includes boomerangs)
        }
        public void HandleEnemyCollision(IEnemy enemy)
        {
            //nothing will happen (they can walk through each other)
        }
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile)
        {
            //projectile should disappear (assuming this is the enemy that threw it otherwise nothing will happen)
        }
        public void HandleItemCollision(IItem item)
        {
            //nothing will happen
        }

        public void HandleBlockCollision(IObject block)
        {
            //they should stop and have to move around it
        }
        public void HandleBoundaryCollision()
        {
            //all enemies except wallmaster are stopped
            //wallmaster spawns from the boundary and phases through the outer walls
        }
    }
}
