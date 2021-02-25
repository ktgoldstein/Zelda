using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZeldaClone
{
    public interface ICollisionHandler
    {
        public void HandlePlayerCollision(IPlayer player);
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile);
        public void HandleEnemyCollision(IEnemy enemy);
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile);
        public void HandleItemCollision(ISprite item); //tentative; IItem interface?
        public void HandleBlockCollision(ISprite block); //tentative; IBlock interface?
        public void HandleBoundaryCollision();
    }
}

