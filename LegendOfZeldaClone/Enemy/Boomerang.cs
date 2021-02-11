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
        private float speed = 5;

        public Boomerang(Vector2 location, Vector2 direction)
        {
            boomerangSprite = EnemySpriteFactory.Instance.createBoomerangSprite();
            this.location = location;
            this.direction = direction;
            this.direction.Normalize();
        }
        public void Draw(SpriteBatch spritebatch)
        {
            boomerangSprite.Draw(spritebatch, location);
        }

        public void Update()
        {
            boomerangSprite.Update();
            location += direction * speed;
        }
    }
}
