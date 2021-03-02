﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZeldaClone
{
    public interface ICollisionHandler
    {
        public void HandlePlayerCollision(IPlayer player);
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile);
        public void HandleEnemyCollision(IEnemy enemy);
        public void HandleEnemyProjectileCollision(IEnemy enemyProjectile);
        public void HandleItemCollision(IItem item);
        public void HandleBlockCollision(IObject block);
        public void HandleBoundaryCollision();
    }
}

