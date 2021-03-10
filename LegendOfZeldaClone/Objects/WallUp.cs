﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class WallUp : IObject
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }

        private ISprite lockedDoorUp;
        private readonly int height;
        private readonly int width;

        public WallUp(Vector2 location)
        {
            lockedDoorUp = ObjectSpriteFactory.Instance.CreateWallFaceUp();
            Location = location;
            height = 32;
            width = 32;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            lockedDoorUp.Draw(spriteBatch, Location);
        }
    }
}