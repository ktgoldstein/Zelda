using System;
using LegendOfZeldaClone.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemy
{
    class MerchantFire : EnemyKernal
    {
        public override int AttackStat { get; }
        public override int Health { get; set; }
        public Vector2 direction;
        public override Vector2 Direction { get { return direction; } set { direction = value; } }
        public override bool Invincible { get; set; }
        public override bool Alive { get; set; }
        public override Vector2 Location { get; set; }
        public override Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }

        public override int Width { get { return LoZHelpers.Scale(width); } }
        public override int Height { get { return LoZHelpers.Scale(height); } }

        private ISprite merchantFireSprite;
        private readonly int width;
        private readonly int height;
        public Merchant Merchant;
        public MerchantFire(GameStateMachine game, Vector2 location, Merchant merchant)
        {
            merchantFireSprite = EnemySpriteFactory.Instance.CreateWizardFireSprite();
            width = 16;
            height = 16;

            base.game = game;
            Location = location;
            Direction = new Vector2(0, 0);
            Invincible = true;
            Alive = true;
            AttackStat = 1;
            Health = 1;
            Merchant = merchant;
        }

        public override void Draw(SpriteBatch spriteBatch) => merchantFireSprite.Draw(spriteBatch, Location - new Vector2(20, 0));

        public override void Knockback(Vector2 direction) { }

        public override void Update()
        {
            merchantFireSprite.Update();
        }
        public override void TakeDamage(Vector2 direction) { }
        public override void Die() { }
        public override void DropItem() { }
        public override void ChangeDirection(Direction direction = LegendOfZeldaClone.Direction.None) { }
    }
}
