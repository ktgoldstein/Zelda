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
            //make item disappear upon collision (and add to player inventory)
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile)
        {
            //make item disappear upon collision (and add to player inventory)
        }
        public void HandleEnemyCollision(IEnemy enemy)
        {
            //only bombs or weapons will cause damage (do boomerangs cause damage?)
        }
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile)
        {
            //nothing will happen
        }
        public void HandleItemCollision(IItem item)
        {
            //nothing will happen (they can overlap)
        }

        public void HandleBlockCollision(ISprite block) //tentative; IBlock interface?
        {
            //nothing will happen (handled in player projectile collision with block)
        }
        public void HandleBoundaryCollision()
        {
            //fairy should bounce off boundary (only item that moves)
        }
    }
}
