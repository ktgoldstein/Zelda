using Microsoft.Xna.Framework;
using LegendOfZeldaClone.Objects;



namespace LegendOfZeldaClone.Collisions
{
    class BlockCollisionHandler : ICollisionHandler
    {
        public IBlock CurrentBlock { get; set; }

        public static BlockCollisionHandler Instance { get; } = new BlockCollisionHandler();
        private BlockCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            if ((CurrentBlock is LockedDoorUp || CurrentBlock is LockedDoorDown ||
                CurrentBlock is LockedDoorLeft || CurrentBlock is LockedDoorRight) &&
                player.Inventory.KeysHeld > 0 )
            {
                CurrentBlock.Die();
                new DoorUnlockingSoundEffect().Play();
                player.Inventory.KeysHeld--;
            }
            else if (CurrentBlock is MovableRaisedBlock)
            {
                MovableRaisedBlock target = (CurrentBlock as MovableRaisedBlock);
                if (target.MovedDirection == Direction.None)
                    target.MovedDirection = LoZHelpers.FlipDirection(direction);
            }
            else if (CurrentBlock is IDoor)
            {
                (CurrentBlock as IDoor).ChangeRoom();
            }
            else if(CurrentBlock is PressurePlate)
            {
                (CurrentBlock as PressurePlate).CloseDoors();
            }
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            if (playerProjectile is BombExplosionProjectile && CurrentBlock.IsBombable)
                CurrentBlock.Die();
        }
        public void HandleEnemyCollision(IEnemy enemy, Direction direction) { }
        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction) { }
        public void HandleItemCollision(IItem item, Direction direction) { }
        public void HandleBlockCollision(IBlock block, Direction direction) { }
    }
}
