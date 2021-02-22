using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemy
{
    class Boomerang : IEnemy
    {
        private ISprite boomerangSprite;
        private Vector2 location;
        private Vector2 direction;
        private float speed = 10;
        private int timer = 0;
        private Goriya goriya;

        public Boomerang(Vector2 location, Vector2 direction, Goriya goriya)
        {
            boomerangSprite = EnemySpriteFactory.Instance.createBoomerangSprite();
            this.location = location;
            this.direction = direction;
            this.direction.Normalize();
            this.goriya = goriya;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            boomerangSprite.Draw(spritebatch, location);
        }

        public void Update()
        {
            timer++;
            if(timer > 20)
            {
                direction = goriya.GetGoriyaLocation() - location;
                direction.Normalize();
            }
            
            location += direction * speed;
            if (Vector2.Distance(location, goriya.GetGoriyaLocation()) < 5)
            {
                goriya.CatchBoomerang();
            }
            boomerangSprite.Update();
        }
    }
}
