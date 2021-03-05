using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Collisions
{
    class ItemCollisionHandler : ICollisionHandler
    {
        public static ItemCollisionHandler Instance { get; } = new ItemCollisionHandler();

        private ItemCollisionHandler() { }

        public IItem CurrItem { get; set; }

        public void HandlePlayerCollision(IPlayer player)
        {
            //item should be added to player inventory (done in player collision?)
            CurrItem.Alive = false;
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile)
        {
            //item should be added to player inventory (done in player collision?)
            CurrItem.Alive = false;
        }
        public void HandleEnemyCollision(IEnemy enemy)
        {
            CurrItem.Alive = false;
        }
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile)
        {
            //nothing will happen
        }
        public void HandleItemCollision(IItem item)
        {
            //nothing will happen (they can overlap)
        }

        public void HandleBlockCollision(IObject block)
        {
            //nothing will happen (fairies fly over blocks like keese do)
        }
        public void HandleBoundaryCollision()
        {
            //fairy should bounce off boundary (only item that moves)
        }
    }
}
