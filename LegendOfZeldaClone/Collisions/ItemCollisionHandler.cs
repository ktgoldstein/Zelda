﻿namespace LegendOfZeldaClone.Collisions
{
    class ItemCollisionHandler : ICollisionHandler
    {
        public static ItemCollisionHandler Instance { get; } = new ItemCollisionHandler();

        private ItemCollisionHandler() { }

        public IItem CurrItem { get; set; }

        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            CurrItem.Alive = false;
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            //only rupees, clocks, or bombs. Everything else does nothing
            CurrItem.Alive = false;
        }
        public void HandleEnemyCollision(IEnemy enemy, Direction direction)
        {
            CurrItem.Alive = false;
        }
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile, Direction direction)
        {
            //nothing will happen
        }
        public void HandleItemCollision(IItem item, Direction direction)
        {
            //nothing will happen (they can overlap)
        }

        public void HandleObjectCollision(IObject block, Direction direction)
        {
            //nothing will happen (fairies fly over blocks like keese do)
        }
        public void HandleBoundaryCollision(Boundary boundary, Direction direction)
        {
            //fairy should bounce off boundary (only item that moves)
        }
    }
}
