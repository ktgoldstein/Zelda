using LegendOfZeldaClone.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemies.EnemyTypes
{
    class Wizard : IEnemy
    {
        public int AttackStat { get; }
        public int Health { get; set; } = LoZHelpers.WizardHP;
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
        private ISprite wizardSprite;
        private int invincibleFrames = 0;
        private readonly int width;
        private readonly int height;
        private Vector2 knockbackForce = Vector2.Zero;
        public Wizard(LegendOfZeldaDungeon game, Vector2 location)
        {
            wizardSprite = EnemySpriteFactory.Instance.CreateWizardSprite();
            width = 16;
            height = 16;

            this.game = game;
            Location = location;
            Direction = new Vector2(0, 0);
            Invincible = false;
            Alive = true;
            AttackStat = 0;
        }

        public void Draw(SpriteBatch spriteBatch) => wizardSprite.Draw(spriteBatch, Location);

        public void Knockback(Vector2 direction)
        {
            knockbackForce = direction*0;
        }

        public void Update()
        {
            wizardSprite.Update();
        }
    }
}
