using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Collisions
{
    class PlayerProjectileCollisionHandler : ICollisionHandler
    {
        public IPlayerProjectile CurrentPlayerProjectile { get; set; }

        public static PlayerProjectileCollisionHandler Instance { get; } = new PlayerProjectileCollisionHandler();
        private PlayerProjectileCollisionHandler() { }


        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            //should only be for boomerangs (don't want bombs to disappear if walked across)
            CurrentPlayerProjectile.Alive = false;
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            //nothing will happen
        }
        public void HandleEnemyCollision(IEnemy enemy, Direction direction)
        {
            //boomerangs don't disappear
            CurrentPlayerProjectile.Alive = false;
        }
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile, Direction direction)
        {
            //nothing will happen?
        }
        public void HandleItemCollision(IItem item, Direction direction)
        {
            //projectile should return to player (only boomerangs can interact with items)
        }

        public void HandleObjectCollision(IObject block, Direction direction)
        {
            //nothing will happen if it is a boomerang
            CurrentPlayerProjectile.Alive = false;
        }
        public void HandleBoundaryCollision(Boundary boundary, Direction direction)
        {
            //boomerangs do not disappear (they seem to clip through walls too)
            CurrentPlayerProjectile.Alive = false;
        }
    }
}
