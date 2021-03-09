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

            // Player collisions
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
                PlayerCollisionHandler.Instance.CurrentPlayer = player;
                foreach (IPlayerProjectile playerProjectile in playerProjectiles)
                {
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(player.HurtBoxLocation, player.Width, player.Height,
                        playerProjectile.Location, playerProjectile.Width, playerProjectile.Height);
                    if (collisionDirection != Direction.None)
                    {
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
                        PlayerCollisionHandler.Instance.HandleEnemyProjectileCollision(enemyProjectile, collisionDirection);
                        EnemyProjectileCollisionHandler.Instance.CurrentEnemyProjectile = enemyProjectile;
                        EnemyProjectileCollisionHandler.Instance.HandlePlayerCollision(player, LoZHelpers.FlipDirection(collisionDirection));
                    }
                }
                foreach (IItem item in items)
                {
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(player.HurtBoxLocation, player.Width, player.Height,
                        item.Location, item.Width, item.Height);
                    if (collisionDirection != Direction.None)
                    {
                        PlayerCollisionHandler.Instance.HandleItemCollision(item, collisionDirection);
                        ItemCollisionHandler.Instance.CurrentItem = item;
                        ItemCollisionHandler.Instance.HandlePlayerCollision(player, LoZHelpers.FlipDirection(collisionDirection));
                    }
                }
                foreach (IObject block in blocks)
                {
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(player.HurtBoxLocation, player.Width, player.Height,
                        block.Location, block.Width, block.Height);
                    if (collisionDirection != Direction.None)
                    {
                        PlayerCollisionHandler.Instance.HandleObjectCollision(block, collisionDirection);
                        ObjectCollisionHandler.Instance.CurrentObject = block;
                        ObjectCollisionHandler.Instance.HandlePlayerCollision(player, LoZHelpers.FlipDirection(collisionDirection));
                    }
                }
            }

            // PlayerProjectile collisions
            for (int playerProjectileIndex = 0; playerProjectileIndex < playerProjectiles.Count; playerProjectileIndex++)
            {
                IPlayerProjectile playerProjectile = playerProjectiles[playerProjectileIndex];
                for (int secondPlayerProjectileIndex = playerProjectileIndex + 1; secondPlayerProjectileIndex < playerProjectiles.Count; secondPlayerProjectileIndex++)
                {
                    IPlayerProjectile secondPlayerProjectile = playerProjectiles[secondPlayerProjectileIndex];
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(playerProjectile.Location, playerProjectile.Width, playerProjectile.Height,
                        secondPlayerProjectile.Location, secondPlayerProjectile.Width, secondPlayerProjectile.Height);
                    if (collisionDirection != Direction.None)
                    {
                        PlayerProjectileCollisionHandler.Instance.CurrentPlayerProjectile = playerProjectile;
                        PlayerProjectileCollisionHandler.Instance.HandlePlayerProjectileCollision(secondPlayerProjectile, collisionDirection);
                        PlayerProjectileCollisionHandler.Instance.CurrentPlayerProjectile = secondPlayerProjectile;
                        PlayerProjectileCollisionHandler.Instance.HandlePlayerProjectileCollision(playerProjectile, collisionDirection);
                    }
                }
                PlayerProjectileCollisionHandler.Instance.CurrentPlayerProjectile = playerProjectile;
                foreach (IEnemy enemy in enemies)
                {
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(playerProjectile.Location, playerProjectile.Width, playerProjectile.Height,
                        enemy.Location, enemy.Width, enemy.Height);
                    if (collisionDirection != Direction.None)
                    {
                        PlayerProjectileCollisionHandler.Instance.HandleEnemyCollision(enemy, collisionDirection);
                        EnemyCollisionHandler.Instance.CurrentEnemy = enemy;
                        EnemyCollisionHandler.Instance.HandlePlayerProjectileCollision(playerProjectile, LoZHelpers.FlipDirection(collisionDirection));
                    }
                }
                foreach (IEnemyProjectile enemyProjectile in enemyProjectiles)
                {
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(playerProjectile.Location, playerProjectile.Width, playerProjectile.Height,
                        enemyProjectile.Location, enemyProjectile.Width, enemyProjectile.Height);
                    if (collisionDirection != Direction.None)
                    {
                        PlayerProjectileCollisionHandler.Instance.HandleEnemyProjectileCollision(enemyProjectile, collisionDirection);
                        EnemyProjectileCollisionHandler.Instance.CurrentEnemyProjectile = enemyProjectile;
                        EnemyProjectileCollisionHandler.Instance.HandlePlayerProjectileCollision(playerProjectile, LoZHelpers.FlipDirection(collisionDirection));
                    }
                }
                foreach (IItem item in items)
                {
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(playerProjectile.Location, playerProjectile.Width, playerProjectile.Height,
                        item.Location, item.Width, item.Height);
                    if (collisionDirection != Direction.None)
                    {
                        PlayerProjectileCollisionHandler.Instance.HandleItemCollision(item, collisionDirection);
                        ItemCollisionHandler.Instance.CurrentItem = item;
                        ItemCollisionHandler.Instance.HandlePlayerProjectileCollision(playerProjectile, LoZHelpers.FlipDirection(collisionDirection));
                    }
                }
                foreach (IObject block in blocks)
                {
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(playerProjectile.Location, playerProjectile.Width, playerProjectile.Height,
                        block.Location, block.Width, block.Height);
                    if (collisionDirection != Direction.None)
                    {
                        PlayerProjectileCollisionHandler.Instance.HandleObjectCollision(block, collisionDirection);
                        ObjectCollisionHandler.Instance.CurrentObject = block;
                        ObjectCollisionHandler.Instance.HandlePlayerProjectileCollision(playerProjectile, LoZHelpers.FlipDirection(collisionDirection));
                    }
                }
            }

            // Enemy collisions
            for (int enemyIndex = 0; enemyIndex < enemies.Count; enemyIndex++)
            {
                IEnemy enemy = enemies[enemyIndex];
                for (int secondEnemyIndex = enemyIndex + 1; secondEnemyIndex < enemies.Count; secondEnemyIndex++)
                {
                    IEnemy secondEnemy = enemies[secondEnemyIndex];
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(enemy.Location, enemy.Width, enemy.Height,
                        secondEnemy.Location, secondEnemy.Width, secondEnemy.Height);
                    if (collisionDirection != Direction.None)
                    {
                        EnemyCollisionHandler.Instance.CurrentEnemy = enemy;
                        EnemyCollisionHandler.Instance.HandleEnemyCollision(secondEnemy, collisionDirection);
                        EnemyCollisionHandler.Instance.CurrentEnemy = secondEnemy;
                        EnemyCollisionHandler.Instance.HandleEnemyCollision(enemy, collisionDirection);
                    }
                }
                EnemyCollisionHandler.Instance.CurrentEnemy = enemy;
                foreach (IEnemyProjectile enemyProjectile in enemyProjectiles)
                {
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(enemy.Location, enemy.Width, enemy.Height,
                        enemyProjectile.Location, enemyProjectile.Width, enemyProjectile.Height);
                    if (collisionDirection != Direction.None)
                    {
                        EnemyCollisionHandler.Instance.HandleEnemyProjectileCollision(enemyProjectile, collisionDirection);
                        EnemyProjectileCollisionHandler.Instance.CurrentEnemyProjectile = enemyProjectile;
                        EnemyProjectileCollisionHandler.Instance.HandleEnemyCollision(enemy, LoZHelpers.FlipDirection(collisionDirection));
                    }
                }
                foreach (IItem item in items)
                {
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(enemy.Location, enemy.Width, enemy.Height,
                        item.Location, item.Width, item.Height);
                    if (collisionDirection != Direction.None)
                    {
                        EnemyCollisionHandler.Instance.HandleItemCollision(item, collisionDirection);
                        ItemCollisionHandler.Instance.CurrentItem = item;
                        ItemCollisionHandler.Instance.HandleEnemyCollision(enemy, LoZHelpers.FlipDirection(collisionDirection));
                    }
                }
                foreach (IObject block in blocks)
                {
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(enemy.Location, enemy.Width, enemy.Height,
                        block.Location, block.Width, block.Height);
                    if (collisionDirection != Direction.None)
                    {
                        EnemyCollisionHandler.Instance.HandleObjectCollision(block, collisionDirection);
                        ObjectCollisionHandler.Instance.CurrentObject = block;
                        ObjectCollisionHandler.Instance.HandleEnemyCollision(enemy, LoZHelpers.FlipDirection(collisionDirection));
                    }
                }
            }

            // EnemyProjectile collisions
            for (int enemyProjectileIndex = 0; enemyProjectileIndex < enemyProjectiles.Count; enemyProjectileIndex++)
            {
                IEnemyProjectile enemyProjectile = enemyProjectiles[enemyProjectileIndex];
                for (int secondEnemyProjectileIndex = enemyProjectileIndex + 1; secondEnemyProjectileIndex < enemyProjectiles.Count; secondEnemyProjectileIndex++)
                {
                    IEnemyProjectile secondEnemyProjectile = enemyProjectiles[secondEnemyProjectileIndex];
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(enemyProjectile.Location, enemyProjectile.Width, enemyProjectile.Height,
                        secondEnemyProjectile.Location, secondEnemyProjectile.Width, secondEnemyProjectile.Height);
                    if (collisionDirection != Direction.None)
                    {
                        EnemyProjectileCollisionHandler.Instance.CurrentEnemyProjectile = enemyProjectile;
                        EnemyProjectileCollisionHandler.Instance.HandleEnemyProjectileCollision(secondEnemyProjectile, collisionDirection);
                        EnemyProjectileCollisionHandler.Instance.CurrentEnemyProjectile = secondEnemyProjectile;
                        EnemyProjectileCollisionHandler.Instance.HandleEnemyProjectileCollision(enemyProjectile, collisionDirection);
                    }
                }
                EnemyProjectileCollisionHandler.Instance.CurrentEnemyProjectile = enemyProjectile;
                foreach (IItem item in items)
                {
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(enemyProjectile.Location, enemyProjectile.Width, enemyProjectile.Height,
                        item.Location, item.Width, item.Height);
                    if (collisionDirection != Direction.None)
                    {
                        EnemyProjectileCollisionHandler.Instance.HandleItemCollision(item, collisionDirection);
                        ItemCollisionHandler.Instance.CurrentItem = item;
                        ItemCollisionHandler.Instance.HandleEnemyProjectileCollision(enemyProjectile, LoZHelpers.FlipDirection(collisionDirection));
                    }
                }
                foreach (IObject block in blocks)
                {
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(enemyProjectile.Location, enemyProjectile.Width, enemyProjectile.Height,
                        block.Location, block.Width, block.Height);
                    if (collisionDirection != Direction.None)
                    {
                        EnemyProjectileCollisionHandler.Instance.HandleObjectCollision(block, collisionDirection);
                        ObjectCollisionHandler.Instance.CurrentObject = block;
                        ObjectCollisionHandler.Instance.HandleEnemyProjectileCollision(enemyProjectile, LoZHelpers.FlipDirection(collisionDirection));
                    }
                }
            }

            // Item collisions
            for (int itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                IItem item = items[itemIndex];
                for (int secondItemIndex = itemIndex + 1; secondItemIndex < items.Count; secondItemIndex++)
                {
                    IItem secondItem = items[secondItemIndex];
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(item.Location, item.Width, item.Height,
                        secondItem.Location, secondItem.Width, secondItem.Height);
                    if (collisionDirection != Direction.None)
                    {
                        ItemCollisionHandler.Instance.CurrentItem = item;
                        ItemCollisionHandler.Instance.HandleItemCollision(secondItem, collisionDirection);
                        ItemCollisionHandler.Instance.CurrentItem = secondItem;
                        ItemCollisionHandler.Instance.HandleItemCollision(item, collisionDirection);
                    }
                }
                ItemCollisionHandler.Instance.CurrentItem = item;
                foreach (IObject block in blocks)
                {
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(item.Location, item.Width, item.Height,
                        block.Location, block.Width, block.Height);
                    if (collisionDirection != Direction.None)
                    {
                        ItemCollisionHandler.Instance.HandleObjectCollision(block, collisionDirection);
                        ObjectCollisionHandler.Instance.CurrentObject = block;
                        ObjectCollisionHandler.Instance.HandleItemCollision(item, LoZHelpers.FlipDirection(collisionDirection));
                    }
                }
            }

            // Block collisions
            for (int blockIndex = 0; blockIndex < blocks.Count; blockIndex++)
            {
                IObject block = blocks[blockIndex];
                for (int secondBlockIndex = blockIndex + 1; secondBlockIndex < blocks.Count; secondBlockIndex++)
                {
                    IObject secondBlock = blocks[secondBlockIndex];
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(block.Location, block.Width, block.Height,
                        secondBlock.Location, secondBlock.Width, secondBlock.Height);
                    if (collisionDirection != Direction.None)
                    {
                        ObjectCollisionHandler.Instance.CurrentObject = block;
                        ObjectCollisionHandler.Instance.HandleObjectCollision(secondBlock, collisionDirection);
                        ObjectCollisionHandler.Instance.CurrentObject = secondBlock;
                        ObjectCollisionHandler.Instance.HandleObjectCollision(block, collisionDirection);
                    }
                }
            }
        }
    }
}
