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
            CurrPlayerProjectile.Alive = false;
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile)
        {
            //nothing will happen
        }
        public void HandleEnemyCollision(IEnemy enemy)
        {
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
            CurrPlayerProjectile.Alive = false;
        }
    }
}
