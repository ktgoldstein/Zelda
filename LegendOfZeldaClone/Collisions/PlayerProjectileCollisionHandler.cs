using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Collisions
{
    class PlayerProjectileCollisionHandler : ICollisionHandler
    {
        public static PlayerProjectileCollisionHandler Instance { get; } = new PlayerProjectileCollisionHandler();

        private PlayerProjectileCollisionHandler() { }

        public IPlayerProjectile CurrPlayerProjectile { get; set; }

        public void HandlePlayerCollision(IPlayer player)
        {
            //should only be for boomerangs (don't want bombs to disappear if walked across)
            CurrPlayerProjectile.Alive = false;
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile)
        {
            //nothing will happen
        }
        public void HandleEnemyCollision(IEnemy enemy)
        {
            //boomerangs don't disappear
            CurrPlayerProjectile.Alive = false;
        }
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile)
        {
            //nothing will happen?
        }
        public void HandleItemCollision(IItem item)
        {
            //projectile should return to player (only boomerangs can interact with items)
        }

        public void HandleBlockCollision(IObject block)
        {
            //nothing will happen if it is a boomerang
            CurrPlayerProjectile.Alive = false;
        }
        public void HandleBoundaryCollision()
        {
            //boomerangs do not disappear (they seem to clip through walls too)
            CurrPlayerProjectile.Alive = false;
        }
    }
}
