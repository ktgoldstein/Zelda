using LegendOfZeldaClone.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone.Enemy
{
    public class BladeTrap : EnemyKernal
    {
        public override Vector2 Location { get; set; }
        private Vector2 originalLocation;
        private IPlayer link;
        public override Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }
        public override int Width { get { return LoZHelpers.Scale(width); } }
        public override int Height { get { return LoZHelpers.Scale(height); } }
        public override int AttackStat { get; }
        public override int Health { get; set;}
        private Vector2 direction;
        public override Vector2 Direction { get { return direction;} set { direction = value;} }

        private ISprite bladeTrapSprite;
        private float speed = 8;
        private readonly int width;
        private readonly int height;
        public override bool Invincible { get; set; }
        public override bool Alive { get; set; } = true;

        public BladeTrap(Vector2 location, IPlayer link)
        {
            bladeTrapSprite = EnemySpriteFactory.Instance.CreateBladeTrapSprite();
            width = 16;
            height = 16;

            this.link = link;
            Location = location;
            originalLocation = Location;
            Invincible = true;
            AttackStat = 1;
            Health = 1;
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            bladeTrapSprite.Draw(spritebatch, Location);
        }

        public override void Update()
        {
            bladeTrapSprite.Update();

            Location += speed * direction;
            if( Vector2.Distance(originalLocation, Location) < .1f)
            {
                direction = Vector2.Zero;
                if( Math.Abs(link.Location.X - originalLocation.X) < width)
                {
                    direction = link.Location - Location;
                    direction.X = 0;
                    direction.Normalize();
                    speed = 12;
                }
                else if( Math.Abs(link.Location.Y - originalLocation.Y) < height)
                {
                    direction = link.Location - Location;
                    direction.Y = 0;
                    direction.Normalize();
                    speed = 12;
                }
            }
            if( Math.Abs(Location.X - originalLocation.X) > LoZHelpers.Scale(80) || Math.Abs(Location.Y - originalLocation.Y) > LoZHelpers.Scale(40))
            {
                direction = (originalLocation - Location);
                direction.Normalize();
                speed = 6;
            }
        }
        public override void Knockback(Vector2 direction) { }
        public override void TakeDamage(Vector2 direction) { }
        public override void Die() { }
        public override void DropItem() {}
        public override void ChangeDirection(Direction direction = LegendOfZeldaClone.Direction.None) {}
    }
}
