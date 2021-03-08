using System.Collections.Generic;

namespace LegendOfZeldaClone.Collisions
{
    public static class CollisionHandling 
    {
        public static void HandleCollisions(LegendOfZeldaDungeon game)
        {
            List<IPlayer> players = new List<IPlayer> { game.Link };
            List<IPlayerProjectile> playerProjectiles = game.LinkProjectiles;
            List<IEnemy> enemies = new List<IEnemy> { game.enemyList[game.currentEnemyIndex] };
            List<IEnemyProjectile> enemyProjectiles = game.EnemyProjectiles;
            List<IItem> items = game.Items;
            List<IObject> blocks = new List<IObject> { game.CurrentObject };
            
            foreach (IPlayer player in players)
            {
                foreach (IPlayerProjectile playerProjectile in playerProjectiles)
                {
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(player.HurtBoxLocation, player.Width, player.Height,
                        playerProjectile.Location, playerProjectile.Width, playerProjectile.Height);
                    if (collisionDirection != Direction.None)
                    {

                    }
                }
            }
        }
    }
}
