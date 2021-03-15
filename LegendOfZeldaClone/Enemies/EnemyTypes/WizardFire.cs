using System;
using LegendOfZeldaClone.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemy
{
    class WizardFire : IEnemy
    {
        public int AttackStat { get; }
        public int Health { get; set; }
        public Vector2 direction;
        public Vector2 Direction { get { return direction;} set { direction = value;} }
        public bool Invincible { get; set; }
        public bool Alive { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 HurtBoxLocation
        {
            get { return Location; }
            set { Location = value; }
        }

        public int Width { get { return LoZHelpers.Scale(width); } }

        public int Height { get { return LoZHelpers.Scale(height); } }
        private LegendOfZeldaDungeon game;
        private ISprite wizardFireSprite;
        private readonly int width;
        private readonly int height;
        public Wizard Wizard;
        private int wizardHealth;
        public WizardFire(LegendOfZeldaDungeon game, Vector2 location, Wizard wizard)
        {
            wizardFireSprite = EnemySpriteFactory.Instance.CreateWizardFireSprite();
            width = 16;
            height = 16;

            this.game = game;
            Location = location;
            Direction = new Vector2(0, 0);
            Invincible = true;
            Alive = true;
            AttackStat = 1;
            Health = 1;
            Wizard = wizard;
            wizardHealth = Wizard.Health;
        }

        public void Draw(SpriteBatch spriteBatch) => wizardFireSprite.Draw(spriteBatch, Location);

        public void Knockback(Vector2 direction) { }

        public void Update()
        {
            wizardFireSprite.Update();
            if(Wizard.Health < wizardHealth)
            {
                SpitFireballs();
                wizardHealth = Wizard.Health;
            }
        }
        private void SpitFireballs()
        {
            game.EnemyProjectilesQueue.Add(new Fireball(Location, game.Player.Location - Location));
        }
    }
}
