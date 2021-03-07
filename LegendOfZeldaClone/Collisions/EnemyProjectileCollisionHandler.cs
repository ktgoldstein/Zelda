namespace LegendOfZeldaClone.Collisions
{
    class EnemyProjectileCollisionHandler : ICollisionHandler
    {
        public static EnemyProjectileCollisionHandler Instance { get; } = new EnemyProjectileCollisionHandler();

        private EnemyProjectileCollisionHandler() { }

        public IEnemyProjectile CurrEnemyProjectile { get; set; }

        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            //boomerangs don't disappear (they just keep moving)
            CurrEnemyProjectile.Alive = false;
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            //nothing will happen
        }
        public void HandleEnemyCollision(IEnemy enemy, Direction direction)
        {
            //check for what enemy it is (does it matter if it's the one who threw it or not?)
            CurrEnemyProjectile.Alive = false;
        }
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile, Direction direction)
        {
            //nothing will happen
        }
        public void HandleItemCollision(IItem item, Direction direction)
        {
            //nothing will happen
        }

        public void HandleBlockCollision(IObject block, Direction direction)
        {
            //nothing will happen (enemy projectiles go through blocks)
        }
        public void HandleBoundaryCollision(Boundary boundary, Direction direction)
        {
            //boomerangs don't disappear (clip through walls)
            CurrEnemyProjectile.Alive = false;
        }
    }
}
