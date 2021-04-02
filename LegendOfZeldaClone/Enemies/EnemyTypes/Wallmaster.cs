using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZeldaClone.Enemies;

namespace LegendOfZeldaClone.Enemy
{
    public class Wallmaster : EnemyKernal
    {
        public override Vector2 Location { get { return location; } set { location = value; } }
        private Vector2 location;
        public override Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public override int Width { get { return LoZHelpers.Scale(width); } }
        public override int Height { get { return LoZHelpers.Scale(height); } }
        public override int AttackStat { get; }
        public override int Health { get; set; } = LoZHelpers.WallmasterHP;
        private Vector2 direction;
        public override Vector2 Direction { get { return direction;} set { direction = value;} }
        private ISprite wallmasterSprite;
        private float speed = 3;
        private readonly int width;
        private readonly int height;
        private Vector2 knockbackForce = Vector2.Zero;
        public override bool Invincible { get; set; }
        public override bool Alive { get; set; }
        private int invincibleFrames = 0;

        public Wallmaster(GameStateMachine game, Vector2 location)
        {
            wallmasterSprite = EnemySpriteFactory.Instance.CreateWallmasterSprite();
            width = 16;
            height = 16;

            direction = game.Player.Location - Location;
            direction.Normalize();
            Location = location;
            Alive = true;
            AttackStat = 1;
            base.game = game;
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            wallmasterSprite.Draw(spritebatch, Location);
        }

        public override void Update()
        {
            Vector2 centerOfRoom = game.CurrentRoom.Offset + new Vector2(LoZHelpers.GameWidth/2, (LoZHelpers.GameHeight - LoZHelpers.HUDHeight)/2);
            wallmasterSprite.Update();
            if (Location.X - centerOfRoom.X > LoZHelpers.Scale(128))
            {
                Location = (centerOfRoom.X - LoZHelpers.Scale(128)) * Vector2.UnitX;
                direction = game.Player.Location - Location;
                direction.Normalize();
            }
            if (Location.X - centerOfRoom.X < -LoZHelpers.Scale(128))
            {
                Vector2 v = Location;
                v.X = centerOfRoom.X + LoZHelpers.Scale(128);
                Location = v;
                direction = game.Player.Location - Location;
                direction.Normalize();
            }
            if (Location.Y - centerOfRoom.Y > LoZHelpers.Scale(90))
            {
                Vector2 v = Location;
                v.Y = centerOfRoom.Y - LoZHelpers.Scale(90);
                Location = v;
                direction = game.Player.Location - Location;
                direction.Normalize();
            }
            if (Location.Y - centerOfRoom.Y < -LoZHelpers.Scale(90))
            {
                Vector2 v = Location;
                v.Y = centerOfRoom.Y + LoZHelpers.Scale(90);
                Location = v;
                direction = game.Player.Location - Location;
                direction.Normalize();
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
            new EnemyDyingSoundEffect().Play();
            Alive = false;
            game.EnemiesQueue.Add(new DeathAnimation(Location));
        }
    }
}
