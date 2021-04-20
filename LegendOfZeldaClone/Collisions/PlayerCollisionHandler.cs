using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class PlayerCollisionHandler : ICollisionHandler
    {
        public IPlayer CurrentPlayer { get; set; }
        public static PlayerCollisionHandler Instance { get; } = new PlayerCollisionHandler();
        private PlayerCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player, Direction direction) { } // Nothing will happen for now (only one player)

        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            if (playerProjectile is FireProjectile)
                CurrentPlayer.Damage(1, direction);
        }

        public void HandleEnemyCollision(IEnemy enemy, Direction direction)
        {
            CurrentPlayer.Damage(enemy.AttackStat, direction);
        }

        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction)
        {
            if (CurrentPlayer.BlockingDirection != direction)
                CurrentPlayer.Damage(enemyProjectile.AttackStat, direction);
            else
            {
                enemyProjectile.Die();
                new ShieldDeflectingSoundEffect().Play();
            }
        }

        public void HandleItemCollision(IItem item, Direction direction)
        {

            if (item is FlashingRupee)
                CurrentPlayer.Inventory.RupeesHeld += (int)RupeeValues.FlashingRupeeValue;
            else if (item is BlueRupee)
                CurrentPlayer.Inventory.RupeesHeld += (int)RupeeValues.BlueRupeeValue;
            else if (item is GoldRupee)
                CurrentPlayer.Inventory.RupeesHeld += (int)RupeeValues.GoldRupeeValue;
            else if (item is Bomb)
            {
                if (!CurrentPlayer.Inventory.HasItem(UsableItemTypes.Bomb))
                {
                    CurrentPlayer.PickUpUsableItem(UsableItemTypes.Bomb, item);
                    new NewImportantItemAcquiredFanfareSoundEffect().Play();
                }
                CurrentPlayer.Inventory.BombsHeld += LoZHelpers.BombPickUpNumber;
            }
            else if (item is Key)
                CurrentPlayer.Inventory.KeysHeld++;
            else if (item is BlueCandle)
                CurrentPlayer.PickUpUsableItem(UsableItemTypes.BlueCandle, item);
            else if (item is BlueRing && CurrentPlayer is LinkPlayer)
                CurrentPlayer.PickUpUsableItem(UsableItemTypes.BlueRing, item);
            else if (item is Boomerang)
                CurrentPlayer.PickUpUsableItem(UsableItemTypes.BoomerangNormal, item);
            else if (item is Bow)
                CurrentPlayer.PickUpUsableItem(UsableItemTypes.BowWooden, item);
            else if (item is HeartContainer)
            {
                CurrentPlayer.MaxHealth += 2;
                CurrentPlayer.Heal(2);
            }
            else if (item is Heart)
                CurrentPlayer.Heal(2);
            else if (item is Fairy)
                CurrentPlayer.Heal(CurrentPlayer.MaxHealth);
            else if (item is Map)
                CurrentPlayer.Inventory.HasMap = true;
            else if (item is Compass)
                CurrentPlayer.Inventory.HasCompass = true;
            else if (item is Arrow)
                CurrentPlayer.Inventory.HasArrow = true;
            else if (item is LifePotion)
            {
                CurrentPlayer.PickUpUsableItem(UsableItemTypes.LifePotion, item);
            }
            else if (item is TriForcePiece)
                CurrentPlayer.PickUpTriforce(item);
            else if (item is Clock)
                CurrentPlayer.Damage(0, Direction.None);
        }


        public void HandleObjectCollision(IObject block, Direction direction)
        {
            if (block.BlockHeight != ObjectHeight.CanWalkOver)
            {
                switch (direction)
                {
                    case Direction.Down:
                        CurrentPlayer.HurtBoxLocation = new Vector2(CurrentPlayer.HurtBoxLocation.X, block.HurtBoxLocation.Y - CurrentPlayer.Height);
                        break;
                    case Direction.Up:
                        CurrentPlayer.HurtBoxLocation = new Vector2(CurrentPlayer.HurtBoxLocation.X, block.HurtBoxLocation.Y + block.Height);
                        break;
                    case Direction.Left:
                        CurrentPlayer.HurtBoxLocation = new Vector2(block.HurtBoxLocation.X + block.Width, CurrentPlayer.HurtBoxLocation.Y);
                        break;
                    case Direction.Right:
                        CurrentPlayer.HurtBoxLocation = new Vector2(block.HurtBoxLocation.X - CurrentPlayer.Width, CurrentPlayer.HurtBoxLocation.Y);
                        break;
                }
            }
        }
    }
}

