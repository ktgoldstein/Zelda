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
            //boomerang should disappear (only one that should collide and do something upon collision)
            //not sure if bombs deal damage yet
        }
        public void HandleEnemyCollision(IEnemy enemy)
        {
            //link should take damage and move backwards (I think this is already handled in the damage state)
        }
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile)
        {
            //link should take damage (unsure if he should move back or not)
        }
        public void HandleItemCollision(IItem item) 
        {
            //item should disappear and be added to player inventory
        }

        public void HandleBlockCollision(ISprite block) //tentative; IBlock interface?
        {
            //player should stop and have to move around the block
        }
        public void HandleBoundaryCollision()
        {
            //player should be stopped from going outside the boundary
        }


    }
}

