﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Enemy
{
    public class Keese : IEnemy
    {
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public int AttackStat { get; }
        public int Health { get; set; } = LoZHelpers.KeeseHP;
        private Vector2 direction;
        public Vector2 Direction { get { return direction;} set { direction = value;} }
        private ISprite keeseSprite;
        private float speed = 2;
        private readonly int width;
        private readonly int height;
        private Vector2 knockbackForce = Vector2.Zero;
        public bool Alive { get; set; }
        public bool Invincible { get; set; }
        private int invincibleFrames = 0;
        public Keese(Vector2 location)
        {
            keeseSprite = EnemySpriteFactory.Instance.CreateKeeseSprite();
            width = 16;
            height = 8;

            Location = location;
            Direction = Vector2.UnitY;
            Alive = true;
            AttackStat = 1;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            keeseSprite.Draw(spritebatch, Location);
        }

        public void Update()
        {
            keeseSprite.Update();

            Location += speed * direction + knockbackForce;
            knockbackForce *= .8f;
            if (Location.Y > 192)
            {
                direction = new Vector2(0, -1);
            }
            if (Location.Y < 64)
            {
                direction = new Vector2(0, 1);
            }
            if(Invincible)
            {
                invincibleFrames++;
                if(invincibleFrames > 10)
                {
                    Invincible = false;
                    invincibleFrames = 0;
                }
            }
        }
        public void Knockback(Vector2 direction)
        {
            knockbackForce = direction * 10;
        }
        public void TakeDamage(Vector2 direction)
        {
            if (!Invincible)
            {
                Invincible = true;
                Health--;
                new EnemyTakingDamageSoundEffect().Play();
                if (Health <= 0)
                    Die();
                Knockback(direction);
            }

        }
        public void Die()
        {
            new EnemyDyingSoundEffect().Play();
            Alive = false;
        }
    }
}
