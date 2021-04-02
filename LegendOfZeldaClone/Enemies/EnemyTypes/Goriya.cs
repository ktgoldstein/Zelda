using LegendOfZeldaClone.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone.Enemy
{
    public class Goriya : EnemyKernal
    {
        public override Vector2 Location { get; set; }
        public override Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public override int Width { get { return LoZHelpers.Scale(width); } }
        public override int Height { get { return LoZHelpers.Scale(height); } }
        public bool HasBoomerang { get; set; }
        public override int AttackStat { get; }
        public override int Health { get; set; } = LoZHelpers.GoriyaHP;
        public override Vector2 Direction { get { return direction;} set { direction = value;} }
        private int invincibleFrames = 0;

        private ISprite goriyaSprite;
        private int speed = LoZHelpers.Scale(2);
        private Vector2 direction = new Vector2(0, 1);
        private int timer = LoZHelpers.random.Next()%80;
        private readonly int width;
        private readonly int height;
        private Vector2 knockbackForce = Vector2.Zero;
        public override bool Invincible { get; set; }
        public override bool Alive { get; set; }
        private Vector2 previousDirection;

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
            base.game = game;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            goriyaSprite.Draw(spritebatch, Location);
        }

        public override void Update()
        {
            goriyaSprite.Update();
            base.Update();

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
            if( direction != previousDirection )
            {
                if( direction.X > 0)
                {
                    goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaRightSprite();
                }
                if ( direction.X < 0)
                {

                    goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaLeftSprite();
                }
                if ( direction.Y < 0)
                {

                    goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaUpSprite();
                }
                if( direction.Y > 0)
                {
                    goriyaSprite = EnemySpriteFactory.Instance.CreateGoriyaDownSprite();
                }
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
            previousDirection = direction;
        }

        private void ThrowBoomerang(Vector2 direction)
        {
            if (!HasBoomerang)
            {
                game.EnemyProjectilesQueue.Add(new EnemyBoomerang(Location + direction * Width, direction, this));
                HasBoomerang = true;
            }
        }
        public override void Knockback(Vector2 direction)
        {
            knockbackForce = direction * 10;
        }
    }
}
