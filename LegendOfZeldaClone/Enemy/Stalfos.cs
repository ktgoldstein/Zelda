using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemy
{
    class Stalfos : IEnemy
    {
        private ISprite stalfosSprite;
        private Vector2 location;
        private float speed = 2;
        private int direction = 1;

        public Stalfos(Vector2 location)
        {
            stalfosSprite = EnemySpriteFactory.Instance.CreateStalfosSprite();
            this.location = location;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            stalfosSprite.Draw(spritebatch, location);
        }

        public void Update()
        {
            stalfosSprite.Update();

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
