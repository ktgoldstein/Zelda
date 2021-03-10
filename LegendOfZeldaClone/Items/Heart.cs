﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Heart : IItem
    {
        private ISprite heart;
        private Vector2 location;
        private int height;
        private int width;

        public Heart(Vector2 location)
        {
            heart = ItemSpriteFactory.Instance.CreateHeart();
            this.location = location;
            this.width = 8;
            this.height = 8;
        }
        public void Update()
        {
            heart.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            heart.Draw(spriteBatch, location);
        }
    }
}