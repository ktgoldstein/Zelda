using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Collisions
{
    class EnemyProjectileCollisionHandler : ICollisionHandler
    {
        public static EnemyProjectileCollisionHandler Instance { get; } = new EnemyProjectileCollisionHandler();

        private EnemyProjectileCollisionHandler() { }

        public IEnemyProjectile CurrEnemyProjectile { get; set; }

        public void HandlePlayerCollision(IPlayer player)
        {
            CurrEnemyProjectile.Alive = false;
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile)
        {
            //nothing will happen
        }
        public void HandleEnemyCollision(IEnemy enemy)
        {
            CurrEnemyProjectile.Alive = false;
        }
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile)
        {
            //nothing will happen
        }
        public void HandleItemCollision(IItem item)
        {
            //nothing will happen
        }

        public void HandleBlockCollision(IObject block)
        {
            //nothing will happen (enemy projectiles go through blocks)
        }
        public void HandleBoundaryCollision()
        {
            CurrEnemyProjectile.Alive = false;
        }
    }
}
