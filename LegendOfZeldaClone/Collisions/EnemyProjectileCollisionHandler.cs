﻿namespace LegendOfZeldaClone.Collisions
{
    class EnemyProjectileCollisionHandler : ICollisionHandler
    {
        public IEnemyProjectile CurrentEnemyProjectile { get; set; }

        public static EnemyProjectileCollisionHandler Instance { get; } = new EnemyProjectileCollisionHandler();
        private EnemyProjectileCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            if (CurrentEnemyProjectile is Enemy.Boomerang)
            {
                CurrentEnemyProjectile.Alive = false;
            }
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            //nothing will happen
        }
        public void HandleEnemyCollision(IEnemy enemy, Direction direction)
        {
            if (CurrentEnemyProjectile is Enemy.Boomerang)
            {
                Enemy.Boomerang boomerang = CurrentEnemyProjectile as Enemy.Boomerang;
                if (enemy is Enemy.Goriya)
                {
                    if (enemy == boomerang.goriya)
                    {
                        CurrentEnemyProjectile.Alive = false;
                        Enemy.Goriya goriya = boomerang.goriya as Enemy.Goriya;
                        goriya.HasBoomerang = false;
                    }
                }
            }
        }
        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction)
        {
            //nothing will happen
        }
        public void HandleItemCollision(IItem item, Direction direction)
        {
            //nothing will happen
        }

        public void HandleObjectCollision(IObject block, Direction direction)
        {
            //nothing will happen (enemy projectiles go through blocks)
        }
        public void HandleBoundaryCollision(Boundary boundary, Direction direction)
        {
            if (!(CurrentEnemyProjectile is Enemy.Boomerang))
            {
                CurrentEnemyProjectile.Alive = false;
            }
        }
    }
}
