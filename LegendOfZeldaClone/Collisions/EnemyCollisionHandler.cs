using Microsoft.Xna.Framework;
using LegendOfZeldaClone.Enemy;
using LegendOfZeldaClone.Players.LinkPlayer.LinkStates;

namespace LegendOfZeldaClone.Collisions
{
    class EnemyCollisionHandler : ICollisionHandler
    {
        public IEnemy CurrentEnemy { get; set; }
        public static EnemyCollisionHandler Instance { get; } = new EnemyCollisionHandler();
        private EnemyCollisionHandler() { }
        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            if (CurrentEnemy is Wallmaster)
                (CurrentEnemy as Wallmaster).game.GoToTheStart();

            if( player is LinkPlayer && ((LinkPlayer)player).linkState is LinkSpin)
            {
                Vector2 hitDirection = CurrentEnemy.Location - player.Location;
                hitDirection.Normalize();
                CurrentEnemy.TakeDamage(hitDirection);
            }
        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            bool projectileDealsEnemyDamage = !(playerProjectile is BombProjectile
                                                || playerProjectile is ArrowImpactProjectile
                                                || playerProjectile is SwordBeamExplosionProjectile);
            if (projectileDealsEnemyDamage)
            {
                Vector2 projectileDirection = CurrentEnemy.Location - playerProjectile.Location;
                projectileDirection.Normalize();
                CurrentEnemy.TakeDamage(projectileDirection);
            }
        }
        public void HandleEnemyCollision(IEnemy enemy, Direction direction) { }
        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction)
        {
            if (enemyProjectile is EnemyBoomerang boomerang && boomerang.goriya == CurrentEnemy)
                ((Goriya) CurrentEnemy).HasBoomerang = false;
        }
        public void HandleItemCollision(IItem item, Direction direction) { }
        public void HandleBlockCollision(IBlock block, Direction direction)
        {
            if (block.BlockHeight == ObjectHeight.CanWalkOver) return;
            if (CurrentEnemy is Wallmaster && block.IsBorder) return;
            if (CurrentEnemy is Keese && block.BlockHeight == ObjectHeight.CanFlyOver) return;

            switch (direction)
            {
                case Direction.Down:
                    CurrentEnemy.HurtBoxLocation = new Vector2(CurrentEnemy.HurtBoxLocation.X, block.HurtBoxLocation.Y - CurrentEnemy.Height);
                    break;
                case Direction.Up:
                    CurrentEnemy.HurtBoxLocation = new Vector2(CurrentEnemy.HurtBoxLocation.X, block.HurtBoxLocation.Y + block.Height);
                    break;
                case Direction.Left:
                    CurrentEnemy.HurtBoxLocation = new Vector2(block.HurtBoxLocation.X + block.Width, CurrentEnemy.HurtBoxLocation.Y);
                    break;
                case Direction.Right:
                    CurrentEnemy.HurtBoxLocation = new Vector2(block.HurtBoxLocation.X - CurrentEnemy.Width, CurrentEnemy.HurtBoxLocation.Y);
                    break;
            }

            if (CurrentEnemy is Aquamentus || CurrentEnemy is BladeTrap || block.IsBorder)
                CurrentEnemy.Direction = -LoZHelpers.DirectionToVector(direction);
            else
                CurrentEnemy.ChangeDirection(direction);
        }
    }
}
