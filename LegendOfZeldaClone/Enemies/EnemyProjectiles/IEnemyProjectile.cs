﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface IEnemyProjectile
    {
        public Vector2 Location { get; set; }
        public int Width { get; }
        public int Height { get; }
        public void Update();
        public void Draw(SpriteBatch spriteBatch);
    }
}
