using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Collisions
{
    class PlayerProjectileCollisionHandler : ICollisionHandler
    {
        public static PlayerProjectileCollisionHandler Instance { get; } = new PlayerProjectileCollisionHandler();

        private PlayerProjectileCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player)
        {
            //should disappear
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile)
        {
            //nothing will happen
        }
        public void HandleEnemyCollision(IEnemy enemy)
        {
            //should deal damage to enemy (unsure if boomerangs are included)
        }
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile)
        {
            //nothing will happen?
        }
        public void HandleItemCollision(IItem item)
        {
            //item should disappear and be added to player inventory
        }

        public void HandleBlockCollision(ISprite block) //tentative; IBlock interface?
        {
            //not sure yet if projectiles can go through objects or not
        }
        public void HandleBoundaryCollision()
        {
            //should disappear on contact
        }
    }
}
