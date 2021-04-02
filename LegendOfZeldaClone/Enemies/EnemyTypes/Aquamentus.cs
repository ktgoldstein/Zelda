using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZeldaClone.Enemies;

namespace LegendOfZeldaClone.Enemy
{
    public class Aquamentus : EnemyKernal
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
        public override int Health { get; set; } = LoZHelpers.AquamentusHP;
        private Vector2 direction;
        public override Vector2 Direction { get { return direction;} set { direction = value;} }
        private bool _invincible;
        public override bool Invincible
         {
            get => _invincible;
            set
            {
                aquamentusSprite = value ? EnemySpriteFactory.Instance.CreateDamagedAquamentusSprite() : EnemySpriteFactory.Instance.CreateAquamentusSprite();                
                _invincible = value;
            }
         }

        public override bool Alive { get; set; }

        private ISprite aquamentusSprite;
        private float speed = LoZHelpers.Scale(1);
        private int timer = 0;
        private int invincibleFrames = 0;
        private readonly int width;
        private readonly int height;
        private Vector2 knockbackForce = Vector2.Zero;

        public Aquamentus(GameStateMachine game, Vector2 location)
        {
            aquamentusSprite = EnemySpriteFactory.Instance.CreateAquamentusSprite();
            width = 24;
            height = 32;

            this.game = game;
            Location = location;
            Direction = new Vector2(0,1);
            Invincible = false;
            Alive = true;
            AttackStat = 2;
            base.game = game;
        }

        public override void Draw(SpriteBatch spritebatch) => aquamentusSprite.Draw(spritebatch, Location);

        public override void Update()
        {
            aquamentusSprite.Update();

            Location += speed * Direction + knockbackForce;
            knockbackForce *= .8f;

            timer++;
            if(timer == 60)
            {
                SpitFireballs();
                timer = 0;
            }

            if(Invincible)
            {
                invincibleFrames++;
                if(invincibleFrames > 20)
                {
                    Invincible = false;
                    invincibleFrames = 0;
                }
            }
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
            Alive = false;
            DropItem();
            game.EnemiesQueue.Add(new DeathAnimation(Location));
        }
    }
}
