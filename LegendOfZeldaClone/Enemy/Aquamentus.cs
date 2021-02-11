using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemy
{
    class Aquamentus : IEnemy
    {
        private ISprite aquamentusSprite;
        private Vector2 location = new Vector2(400, 120);
        private float speed = 2;
        private int direction = 1;
        private int timer = 0;
        private List<Fireball> fireballs = new List<Fireball>();
    
        public Aquamentus()
        {
            aquamentusSprite = EnemySpriteFactory.Instance.CreateAquamentusSprite();
        }

        public void Draw(SpriteBatch spritebatch)
        {
            aquamentusSprite.Draw(spritebatch, location);
            foreach (Fireball fireball in fireballs)
            {
                fireball.Draw(spritebatch);
            }
        }
        public void Update()
        {
            aquamentusSprite.Update();
            
            foreach (Fireball fireball in fireballs)
            {
                fireball.Update();
            }

            location.Y += speed * direction;
            if (location.Y > 192)
            {
                direction = -1;
            }
            if (location.Y < 64)
            {
                direction = 1;
            }

            timer++;
            if(timer == 60)
            {
                SpitFireballs();
                timer = 0;
            }
        }

        private void SpitFireballs()
        {
            fireballs.Add(new Fireball(this.location, new Vector2(-2, -1)));
            fireballs.Add(new Fireball(this.location, new Vector2(-1, 0)));
            fireballs.Add(new Fireball(this.location, new Vector2(-2, 1)));
        }
    }
}
