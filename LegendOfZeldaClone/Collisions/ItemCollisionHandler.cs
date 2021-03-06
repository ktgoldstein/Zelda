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
            CurrItem.Alive = false;
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile)
        {
            //only rupees, clocks, or bombs. Everything else does nothing
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
