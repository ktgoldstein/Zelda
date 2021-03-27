﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Enemy
{
    public class Goriya : IEnemy
    {
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }
        public bool HasBoomerang { get; set; }
        public int AttackStat { get; }
        public int Health { get; set; } = LoZHelpers.GoriyaHP;
        public Vector2 Direction { get { return direction;} set { direction = value;} }
        private int invincibleFrames = 0;

        private LegendOfZeldaDungeon game;
        private ISprite goriyaSprite;
        private int speed = LoZHelpers.Scale(2);
        private Vector2 direction = new Vector2(0, 1);
        private int timer = 0;
        private readonly int width;
        private readonly int height;
        private Vector2 knockbackForce = Vector2.Zero;
        public bool Invincible { get; set; }
        public bool Alive { get; set; }

        public Goriya(LegendOfZeldaDungeon game, Vector2 location)
        {
            HasBoomerang = false;
            goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite();
            width = 13;
            height = 16;

            this.game = game;
            Location = location;
            Invincible = false;
            Alive = true;
            AttackStat = 1;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            goriyaSprite.Draw(spritebatch, Location);
        }

        public void Update()
        {
            goriyaSprite.Update();

            Location += speed * direction + knockbackForce;
            knockbackForce *= .8f;
            if(timer % 20 == 0)
                ThrowBoomerang(direction);

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

        private void ThrowBoomerang(Vector2 direction)
        {
            if (!HasBoomerang)
            {
                game.EnemyProjectilesQueue.Add(new EnemyBoomerang(Location + direction * Width, direction, this));
                HasBoomerang = true;
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
