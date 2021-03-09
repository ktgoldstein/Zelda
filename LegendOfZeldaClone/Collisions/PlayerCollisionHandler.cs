﻿using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class PlayerCollisionHandler : ICollisionHandler
    {
        public IPlayer CurrentPlayer { get; set; }

        public static PlayerCollisionHandler Instance { get; } = new PlayerCollisionHandler();
        private PlayerCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player, Direction direction) { } // Nothing will happen for now (only one player)

        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction) { } // No collision

        public void HandleEnemyCollision(IEnemy enemy, Direction direction)
        {
            CurrentPlayer.Damage(1, direction);
        }

        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction)
        {
            CurrentPlayer.Damage(1, direction);
        }

        public void HandleItemCollision(IItem item, Direction direction) 
        {
            //item should be added to player inventory
        }

        public void HandleObjectCollision(IObject block, Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    CurrentPlayer.HurtBoxLocation = new Vector2(CurrentPlayer.HurtBoxLocation.X, block.HurtBoxLocation.Y - CurrentPlayer.Height);
                    break;
                case Direction.Up:
                    CurrentPlayer.HurtBoxLocation = new Vector2(CurrentPlayer.HurtBoxLocation.X, block.HurtBoxLocation.Y + block.Height);
                    break;
                case Direction.Left:
                    CurrentPlayer.HurtBoxLocation = new Vector2(block.HurtBoxLocation.X + block.Width, CurrentPlayer.HurtBoxLocation.Y);
                    break;
                case Direction.Right:
                    CurrentPlayer.HurtBoxLocation = new Vector2(block.HurtBoxLocation.X - CurrentPlayer.Width, CurrentPlayer.HurtBoxLocation.Y);
                    break;
            }
        }

        public void HandleBoundaryCollision(Boundary boundary, Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    CurrentPlayer.HurtBoxLocation = new Vector2(CurrentPlayer.HurtBoxLocation.X, boundary.Location.Y + boundary.Height - CurrentPlayer.Height);
                    break;
                case Direction.Up:
                    CurrentPlayer.HurtBoxLocation = new Vector2(CurrentPlayer.HurtBoxLocation.X, boundary.Location.Y);
                    break;
                case Direction.Left:
                    CurrentPlayer.HurtBoxLocation = new Vector2(boundary.Location.X, CurrentPlayer.HurtBoxLocation.Y);
                    break;
                case Direction.Right:
                    CurrentPlayer.HurtBoxLocation = new Vector2(boundary.Location.X + boundary.Width - CurrentPlayer.Width, CurrentPlayer.HurtBoxLocation.Y);
                    break;
            }
        }
    }
}

