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
            bool currentProjectileDisappearsUponEnemyCollision = !(CurrentPlayerProjectile is BoomerangProjectile
                                                || CurrentPlayerProjectile is SwordBeamExplosionProjectile
                                                || CurrentPlayerProjectile is ArrowImpactProjectile);
            if (currentProjectileDisappearsUponEnemyCollision)
                CurrentPlayerProjectile.Die();
        }
        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction) {}
        public void HandleItemCollision(IItem item, Direction direction)
        {
            if (CurrentPlayerProjectile is BoomerangProjectile)
            {
                BoomerangProjectile boomerang = CurrentPlayerProjectile as BoomerangProjectile;
                IPlayer player = boomerang.link;
                if (item is FlashingRupee)
                    player.Inventory.RupeesHeld += (int)RupeeValues.FlashingRupeeValue;
                else if (item is BlueRupee)
                    player.Inventory.RupeesHeld += (int)RupeeValues.FlashingRupeeValue;
                else if (item is GoldRupee)
                    player.Inventory.RupeesHeld += (int)RupeeValues.GoldRupeeValue;
                else if (item is Bomb)
                    player.Inventory.BombsHeld += LoZHelpers.BombPickUpNumber;
                else if (item is Key)
                    player.Inventory.KeysHeld++;
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
