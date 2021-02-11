using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemy
{
    class Goriya : IEnemy
    {
      
        private ISprite goriyaSprite;
        private Vector2 location = new Vector2(400, 120);
        private float speed = 3;
        private Vector2 direction = new Vector2(0, 1);
        private int timer = 0;
        private Boomerang boomerang;

        public Goriya()
        {
            goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite();
        }
        public void Draw(SpriteBatch spritebatch)
        {
            goriyaSprite.Draw(spritebatch, location);
            boomerang.Draw(spritebatch);
        }

        public void Update()
        {
            goriyaSprite.Update();
            //boomerang.Update();

            location.Y += speed * direction.Y;
            location.X += speed * direction.X;
            if(timer % 20 == 0)
            {
                ThrowBoomerang();
            }
            if (timer == 0)
            {
                direction = Vector2.UnitY;
                goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite();

            }
            else if (timer == 20)
            {
                direction = -Vector2.UnitX;
                goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaLeftSprite();
            }
            else if (timer == 40)
            {
                direction = -Vector2.UnitY;
                goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaUpSprite();
            }
            else if (timer == 60)
            {
                direction = Vector2.UnitX;
                goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaRightSprite();
            }
            timer++;
            if (timer > 79)
            {
                timer = 0;
            }
        }

        private void ThrowBoomerang()
        {
            boomerang = new Boomerang(this.location, this.direction);
        }
    }
}
