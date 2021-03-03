﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZeldaClone.Objects
{
    public class BlueDragonStatue : IObject
    {
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public Vector2 Location { get; set; }

        private ISprite blueDragonStatue;
        private readonly int height;
        private readonly int width;

        public BlueDragonStatue(Vector2 location)
        {
            blueDragonStatue = ObjectSpriteFactory.Instance.CreateBlueDragonStatue();
            Location = location;
            height = 16;
            width = 16;
        }
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            blueDragonStatue.Draw(spriteBatch, Location);
        }
    }
}