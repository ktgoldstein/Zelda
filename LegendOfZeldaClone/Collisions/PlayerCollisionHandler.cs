namespace LegendOfZeldaClone
{
    public class PlayerCollisionHandler : ICollisionHandler
    {
        public IPlayer CurrentPlayer { get; set; }

        public static PlayerCollisionHandler Instance { get; } = new PlayerCollisionHandler();
        private PlayerCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            //nothing will happen for now (only one player)
        }

        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            //nothing will happen
        }

        public void HandleEnemyCollision(IEnemy enemy, Direction direction)
        {
            //link should take damage and move backwards
        }

        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile, Direction direction)
        {
            //link should take damage and move backwards
        }

        public void HandleItemCollision(IItem item, Direction direction) 
        {
            //item should be added to player inventory
        }

        public void HandleBlockCollision(IObject block, Direction direction)
        {
            int xHalfway = (int)block.Location.X + block.Width / 2;
            int yHalfway = (int)block.Location.Y + block.Height / 2;
        }

        public void HandleBoundaryCollision(Boundary boundary, Direction direction)
        {
            //player should be stopped from going outside the boundary
        }
    }
}

