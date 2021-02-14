using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemy
{
    public class Wallmaster : IEnemy
    {

        private ISprite wallmasterSprite;
        private Vector2 location = new Vector2(400, 120);
        private float speed = 2;
        private int direction = 1;

        public Wallmaster()
        {
            wallmasterSprite = EnemySpriteFactory.Instance.CreateWallmasterSprite();
        }
        public void Draw(SpriteBatch spritebatch)
        {
            wallmasterSprite.Draw(spritebatch, location);
        }

        public void Update()
        {
            wallmasterSprite.Update();

            location.Y += speed * direction;
            if (location.Y > 192)
            {
                direction = -1;
            }
            if (location.Y < 64)
            {
                direction = 1;
            }
        }
    }
}
