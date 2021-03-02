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
            //player should stop against most blocks and have to walk around them
            //locked doors should open if the player has a key
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile)
        {
            //bombs should blow up walls with hidden rooms
            //not sure if other projectiles will go through blocks or not
        }
        public void HandleEnemyCollision(IEnemy enemy)
        {
            //enemies should stop against most blocks and have to move around them
        }
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile)
        {
            //not sure if projectiles will go through blocks or not
        }
        public void HandleItemCollision(IItem item)
        {
            //nothing should happen
        }

        public void HandleBlockCollision(ISprite block) //tentative; IBlock interface?
        {
            //nothing should happen
        }
        public void HandleBoundaryCollision()
        {
            //nothing should happen
        }
    }
}
