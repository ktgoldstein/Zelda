using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZeldaClone.Enemies;
using System;
using LegendOfZeldaClone.Enemies.EnemyTypes.DodongoStatePattern;

namespace LegendOfZeldaClone.Enemy
{
    public class Dodongo : EnemyKernal
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
        public override int Health { get; set; } = 20;
        private Vector2 direction;
        public override Vector2 Direction { get { return direction; } set { direction = value; } }
        private bool _invincible;
        public override bool Invincible
        {
            get => _invincible;
            set
            {
                // aquamentusSprite = value ? EnemySpriteFactory.Instance.CreateDamagedAquamentusSprite() : EnemySpriteFactory.Instance.CreateAquamentusSprite();
                _invincible = value;
            }
        }

        public override bool Alive { get; set; }

        private ISprite dodongoSprite;
        private float speed = LoZHelpers.Scale(1);
        private int timer = 0;
        private int invincibleFrames = 0;
        private readonly int width;
        private readonly int height;
        private Vector2 knockbackForce = Vector2.Zero;
        private int something = 1;
        private bool stream;
        private int streamTimer = 0;
        private float angle = 0;
        private float rotationSpeed = 1;
        private IDodongoState state;
        public IDodongoState State { get { return state; } set { state = value; } }

        public Dodongo(GameStateMachine game, Vector2 location)
        {
            dodongoSprite = EnemySpriteFactory.Instance.CreateDodongoPhaseOneSprite();
            width = 24;
            height = 32;

            this.game = game;
            Location = location;
            Direction = Vector2.Zero;
            Invincible = false;
            Alive = true;
            AttackStat = 2;
            base.game = game;
            state = new PhaseOneIdle(this, game);
        }

        public override void Draw(SpriteBatch spritebatch) => dodongoSprite.Draw(spritebatch, Location);

        public override void Update()
        {
            dodongoSprite.Update();
            state.Update();
            Console.WriteLine(Invincible);
            if (Invincible)
            {
                invincibleFrames++;
                if (invincibleFrames > 20)
                {
                    Invincible = false;
                    invincibleFrames = 0;
                }
            }
        }
        public void Move()
        {
            Location += speed * Direction + knockbackForce;
        }

        private void SpitFireballs()
        {
            game.EnemyProjectilesQueue.Add(new Fireball(Location, new Vector2(-2, -1)));
            game.EnemyProjectilesQueue.Add(new Fireball(Location, new Vector2(-1, 0)));
            game.EnemyProjectilesQueue.Add(new Fireball(Location, new Vector2(-2, 1)));
        }

        public override void Knockback(Vector2 direction) { }

        public override void TakeDamage(Vector2 direction)
        {
            if (!Invincible)
            {
                Invincible = true;
                Health--;
                new BossTakingDamageSoundEffect().Play();
                if (Health <= 0)
                    Die();
                Knockback(direction);
            }
        }

        public override void Die()
        {
            if (!Alive) return;
            Alive = false;
            DropItem();
            game.EnemiesQueue.Add(new DeathAnimation(Location));
            game.KillCounter++;
        }
        public override void DropItem()
        {
            HeartContainer bossDrop = new HeartContainer(Location);
            game.Items.Add(bossDrop);
        }
    }
}
