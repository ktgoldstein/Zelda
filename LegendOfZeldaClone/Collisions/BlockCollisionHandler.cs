using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Collisions
{
    class BlockCollisionHandler : ICollisionHandler
    {
        public static BlockCollisionHandler Instance { get; } = new BlockCollisionHandler();

        private BlockCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player)
        {
            //locked doors should open if the player has a key
            //movable blocks should move
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile)
        {
            //bombs should blow up walls with hidden rooms
        }
        public void HandleEnemyCollision(IEnemy enemy)
        {
            //nothing will happen
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
            //movable blocks should stop when they hit other blocks
        }
        public void HandleBoundaryCollision()
        {
            //movable blocks should stop
        }
    }
}
