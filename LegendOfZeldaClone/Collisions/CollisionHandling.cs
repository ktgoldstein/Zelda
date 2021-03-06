using System.Collections.Generic;

namespace LegendOfZeldaClone.Collisions
{
    public static class CollisionHandling
    {
        public static void HandleCollisions(GameStateMachine game)
        {
            List<IGameObject> gameObjects = new List<IGameObject>();
            gameObjects.Add(game.Player);
            gameObjects.AddRange(game.PlayerProjectiles);
            gameObjects.AddRange(game.Enemies);
            gameObjects.AddRange(game.EnemyProjectiles);
            gameObjects.AddRange(game.Items);
            gameObjects.AddRange(game.Blocks);

            for (int firstIndex = 0; firstIndex < gameObjects.Count; firstIndex++)
            {
                IGameObject firstGameObject = gameObjects[firstIndex];
                for (int secondIndex = firstIndex + 1; secondIndex < gameObjects.Count; secondIndex++)
                {
                    IGameObject secondGameObject = gameObjects[secondIndex];
                    Direction collisionDirection = CollisionDetection.DetectCollisionDirection(firstGameObject.HurtBoxLocation, firstGameObject.Width, firstGameObject.Height,
                        secondGameObject.HurtBoxLocation, secondGameObject.Width, secondGameObject.Height);
                    if (collisionDirection != Direction.None)
                    {
                        Collide(firstGameObject, secondGameObject, collisionDirection);
                        Collide(secondGameObject, firstGameObject, LoZHelpers.FlipDirection(collisionDirection));
                    }
                }
            }
        }

        private static void Collide(IGameObject gameObject1, IGameObject gameObject2, Direction direction)
        {
            ICollisionHandler handler = GetCollisionHandler(gameObject1);

            if (gameObject2 is IPlayer)
                handler.HandlePlayerCollision(gameObject2 as IPlayer, direction);
            else if (gameObject2 is IPlayerProjectile)
                handler.HandlePlayerProjectileCollision(gameObject2 as IPlayerProjectile, direction);
            else if (gameObject2 is IEnemy)
                handler.HandleEnemyCollision(gameObject2 as IEnemy, direction);
            else if (gameObject2 is IEnemyProjectile)
                handler.HandleEnemyProjectileCollision(gameObject2 as IEnemyProjectile, direction);
            else if (gameObject2 is IItem)
                handler.HandleItemCollision(gameObject2 as IItem, direction);
            else if (gameObject2 is IBlock)
                handler.HandleBlockCollision(gameObject2 as IBlock, direction);
        }

        private static ICollisionHandler GetCollisionHandler(IGameObject gameObject)
        {
            ICollisionHandler correctHandler = null;

            if (gameObject is IPlayer)
            {
                correctHandler = PlayerCollisionHandler.Instance;
                PlayerCollisionHandler.Instance.CurrentPlayer = gameObject as IPlayer;
            }
            else if (gameObject is IPlayerProjectile)
            {
                correctHandler = PlayerProjectileCollisionHandler.Instance;
                PlayerProjectileCollisionHandler.Instance.CurrentPlayerProjectile = gameObject as IPlayerProjectile;
            }
            else if (gameObject is IEnemy)
            {
                correctHandler = EnemyCollisionHandler.Instance;
                EnemyCollisionHandler.Instance.CurrentEnemy = gameObject as IEnemy;
            }
            else if (gameObject is IEnemyProjectile)
            {
                correctHandler = EnemyProjectileCollisionHandler.Instance;
                EnemyProjectileCollisionHandler.Instance.CurrentEnemyProjectile = gameObject as IEnemyProjectile;
            }
            else if (gameObject is IItem)
            {
                correctHandler = ItemCollisionHandler.Instance;
                ItemCollisionHandler.Instance.CurrentItem = gameObject as IItem;
            }
            else if (gameObject is IBlock)
            {
                correctHandler = BlockCollisionHandler.Instance;
                BlockCollisionHandler.Instance.CurrentBlock = gameObject as IBlock;
            }

            return correctHandler;
        }            
    }
}
