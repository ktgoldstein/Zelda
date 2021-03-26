using Microsoft.Xna.Framework;
using LegendOfZeldaClone.Objects;



namespace LegendOfZeldaClone.Collisions
{
    class ObjectCollisionHandler : ICollisionHandler
    {
        public IObject CurrentObject { get; set; }

        public static ObjectCollisionHandler Instance { get; } = new ObjectCollisionHandler();
        private ObjectCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            if ((CurrentObject is LockedDoorUp || CurrentObject is LockedDoorDown ||
                CurrentObject is LockedDoorLeft || CurrentObject is LockedDoorRight) &&
                player.Inventory.KeysHeld > 0 )
            { 
                CurrentObject.IsAlive = false;
                player.Inventory.KeysHeld--;
            }
            else if (CurrentObject.IsMovable)
            {
                int blockPushingSpeedConstant = LoZHelpers.Scale(1);
                switch (direction)
                {
                    case Direction.Down:
                        CurrentObject.Location = new Vector2(CurrentObject.Location.X, CurrentObject.Location.Y - blockPushingSpeedConstant);
                        break;
                    case Direction.Up:
                        CurrentObject.Location = new Vector2(CurrentObject.Location.X, CurrentObject.Location.Y + blockPushingSpeedConstant);
                        break;
                    case Direction.Left:
                        CurrentObject.Location = new Vector2(CurrentObject.Location.X + blockPushingSpeedConstant, CurrentObject.Location.Y);
                        break;
                    case Direction.Right:
                        CurrentObject.Location = new Vector2(CurrentObject.Location.X - blockPushingSpeedConstant, CurrentObject.Location.Y);
                        break;
                }
            }
            else if (CurrentObject is IDoor)
            {
                (CurrentObject as IDoor).ChangeRoom();
            }
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            if (playerProjectile is BombExplosionProjectile && CurrentObject.IsBombable)
                CurrentObject.IsAlive = false;
        }
        public void HandleEnemyCollision(IEnemy enemy, Direction direction) { }
        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction) { }
        public void HandleItemCollision(IItem item, Direction direction) { }
        public void HandleObjectCollision(IObject block, Direction direction)
        {
            if (CurrentObject.IsMovable)
            {
                switch (direction)
                {
                    case Direction.Down:
                        CurrentObject.HurtBoxLocation = new Vector2(CurrentObject.HurtBoxLocation.X, block.HurtBoxLocation.Y - CurrentObject.Height);
                        break;
                    case Direction.Up:
                        CurrentObject.HurtBoxLocation = new Vector2(CurrentObject.HurtBoxLocation.X, block.HurtBoxLocation.Y + block.Height);
                        break;
                    case Direction.Left:
                        CurrentObject.HurtBoxLocation = new Vector2(block.HurtBoxLocation.X + block.Width, CurrentObject.HurtBoxLocation.Y);
                        break;
                    case Direction.Right:
                        CurrentObject.HurtBoxLocation = new Vector2(block.HurtBoxLocation.X - CurrentObject.Width, CurrentObject.HurtBoxLocation.Y);
                        break;
                }
            }
        }
    }
}
