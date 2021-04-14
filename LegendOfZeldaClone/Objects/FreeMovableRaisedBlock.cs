﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class FreeMovableRaisedBlock: IObject
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public ObjectHeight BlockHeight => ObjectHeight.CanFlyOver;
        public bool IsBombable => false;
        public bool Alive { get; set; } = true;
        public Direction MovedDirection { get; set; } = Direction.None;

        private Vector2 startingLocation;
        private Vector2 nextLocation;
        private bool moved = false;
        private ISprite sprite;
        private readonly int height = 16;
        private readonly int width = 16;
        private Vector2 targetLocation;
        
        public FreeMovableRaisedBlock(Vector2 location)
        {
            sprite = ObjectSpriteFactory.Instance.CreateRaisedBlock();
            startingLocation = location;
            Location = startingLocation;
            targetLocation = startingLocation;
        }

        public void Update() 
        {
            

            Vector2 targetLocation = nextLocation;
            switch (MovedDirection)
            {
                case Direction.Down:
                    targetLocation += Height * Vector2.UnitY;
                    break;
                case Direction.Up:
                    targetLocation -= Height * Vector2.UnitY;
                    break;
                case Direction.Left:
                    targetLocation -= Width * Vector2.UnitX;
                    break;
                case Direction.Right:
                    targetLocation += Width * Vector2.UnitX;
                    break;
                case Direction.None:
                    break;
            }
            Vector2 displacement = targetLocation - Location;
            if (displacement.Length() == 0) return;

            displacement.Normalize();
            Location += displacement * LoZHelpers.BlockSpeed;
            moved = Location == targetLocation;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, Location);
        public void Die() => Alive = false;
        public void Reset()
        {
            MovedDirection = Direction.None;
            Location = startingLocation;
        }
    }
}
