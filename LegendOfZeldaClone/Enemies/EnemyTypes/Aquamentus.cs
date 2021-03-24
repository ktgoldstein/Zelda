using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Enemy
{
    class Aquamentus : IEnemy
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
        public int Health { get; set; } = LoZHelpers.AquamentusHP;
        private Vector2 direction;
        public Vector2 Direction { get { return direction;} set { direction = value;} }
        private bool _invincible;
        public bool Invincible
         {
            get => _invincible;
            set
            {
                if( value == true)
                {
                    aquamentusSprite = EnemySpriteFactory.Instance.CreateDamagedAquamentusSprite();
                }
                else{
                    aquamentusSprite = EnemySpriteFactory.Instance.CreateAquamentusSprite();
                }
                _invincible = value;
            }
         }

        public bool Alive { get; set; }

        private GameStateMachine game;
        private ISprite aquamentusSprite;
        private float speed = 2;
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
        }

        public void Draw(SpriteBatch spritebatch) => aquamentusSprite.Draw(spritebatch, Location);

        public void Update()
        {
            aquamentusSprite.Update();

            Location += speed * Direction + knockbackForce;
            knockbackForce *= .8f;
            if (Location.Y > 192)
            {
                direction = new Vector2(0,-1);
            }
            if (Location.Y < 64)
            {
                direction = new Vector2(0,1);
            }

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
        public void Knockback(Vector2 direction)
        {
            knockbackForce = direction * 10;
        }
    }
}
