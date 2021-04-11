using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZeldaClone.Enemies;
using System;
using System.Collections.Generic;

namespace LegendOfZeldaClone.Enemy
{
    class Stalfos : EnemyKernal
    {
        public override Vector2 Location { get; set; }
        public override Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public override int Width { get { return LoZHelpers.Scale(width); } }
        public override int Height { get { return LoZHelpers.Scale(height); } }
        public override int AttackStat { get; }
        public override int Health { get; set; } = LoZHelpers.StalfosHP;
        private Vector2 direction;
        public override Vector2 Direction { get { return direction;} set { direction = value;} }
        private ISprite stalfosSprite;
        private float speed = 3;
        private readonly int width;
        private readonly int height;
        private Vector2 knockbackForce = Vector2.Zero;
        public override  bool Invincible { get; set; }
        public override  bool Alive { get; set; }
        private int invincibleFrames = 0;
        private int timer = 0;

        public Stalfos(GameStateMachine game, Vector2 location)
        {
            stalfosSprite = EnemySpriteFactory.Instance.CreateStalfosSprite();
            width = 15;
            height = 16;

            Location = location;
            direction.X = (float)LoZHelpers.random.NextDouble()*2 + -1;
            direction.Y = (float)LoZHelpers.random.NextDouble()*2 + -1;
            Alive = true;
            AttackStat = 1;
            base.game = game;
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            stalfosSprite.Draw(spritebatch, Location);
        }

        public override void Update()
        {
            stalfosSprite.Update();
            base.Update();
            timer++;
            if(timer == 60)
            {
                double num = LoZHelpers.random.NextDouble();
                if( num < 0.25)
                {
                    direction = Vector2.UnitX;
                }
                else if ( num >= 0.25 && num < 0.5)
                {
                    direction = -Vector2.UnitX;
                }
                else if( num >= 0.5 && num < 0.75)
                {
                    direction = Vector2.UnitY;
                }
                else
                {
                    direction = -Vector2.UnitY;
                }
                timer = 0;
            }
            Location += speed * direction + knockbackForce;
            knockbackForce *= .8f;
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
        public override void Knockback(Vector2 direction)
        {
            knockbackForce = direction * 10;
        }
        public override void TakeDamage(Vector2 direction)
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
        public override void Die()
        {
            if (!Alive) return;
            new EnemyDyingSoundEffect().Play();
            Alive = false;
            game.EnemiesQueue.Add(new DeathAnimation(Location));
            game.KillCounter++;
            DropItem();
        }
    }
}
