using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Collisions
{
    class EnemyProjectileCollisionHandler : ICollisionHandler
    {
        public static EnemyProjectileCollisionHandler Instance { get; } = new EnemyProjectileCollisionHandler();

        private EnemyProjectileCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player)
        {
            //player should take damage and projectile should disappear
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile)
        {
            //nothing will happen?
        }
        public void HandleEnemyCollision(IEnemy enemy)
        {
            //only applies to boomerangs which should disappear 
        }
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile)
        {
            //nothing will happen (I think)
        }
        public void HandleItemCollision(IItem item)
        {
            //nothing will happen
        }

        public void HandleBlockCollision(ISprite block) //tentative; IBlock interface?
        {
            //not sure yet if projectiles can go through blocks
        }
        public void HandleBoundaryCollision()
        {
            //should disappear on impact
        }
    }
}
