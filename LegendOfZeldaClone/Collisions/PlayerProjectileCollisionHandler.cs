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

        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            //should only be for boomerangs (don't want bombs to disappear if walked across)
            CurrPlayerProjectile.Alive = false;
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            //nothing will happen
        }
        public void HandleEnemyCollision(IEnemy enemy, Direction direction)
        {
            //boomerangs don't disappear
            CurrPlayerProjectile.Alive = false;
        }
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile, Direction direction)
        {
            //nothing will happen?
        }
        public void HandleItemCollision(IItem item, Direction direction)
        {
            //projectile should return to player (only boomerangs can interact with items)
        }

        public void HandleBlockCollision(IObject block, Direction direction)
        {
            //nothing will happen if it is a boomerang
            CurrPlayerProjectile.Alive = false;
        }
        public void HandleBoundaryCollision(Boundary boundary, Direction direction)
        {
            //boomerangs do not disappear (they seem to clip through walls too)
            CurrPlayerProjectile.Alive = false;
        }
    }
}
