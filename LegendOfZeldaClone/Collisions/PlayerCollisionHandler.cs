using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class PlayerCollisionHandler : ICollisionHandler
    {
        public IPlayer CurrentPlayer { get; set; }

        public static PlayerCollisionHandler Instance { get; } = new PlayerCollisionHandler();
        private PlayerCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player, Direction direction) { } // Nothing will happen for now (only one player)

        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction) { } // No collision

        public void HandleEnemyCollision(IEnemy enemy, Direction direction)
        {
            CurrentPlayer.Damage(enemy.AttackStat, direction);
        }

        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction)
        {
            CurrentPlayer.Damage(enemyProjectile.AttackStat, direction);
        }

        public void HandleItemCollision(IItem item, Direction direction) 
        {
            if (item is FlashingRupee)
                CurrentPlayer.Inventory.RupeesHeld += 1;
            else if (item is BlueRupee)
                CurrentPlayer.Inventory.RupeesHeld += 5;
            else if (item is GoldRupee)
                CurrentPlayer.Inventory.RupeesHeld += 10;
            else if (item is Bomb)
                CurrentPlayer.Inventory.BombsHeld++;
            else if (item is Key)
                CurrentPlayer.Inventory.KeysHeld++;
            else if (item is BlueCandle)
                CurrentPlayer.PickUpUsableItem(UsableItemTypes.BlueCandle, item);
            else if (item is BlueRing)
                CurrentPlayer.PickUpUsableItem(UsableItemTypes.BlueRing, item);
            else if (item is Boomerang)
                CurrentPlayer.PickUpUsableItem(UsableItemTypes.BoomerangNormal, item);
            else if (item is Bow)
                CurrentPlayer.PickUpUsableItem(UsableItemTypes.BowWooden, item);
        }

        public void HandleObjectCollision(IObject block, Direction direction)
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

        public void HandleBoundaryCollision(Boundary boundary, Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    CurrentPlayer.HurtBoxLocation = new Vector2(CurrentPlayer.HurtBoxLocation.X, boundary.Location.Y + boundary.Height - CurrentPlayer.Height);
                    break;
                case Direction.Up:
                    CurrentPlayer.HurtBoxLocation = new Vector2(CurrentPlayer.HurtBoxLocation.X, boundary.Location.Y);
                    break;
                case Direction.Left:
                    CurrentPlayer.HurtBoxLocation = new Vector2(boundary.Location.X, CurrentPlayer.HurtBoxLocation.Y);
                    break;
                case Direction.Right:
                    CurrentPlayer.HurtBoxLocation = new Vector2(boundary.Location.X + boundary.Width - CurrentPlayer.Width, CurrentPlayer.HurtBoxLocation.Y);
                    break;
            }
        }
    }
}

