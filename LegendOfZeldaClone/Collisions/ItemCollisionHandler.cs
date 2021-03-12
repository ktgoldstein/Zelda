using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone.Collisions
{
    class ItemCollisionHandler : ICollisionHandler
    {
        public IItem CurrentItem { get; set; }

        public static ItemCollisionHandler Instance { get; } = new ItemCollisionHandler();
        private ItemCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            CurrentItem.Alive = false;
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            //only rupees, clocks, or bombs. Everything else does nothing
            if (CurrentItem is FlashingRupee || CurrentItem is BlueRupee || CurrentItem is GoldRupee || CurrentItem is Clock || CurrentItem is Bomb)
            {
                CurrentItem.Alive = false;
            }
            
        }
        public void HandleEnemyCollision(IEnemy enemy, Direction direction)
        {
            //nothing will happen
        }
        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction)
        {
            //nothing will happen
        }
        public void HandleItemCollision(IItem item, Direction direction)
        {
            //nothing will happen (they can overlap)
        }

        public void HandleObjectCollision(IObject block, Direction direction)
        {
            //nothing will happen (fairies fly over blocks like keese do)
            if (block.BlockHeight == ObjectHeight.Impassable)
            {
                if (CurrentItem is Fairy)
                {
                    Fairy fairy = CurrentItem as Fairy;
                    switch (direction)
                    {
                        case Direction.Up:
                            fairy.FairyDirection = new Vector2(fairy.FairyDirection.X, 1);
                            break;
                        case Direction.Down:
                            fairy.FairyDirection = new Vector2(fairy.FairyDirection.X, -1);
                            break;
                        case Direction.Left:
                            fairy.FairyDirection = new Vector2(1, fairy.FairyDirection.Y);
                            break;
                        case Direction.Right:
                            fairy.FairyDirection = new Vector2(-1, fairy.FairyDirection.Y);
                            break;
                        case Direction.UpLeft:
                            fairy.FairyDirection = new Vector2(1, 1);
                            break;
                        case Direction.UpRight:
                            fairy.FairyDirection = new Vector2(-1, 1);
                            break;
                        case Direction.DownLeft:
                            fairy.FairyDirection = new Vector2(1, -1);
                            break;
                        case Direction.DownRight:
                            fairy.FairyDirection = new Vector2(-1, -1);
                            break;
                    }
                }
            }
        }
        public void HandleBoundaryCollision(Boundary boundary, Direction direction)
        {
            if (CurrentItem is Fairy)
            {
                Fairy fairy = CurrentItem as Fairy;
                switch (direction) {
                    case Direction.Up:
                        fairy.FairyDirection = new Vector2(fairy.FairyDirection.X, 1);
                        break;
                    case Direction.Down:
                        fairy.FairyDirection = new Vector2(fairy.FairyDirection.X, -1);
                        break;
                    case Direction.Left:
                        fairy.FairyDirection = new Vector2(1, fairy.FairyDirection.Y);
                        break;
                    case Direction.Right:
                        fairy.FairyDirection = new Vector2(-1, fairy.FairyDirection.Y);
                        break;
                    case Direction.UpLeft:
                        fairy.FairyDirection = new Vector2(1, 1);
                        break;
                    case Direction.UpRight:
                        fairy.FairyDirection = new Vector2(-1, 1);
                        break;
                    case Direction.DownLeft:
                        fairy.FairyDirection = new Vector2(1, -1);
                        break;
                    case Direction.DownRight:
                        fairy.FairyDirection = new Vector2(-1, -1);
                        break;
                }
            }
        }
    }
}
