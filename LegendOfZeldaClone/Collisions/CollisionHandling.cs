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
            Boundary boundary;
            
            for (int playerIndex = 0; playerIndex < players.Count; playerIndex++)
            {
                IPlayer player = players[playerIndex];
                for (int secondPlayerIndex = playerIndex + 1; secondPlayerIndex < players.Count; secondPlayerIndex++)
                {
                    IPlayer secondPlayer = players[secondPlayerIndex];
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(player.HurtBoxLocation, player.Width, player.Height,
                        secondPlayer.Location, secondPlayer.Width, secondPlayer.Height);
                    if (collisionDirection != Direction.None)
                    {
                        PlayerCollisionHandler.Instance.CurrentPlayer = player;
                        PlayerCollisionHandler.Instance.HandlePlayerCollision(secondPlayer, collisionDirection);
                        PlayerCollisionHandler.Instance.CurrentPlayer = secondPlayer;
                        PlayerCollisionHandler.Instance.HandlePlayerCollision(player, collisionDirection);
                    }
                }
                foreach (IPlayerProjectile playerProjectile in playerProjectiles)
                {
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(player.HurtBoxLocation, player.Width, player.Height,
                        playerProjectile.Location, playerProjectile.Width, playerProjectile.Height);
                    if (collisionDirection != Direction.None)
                    {
                        PlayerCollisionHandler.Instance.CurrentPlayer = player;
                        PlayerCollisionHandler.Instance.HandlePlayerProjectileCollision(playerProjectile, collisionDirection);
                        PlayerProjectileCollisionHandler.Instance.CurrentPlayerProjectile = playerProjectile;
                        PlayerProjectileCollisionHandler.Instance.HandlePlayerCollision(player, LoZHelpers.FlipDirection(collisionDirection));
                    }
                }
                foreach (IEnemy enemy in enemies)
                {
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(player.HurtBoxLocation, player.Width, player.Height,
                        enemy.Location, enemy.Width, enemy.Height);
                    if (collisionDirection != Direction.None)
                    {
                        PlayerCollisionHandler.Instance.CurrentPlayer = player;
                        PlayerCollisionHandler.Instance.HandleEnemyCollision(enemy, collisionDirection);
                        EnemyCollisionHandler.Instance.CurrentEnemy = enemy;
                        EnemyCollisionHandler.Instance.HandlePlayerCollision(player, LoZHelpers.FlipDirection(collisionDirection));
                    }
                }
                foreach (IEnemyProjectile enemyProjectile in enemyProjectiles)
                {
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(player.HurtBoxLocation, player.Width, player.Height,
                        enemyProjectile.Location, enemyProjectile.Width, enemyProjectile.Height);
                    if (collisionDirection != Direction.None)
                    {
                        PlayerCollisionHandler.Instance.CurrentPlayer = player;
                        PlayerCollisionHandler.Instance.HandleEnemyProjectileCollision(enemyProjectile, collisionDirection);
                        EnemyProjectileCollisionHandler.Instance.CurrentEnemyProjectile = enemyProjectile;
                        EnemyProjectileCollisionHandler.Instance.HandlePlayerCollision(player, LoZHelpers.FlipDirection(collisionDirection));
                    }
                }
            }
        }
    }
}
