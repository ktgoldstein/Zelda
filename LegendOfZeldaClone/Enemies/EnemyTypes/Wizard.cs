using LegendOfZeldaClone.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone.Enemy
{
    class Wizard : IEnemy
    {
        public int AttackStat { get; }
        public int Health { get; set; } = LoZHelpers.WizardHP;
        public int MaxHealth { get; } = LoZHelpers.WizardHP;
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
        private SpriteFont font;
        private String target = "Hit me, I dare you.\n You won't.";
        private int current = 0;
        private int timer = 7;

        public Wizard(LegendOfZeldaDungeon game, Vector2 location)
        {
            wizardSprite = EnemySpriteFactory.Instance.CreateWizardSprite();
            font = EnemySpriteFactory.Instance.CreateFont();
            width = 16;
            height = 16;

            this.game = game;
            Location = location;
            Direction = new Vector2(0, 0);
            Invincible = false;
            Alive = true;
            AttackStat = 0;

            this.game.Enemies.Add(new WizardFire(game, Location - new Vector2(LoZHelpers.Scale(3 * 16), 0), this));
            this.game.Enemies.Add(new WizardFire(game, Location + new Vector2(LoZHelpers.Scale(3 * 16), 0), this));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            wizardSprite.Draw(spriteBatch, Location);

            spriteBatch.DrawString(font, target.Substring(0,current), Location + new Vector2(-192, -96), Color.White);
        }

        public void Knockback(Vector2 direction) { }

        public void Update()
        {
            wizardSprite.Update();
            if(Invincible)
            {
                invincibleFrames++;
                if(invincibleFrames > 20)
                {
                    Invincible = false;
                    invincibleFrames = 0;
                }
            }
            timer--;
            if(timer == 0)
            {
                timer =  7;
                if(current < target.Length)
                    current++;
            }
        }
    }
}
