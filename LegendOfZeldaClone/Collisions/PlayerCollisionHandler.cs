namespace LegendOfZeldaClone
{
    public class PlayerCollisionHandler : ICollisionHandler
    {
        public static PlayerCollisionHandler Instance { get; } = new PlayerCollisionHandler();

        private PlayerCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player)
        {
            //nothing will happen for now (only one player)
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile)
        {
            //nothing will happen
        }
        public void HandleEnemyCollision(IEnemy enemy)
        {
            //link should take damage and move backwards
        }
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile)
        {
            //link should take damage and move backwards
        }
        public void HandleItemCollision(IItem item) 
        {
            //item should be added to player inventory
        }

        public void HandleBlockCollision(IObject block)
        {
            //player should stop and have to move around the block
        }
        public void HandleBoundaryCollision()
        {
            //player should be stopped from going outside the boundary
        }


    }
}

