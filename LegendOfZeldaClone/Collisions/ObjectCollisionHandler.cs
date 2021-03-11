﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Collisions
{
    class ObjectCollisionHandler : ICollisionHandler
    {
        public IObject CurrentObject { get; set; }

        public static ObjectCollisionHandler Instance { get; } = new ObjectCollisionHandler();
        private ObjectCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            //locked doors should open if the player has a key



            if (CurrentObject is Objects.LockedDoorUp || CurrentObject is Objects.LockedDoorDown ||
                CurrentObject is Objects.LockedDoorLeft || CurrentObject is Objects.LockedDoorRight)
            {
                //add condition here: if player has key in their inventory
                if (player.Inventory.KeysHeld > 0)
                {
                    //delete the LockedDoor object to reveal the unlocked version underneath
                }
            }

            else if (CurrentObject.IsMovable)
            {
                switch (direction)
                {
                    case Direction.Down:
                        CurrentObject.Location = new Vector2(CurrentObject.Location.X, CurrentObject.Location.Y - 1);
                        break;
                    case Direction.Up:
                        CurrentObject.Location = new Vector2(CurrentObject.Location.X, CurrentObject.Location.Y + 1);
                        break;
                    case Direction.Left:
                        CurrentObject.Location = new Vector2(CurrentObject.Location.X + 1, CurrentObject.Location.Y);
                        break;
                    case Direction.Right:
                        CurrentObject.Location = new Vector2(CurrentObject.Location.X - 1, CurrentObject.Location.Y);
                        break;
                }
            }
            


        }
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            if (playerProjectile is BombExplosionProjectile && CurrentObject.IsBombable)
            {
               
                    //get rid of object on top of base object
            }
        }
        public void HandleEnemyCollision(IEnemy enemy, Direction direction)
        {
            //nothing will happen
        }
        public void HandleEnemyProjectileCollision(IEnemyProjectile enemyProjectile, Direction direction)
        {
            //nothing will happen
        }
        public void HandleItemCollision(IItem item, Direction direction)
        {
            //nothing will happen
        }

        public void HandleObjectCollision(IObject block, Direction direction)
        {
            //movable blocks should stop when they hit other blocks
            if (CurrentObject.IsMovable)
            {
                if (direction == Direction.Down || direction == Direction.Up)
                {
                    CurrentObject.Location = new Vector2(CurrentObject.Location.X, block.Location.Y);
                }
                else if (direction == Direction.Right || direction == Direction.Left)
                {
                    CurrentObject.Location = new Vector2(block.Location.X, CurrentObject.Location.Y);
                }
            }



        }
        public void HandleBoundaryCollision(Boundary boundary, Direction direction)
        {

            if (direction == Direction.Down || direction == Direction.Up)
            {
                CurrentObject.Location = new Vector2(CurrentObject.Location.X, boundary.Location.Y);
            }
            else if (direction == Direction.Right || direction == Direction.Left)
            {
                CurrentObject.Location = new Vector2(boundary.Location.X, CurrentObject.Location.Y);
            }
        }
    }
}
