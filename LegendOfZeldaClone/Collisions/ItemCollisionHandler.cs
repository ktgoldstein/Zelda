﻿using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone.Collisions
{
    class ItemCollisionHandler : ICollisionHandler
    {
        public IItem CurrentItem { get; set; }

        public static ItemCollisionHandler Instance { get; } = new ItemCollisionHandler();
        private ItemCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player, Direction direction) => CurrentItem.BeCollected();
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            if ((CurrentItem is FlashingRupee || CurrentItem is BlueRupee || CurrentItem is GoldRupee || CurrentItem is Clock || CurrentItem is Bomb) && playerProjectile is BoomerangProjectile)
            {
                CurrentItem.Alive = false;
                if (CurrentItem is FlashingRupee || CurrentItem is BlueRupee || CurrentItem is GoldRupee)
                    new RupeePickupSoundEffect().Play();
                if (CurrentItem is Clock)
                    new ClockPickupSoundEffect().Play();
                if (CurrentItem is Bomb)
                    new InventoryItemPickupSoundEffect().Play();
            }
            
        }
        public void HandleEnemyCollision(IEnemy enemy, Direction direction) {}
        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction) {}
        public void HandleItemCollision(IItem item, Direction direction) {}

        public void HandleObjectCollision(IObject block, Direction direction)
        {
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
                    }
                    fairy.FairyDirection.Normalize();
                }
            }
        }
    }
}
