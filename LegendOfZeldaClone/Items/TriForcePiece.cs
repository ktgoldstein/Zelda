﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class TriForcePiece : IItem
    {
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation { get { return Location; } }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite triforcePiece;
        private readonly int height;
        private readonly int width;

        public TriForcePiece(Vector2 location)
        {
            triforcePiece = ItemSpriteFactory.Instance.CreateTriforcePiece();
            Location = location;
            width = 10;
            height = 10;
            Alive = true;
        }

        public void Update() => triforcePiece.Update();
        public void Draw(SpriteBatch spriteBatch) => triforcePiece.Draw(spriteBatch, Location);
    }
}
