using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Collisions
{
    class ObjectCollisionHandler : ICollisionHandler
    {
        public IObject CurrentObject { get; set; }
        public LegendOfZeldaDungeon game; 

        public static ObjectCollisionHandler Instance { get; } = new ObjectCollisionHandler();
        private ObjectCollisionHandler() { }

        public void HandlePlayerCollision(IPlayer player, Direction direction)
        {
            //locked doors should open if the player has a key
            //movable blocks should move
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
        public void HandlePlayerProjectileCollision(IPlayerProjectile playerProjectile, Direction direction)
        {
            //bombs should blow up walls with hidden rooms
            if (playerProjectile is BombProjectile)
            {

                //bombable wall will be the object type that ends up going here
                if(CurrentObject is Objects.DarkBlock)
                {
                    //change object type to doorway; how?
                }

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
        }
        public void HandleBoundaryCollision(Boundary boundary, Direction direction)
        {
            //movable blocks should stop
        }
    }
}
