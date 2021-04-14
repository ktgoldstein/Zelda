namespace LegendOfZeldaClone.Collisions
{
    class BlockCollisionHandler : ICollisionHandler
    {
        public IBlock CurrentBlock { get; set; }

        public static BlockCollisionHandler Instance { get; } = new BlockCollisionHandler();
        private BlockCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            if (CurrentBlock is LockedDoor && player.Inventory.KeysHeld > 0 )
            {
                CurrentBlock.Die();
                new DoorUnlockingSoundEffect().Play();
                player.Inventory.KeysHeld--;
            }
            else if (CurrentBlock is MovableBlock)
            {
                MovableBlock target = (CurrentBlock as MovableBlock);
                if (target.MovedDirection == Direction.None)
                    target.MovedDirection = LoZHelpers.FlipDirection(direction);
            }
            else if (CurrentBlock is DoorKernel)
            {
                (CurrentBlock as DoorKernel).ChangeRoom();
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
        public void HandleBlockCollision(IBlock block, Direction direction)
        {
            if (CurrentBlock is MovableBlock movableBlock)
            {
                if (block is MovableBlockGoal)
                    movableBlock.HitTarget = true;
                else if (block.BlockHeight != ObjectHeight.CanWalkOver)
                    movableBlock.CancelMovement();
            }
        }
    }
}
