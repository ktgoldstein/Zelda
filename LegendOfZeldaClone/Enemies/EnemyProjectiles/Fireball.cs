using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone.Enemy
{
    class Fireball : IEnemyProjectile
    {
        public bool Alive { get; set; }
        public int AttackStat { get; }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public int Width { get { return LoZHelpers.Scale(width); } }
        public int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite fireballSprite;
        private Vector2 direction;
        private float speed = 5;
        private readonly int width;
        private readonly int height;
        private int lifespan;
        public bool reflected = false;
        private bool homing;
        private IGameObject link;
        private int prepareTime = 30;
        private int prepareWallTimer;
        private bool wallAttack;
        private Vector2? target;
        private Vector2? moveDirection;
        private Vector2 startLocation;

        public Fireball(Vector2 location, Vector2 direction, int lifespan = -1, bool homing = false, IGameObject link = null, bool wallAttack = false, Vector2? target = null, Vector2? moveDirection = null)
        {
            fireballSprite = EnemySpriteFactory.Instance.CreateFireballSprite(Color.White);
            width = 8;
            height = 10;

            Alive = true;
            AttackStat = 1;
            Location = location;
            this.direction = direction;
            if(direction != Vector2.Zero) this.direction.Normalize();
            this.lifespan = lifespan;
            this.homing = homing;
            this.link = link;
            this.wallAttack = wallAttack;
            this.target = target;
            this.moveDirection = moveDirection;
            prepareWallTimer = prepareTime;
            startLocation = location;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            fireballSprite.Draw(spritebatch, Location);
        }

        public void Update()
        {
            fireballSprite.Update();
            if(wallAttack && !reflected)
            {
                if(prepareWallTimer > 0)
                {
                    prepareWallTimer--;
                    Location = Vector2.Lerp(startLocation, (Vector2)target,  1-1f*prepareWallTimer/prepareTime);
                }
                else
                {
                    Location += speed*(Vector2)moveDirection;
                }
            }
            if(homing && !reflected)
            {
                Vector2 linkDirection = link.Location - Location;
                linkDirection.Normalize();
                direction = Vector2.Lerp(direction, linkDirection, .02f);
            }
            if(!wallAttack || reflected) Location += direction * speed;
            lifespan--;
            if(lifespan == 0) Die();
        }

        public void Die() => Alive = false;
        public void Reflect(Vector2 direction)
        {
            direction.Normalize();
            this.direction = direction;
            reflected = true;
            fireballSprite = EnemySpriteFactory.Instance.CreateFireballSprite(Color.Blue);
        }
    }
}
