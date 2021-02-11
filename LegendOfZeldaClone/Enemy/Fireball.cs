using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemy
{
    class Fireball : IEnemy
    {

        private ISprite fireballSprite;
        private Vector2 location;
        private Vector2 direction;
        private float speed = 5;
        public Fireball(Vector2 location, Vector2 direction)
        {
            fireballSprite = EnemySpriteFactory.Instance.CreateFireballSprite();
            this.location = location;
            this.direction = direction;
            this.direction.Normalize();
        }
        public void Draw(SpriteBatch spritebatch)
        {
            fireballSprite.Draw(spritebatch, location);
        }

        public void Update()
        {
            fireballSprite.Update();
            location += direction * speed;
        }
    }
}
