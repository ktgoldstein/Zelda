using System;
using LegendOfZeldaClone.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemy
{
    class WizardFire : EnemyKernal
    {
        public override int AttackStat { get; }
        public override int Health { get; set; }
        public Vector2 direction;
        public override Vector2 Direction { get { return direction;} set { direction = value;} }
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

        private ISprite wizardFireSprite;
        private readonly int width;
        private readonly int height;
        public Wizard Wizard;
        private int wizardHealth;
        private int attackInt = 0;
        public WizardFire(GameStateMachine game, Vector2 location, Wizard wizard)
        {
            wizardFireSprite = EnemySpriteFactory.Instance.CreateWizardFireSprite();
            width = 16;
            height = 16;

            base.game = game;
            Location = location;
            Direction = new Vector2(0, 0);
            Invincible = true;
            Alive = true;
            AttackStat = 1;
            Health = 1;
            Wizard = wizard;
            wizardHealth = Wizard.Health;
        }

        public override void Draw(SpriteBatch spriteBatch) => wizardFireSprite.Draw(spriteBatch, Location);

        public override void Knockback(Vector2 direction) { }

        public override void Update()
        {
            wizardFireSprite.Update();
            if(Wizard.Health < wizardHealth && attackInt%40==0)
                SpitFireballs();
            attackInt++;
        }
        private void SpitFireballs()
        {
            game.EnemyProjectilesQueue.Add(new Fireball(Location, game.Player.Location - Location));
        }

        public override void TakeDamage(Vector2 direction) { }
        public override void Die() { }
        public override void DropItem() {}
        public override void ChangeDirection(Direction direction = LegendOfZeldaClone.Direction.None) {}
    }
}
