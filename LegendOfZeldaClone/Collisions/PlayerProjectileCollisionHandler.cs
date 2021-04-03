namespace LegendOfZeldaClone.Collisions
{
    class PlayerProjectileCollisionHandler : ICollisionHandler
    {
        public IPlayerProjectile CurrentPlayerProjectile { get; set; }

        public static PlayerProjectileCollisionHandler Instance { get; } = new PlayerProjectileCollisionHandler();
        private PlayerProjectileCollisionHandler() { }


        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            if (CurrentPlayerProjectile is BoomerangProjectile)
            {
                CurrentPlayerProjectile.Alive = false;
            }
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction) {}
        public void HandleEnemyCollision(IEnemy enemy, Direction direction)
        {
            if(!(CurrentPlayerProjectile is BoomerangProjectile || CurrentPlayerProjectile is SwordBeamExplosionProjectile
                || CurrentPlayerProjectile is ArrowImpactProjectile || CurrentPlayerProjectile is BombProjectile))
                CurrentPlayerProjectile.Die();
        }
        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction) {}
        public void HandleItemCollision(IItem item, Direction direction)
        {
            if (CurrentPlayerProjectile is SwordProjectile)
            {
                PlayerCollisionHandler.Instance.CurrentPlayer = (CurrentPlayerProjectile as SwordProjectile).player;
                PlayerCollisionHandler.Instance.HandleItemCollision(item, direction);
            }
            else if (CurrentPlayerProjectile is BoomerangProjectile)
            {
                if (item is FlashingRupee || item is BlueRupee || item is GoldRupee || item is Bomb || item is Key)
                {
                    PlayerCollisionHandler.Instance.CurrentPlayer = (CurrentPlayerProjectile as BoomerangProjectile).link;
                    PlayerCollisionHandler.Instance.HandleItemCollision(item, direction);
                }
            }
        }

        public void HandleObjectCollision(IObject block, Direction direction)
        {
            bool blockIsImpassable = block.BlockHeight == ObjectHeight.Impassable;
            bool projectileTypeIsStoppedByImpassableBlock = !(CurrentPlayerProjectile is BoomerangProjectile 
                                                        || CurrentPlayerProjectile is SwordBeamExplosionProjectile 
                                                        || CurrentPlayerProjectile is BombProjectile);
            if (projectileTypeIsStoppedByImpassableBlock && blockIsImpassable)
                CurrentPlayerProjectile.Die();
        }
    }
}
