﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class FireProjectile : IPlayerProjectile
    {
        private readonly ISprite sprite;
        private readonly int speed;
        private Vector2 velocity;
        private Vector2 location;
        private int lifeSpan;

        public FireProjectile(Vector2 startingLocation, Direction direction)
        {
            location = startingLocation;
            speed = 1;
            lifeSpan = 20;
            sprite = PlayerProjectileSpriteFactory.Instance.CreateFireSprite();
            DirectionBasedSetUp(direction);
        }

        public bool Update()
        {
            sprite.Update();
            if (lifeSpan == 0)
                return true;

            lifeSpan--;
            location += velocity;
            return false;
        }

        public void Draw(SpriteBatch spriteBatch) => sprite.Draw(spriteBatch, location);

        private void DirectionBasedSetUp(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    velocity = new Vector2(0, LoZHelpers.Scale(speed));
                    location += new Vector2(0, LoZHelpers.Scale(16));
                    break;
                case Direction.Up:
                    velocity = new Vector2(0, -LoZHelpers.Scale(speed));
                    location += new Vector2(0, -LoZHelpers.Scale(16));
                    break;
                case Direction.Left:
                    velocity = new Vector2(-LoZHelpers.Scale(speed), 0);
                    location += new Vector2(-LoZHelpers.Scale(16), 0);
                    break;
                case Direction.Right:
                    velocity = new Vector2(LoZHelpers.Scale(speed), 0);
                    location += new Vector2(LoZHelpers.Scale(16), 0);
                    break;
            }
        }
    }
}