using Microsoft.Xna.Framework;
using LegendOfZeldaClone.Objects;
using LegendOfZeldaClone.Players.LinkPlayer.LinkStates;


namespace LegendOfZeldaClone.Collisions
{
    class ObjectCollisionHandler : ICollisionHandler
    {
        public IObject CurrentObject { get; set; }

        public static ObjectCollisionHandler Instance { get; } = new ObjectCollisionHandler();
        private ObjectCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            if( player is LinkPlayer && ((LinkPlayer)player).linkState is LinkSpin) return;
            if ((CurrentObject is LockedDoorUp || CurrentObject is LockedDoorDown ||
                CurrentObject is LockedDoorLeft || CurrentObject is LockedDoorRight) &&
                player.Inventory.KeysHeld > 0 )
            {
                CurrentObject.Die();
                new DoorUnlockingSoundEffect().Play();
                player.Inventory.KeysHeld--;
            }
            else if (CurrentObject is MovableRaisedBlock)
            {
                MovableRaisedBlock target = (CurrentObject as MovableRaisedBlock);
                if (target.MovedDirection == Direction.None)
                    target.MovedDirection = LoZHelpers.FlipDirection(direction);
            }
            else if (CurrentObject is IDoor)
            {
                (CurrentObject as IDoor).ChangeRoom();
            }
            else if(CurrentObject is PressurePlate)
            {
                (CurrentObject as PressurePlate).CloseDoors();
            }
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            if (playerProjectile is BombExplosionProjectile && CurrentObject.IsBombable)
                CurrentObject.Die();
        }
        public void HandleEnemyCollision(IEnemy enemy, Direction direction) { }
        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction) { }
        public void HandleItemCollision(IItem item, Direction direction) { }
        public void HandleObjectCollision(IObject block, Direction direction) { }
    }
}
