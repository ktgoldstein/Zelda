using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZeldaClone.Enemies;
using System;
using LegendOfZeldaClone.Enemies.EnemyTypes.DodongoStatePattern;
using System.Collections.Generic;

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
        public override int Health { get; set; } = 1;
        private int maxHealth;
        private float healthRatio;
        private Vector2 direction;
        public override Vector2 Direction { get { return direction; } set { direction = value; } }
        private bool _invincible;
        public override bool Invincible
        {
            get => _invincible;
            set
            {
                if(phase == 1)
                    dodongoSprite = value ? EnemySpriteFactory.Instance.CreateGreenDodongoDamaged() : EnemySpriteFactory.Instance.CreateDodongoSprite();
                else if ( phase == 2)
                    dodongoSprite = value ? EnemySpriteFactory.Instance.CreateBlueDodongoDamaged() : EnemySpriteFactory.Instance.CreateDodongoPhaseTwoSprite();
                else
                    dodongoSprite = value ? EnemySpriteFactory.Instance.CreateRedDodongoDamaged() : EnemySpriteFactory.Instance.CreateDodongoPhaseThreeSprite();
                _invincible = value;
            }
        }

        public override bool Alive { get; set; }

        private ISprite dodongoSprite;
        private ISprite hpBackground;
        private ISprite bossHP;
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
        private int phase = 1;
        private const float up = 3*48;
        private const float down = 3*48;
        private const float right = 4*48;
        private const float left = 6*48;
        private List<Vector2> destinations;
        private Vector2 center;
        private CustomBossThemeMusic bossTheme;
        public Dodongo(GameStateMachine game, Vector2 location)
        {
            dodongoSprite = EnemySpriteFactory.Instance.CreateDodongoPhaseOneSprite();
            hpBackground = EnemySpriteFactory.Instance.CreateBossHPBackground();
            bossHP = EnemySpriteFactory.Instance.CreateBossHP();
            width = 32;
            height = 16;
            maxHealth = Health;

            this.game = game;
            Location = location;
            Direction = Vector2.Zero;
            Invincible = false;
            Alive = true;
            AttackStat = 2;
            base.game = game;
            state = new PhaseOneIdle(this, game);
            center = location;
            destinations = new List<Vector2>()
            {
                center + new Vector2(-left, -up),
                center + new Vector2(-left, down),
                center + new Vector2(right, -up),
                center + new Vector2(right, down),
                center + new Vector2(0, down),
                center + new Vector2(0, -up),
                center + new Vector2(-left, 0),
                center + new Vector2(right, 0)
            };
            bossTheme = new CustomBossThemeMusic();
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            dodongoSprite.Draw(spritebatch, Location);
            hpBackground.Draw(spritebatch, center + new Vector2(-LoZHelpers.Scale(48),LoZHelpers.Scale(70)));
            ((EnemySprite)(bossHP)).HPDraw(healthRatio, spritebatch, center + new Vector2(-LoZHelpers.Scale(46),LoZHelpers.Scale(72)));
        }

        public override void Update()
        {
            bossTheme.Play();
            game.GameBackgroundMusic.StopPlaying();
            dodongoSprite.Update();
            state.Update();
            bossHP.Update();
            if (Invincible)
            {
                invincibleFrames++;
                if (invincibleFrames > 20)
                {
                    Invincible = false;
                    invincibleFrames = 0;
                }
            }
            healthRatio = 1f*Health/maxHealth;
        }
        public void Move()
        {
            Vector2 destination = center;
            foreach( Vector2 d in destinations)
            {
                if(Vector2.Distance(d, game.Player.Location) > Vector2.Distance(destination, game.Player.Location))
                {
                    destination = d;
                }
            }
            direction = destination - Location;
            direction.Normalize();
            Location += speed * direction + knockbackForce;
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
            if( healthRatio <= .7 && phase == 1)
            {
                dodongoSprite = EnemySpriteFactory.Instance.CreateDodongoPhaseTwoSprite();
                state = new PhaseTwoIdle(this, game);
                phase = 2;
            }
            if( healthRatio <= .2 && phase == 2)
            {
                dodongoSprite = EnemySpriteFactory.Instance.CreateDodongoPhaseThreeSprite();
                state = new PhaseThreeIdle(this, game);
                phase = 3;
            }
        }

        public override void Die()
        {
            if (!Alive) return;
            Alive = false;
            DropItem();
            game.EnemiesQueue.Add(new DeathAnimation(Location));
            game.KillCounter++;
            bossTheme.StopPlaying();
            game.GameBackgroundMusic = new DungeonThemeMusic();
            game.GameBackgroundMusic.Play();
        }
        public override void DropItem()
        {
            HeartContainer bossDrop = new HeartContainer(Location);
            game.Items.Add(bossDrop);
        }
    }
}
