using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemy
{
    public class Keese : IEnemy
    {

        private ISprite keeseSprite;
        private Vector2 location;
        private float speed = 2;
        private int direction = 1;

        public Keese(Vector2 location)
        {
            keeseSprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
            this.location = location;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            keeseSprite.Draw(spritebatch, location);
        }

        public void Update()
        {
            keeseSprite.Update();

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
