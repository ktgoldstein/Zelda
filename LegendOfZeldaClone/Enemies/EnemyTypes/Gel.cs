using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZeldaClone.Enemies;
using System;

namespace LegendOfZeldaClone.Enemy
{
    public class Gel : EnemyKernal
    {
        public override  Vector2 Location { get; set; }
        public override Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public override int Width { get { return LoZHelpers.Scale(width); } }
        public override int Height { get { return LoZHelpers.Scale(height); } }
        public override int AttackStat { get; }
        public override int Health { get; set; } = LoZHelpers.GelHP;
        private Vector2 direction;
        public override Vector2 Direction { get { return direction;} set { direction = value;} }

        private ISprite gelSprite;
        private float speed = 2;
        private readonly int width;
        private readonly int height;
        private Vector2 knockbackForce = Vector2.Zero;
        public override bool Invincible { get; set; }
        public override bool Alive { get; set; }
        private int invincibleFrames = 0;
        private int timer = 0;

        public Gel(Vector2 location)
        {
            gelSprite = EnemySpriteFactory.Instance.CreateGelSprite();
            width = 8;
            height = 9;

            Location = location;
            direction.X = (float)LoZHelpers.random.NextDouble()*2 + -1;
            direction.Y = (float)LoZHelpers.random.NextDouble()*2 + -1;
            Alive = true;
            AttackStat = 1;
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            gelSprite.Draw(spritebatch, Location);
        }

        public override void Update()
        {
            gelSprite.Update();
            timer++;
            if(timer % 10 == 0)
            {
                direction.X = (float)LoZHelpers.random.NextDouble()*2 + -1;
                direction.Y = (float)LoZHelpers.random.NextDouble()*2 + -1;
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
        public override void DropItem() {}
    }
}
