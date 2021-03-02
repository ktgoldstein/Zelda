using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Collisions
{
    class ItemCollisionHandler : ICollisionHandler
    {
        public static ItemCollisionHandler Instance { get; } = new ItemCollisionHandler();

        private ItemCollisionHandler() { }

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
