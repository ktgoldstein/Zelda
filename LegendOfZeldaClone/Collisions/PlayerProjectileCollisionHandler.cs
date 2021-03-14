﻿namespace LegendOfZeldaClone.Collisions
{
    class PlayerProjectileCollisionHandler : ICollisionHandler
    {
        public IPlayerProjectile CurrentPlayerProjectile { get; set; }

        public static PlayerProjectileCollisionHandler Instance { get; } = new PlayerProjectileCollisionHandler();
        private PlayerProjectileCollisionHandler() { }


        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            //should only be for boomerangs (don't want bombs to disappear if walked across)
            if (CurrentPlayerProjectile is BoomerangProjectile)
            {
                CurrentPlayerProjectile.Alive = false;
            }
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            //nothing will happen
        }
        public void HandleEnemyCollision(IEnemy enemy, Direction direction)
        {
            bool projectileDisappearsUponEnemyCollision = !(CurrentPlayerProjectile is BoomerangProjectile || CurrentPlayerProjectile is SwordBeamExplosionProjectile || CurrentPlayerProjectile is ArrowImpactProjectile);
            if (projectileDisappearsUponEnemyCollision)
            {
                if (CurrentPlayerProjectile is SwordBeamProjectile)
                {
                    SwordBeamProjectile swordBeam = CurrentPlayerProjectile as SwordBeamProjectile;
                    swordBeam.SpawnSwordExplosion();
                }
                else if (CurrentPlayerProjectile is ArrowProjectile)
                {
                    ArrowProjectile arrow = CurrentPlayerProjectile as ArrowProjectile;
                    arrow.SpawnArrowExplosion();
                }
                else
                {
                    CurrentPlayerProjectile.Alive = false;
                }
            }
        }
        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction)
        {
            //nothing will happen?
        }
        public void HandleItemCollision(IItem item, Direction direction)
        {
            if (CurrentPlayerProjectile is BoomerangProjectile)
            {
                BoomerangProjectile boomerang = CurrentPlayerProjectile as BoomerangProjectile;
                IPlayer player = boomerang.link;
                if (item is FlashingRupee || item is BlueRupee || item is GoldRupee)
                    player.Inventory.RupeesHeld++;
                else if (item is Bomb)
                    player.Inventory.BombsHeld++;
                else if (item is Key)
                    player.Inventory.KeysHeld++;
                
            }
        }

        public void HandleObjectCollision(IObject block, Direction direction)
        {

            bool collidesWithImpassableBlocks = !((CurrentPlayerProjectile is BoomerangProjectile || CurrentPlayerProjectile is SwordBeamExplosionProjectile));
            collidesWithImpassableBlocks &= !(CurrentPlayerProjectile is BombProjectile);
            bool blockIsImpassable = block.BlockHeight == ObjectHeight.Impassable;

            if ((collidesWithImpassableBlocks && blockIsImpassable))
            {
                if (CurrentPlayerProjectile is SwordBeamProjectile)
                {
                    SwordBeamProjectile swordBeam = CurrentPlayerProjectile as SwordBeamProjectile;
                    swordBeam.SpawnSwordExplosion();
                }
                else if (CurrentPlayerProjectile is ArrowProjectile)
                {
                    ArrowProjectile arrow = CurrentPlayerProjectile as ArrowProjectile;
                    arrow.SpawnArrowExplosion();
                }
                else
                {
                    CurrentPlayerProjectile.Alive = false;
                }
            }
        }
    }
}
