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

        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile)
        {

        }
        public void HandleEnemyCollision(IEnemy enemy)
        {

        }
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile)
        {

        }
        public void HandleItemCollision(IItem item)
        {

        }

        public void HandleBlockCollision(ISprite block) //tentative; IBlock interface?
        {

        }
        public void HandleBoundaryCollision()
        {

        }
    }
}
