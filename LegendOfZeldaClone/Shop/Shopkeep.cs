using LegendOfZeldaClone.Enemies;
using LegendOfZeldaClone.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegendOfZeldaClone
{
    class Shopkeep : ISprite
    {

        private ISprite shopkeepSprite;
        private Vector2 Location;

        private SpriteFont font;
        private String target = "Would you like to \n buy some items?";
        private int current = 0;
        private int timer = 7;

        public Shopkeep(GameStateMachine game, Vector2 location)
        {
            shopkeepSprite = EnemySpriteFactory.Instance.CreateWizardSprite();
            font = EnemySpriteFactory.Instance.CreateFont();
            Location = location;

        }

        public override void Update()
        {
            timer--;
            if (timer == 0)
            {
                timer = 7;
                if (current < target.Length)
                {
                    current++;
                    new TextAppearingSlowlySoundEffect().Play();
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            shopkeepSprite.Draw(spriteBatch, Location);
            spriteBatch.DrawString(font, target.Substring(0,current), Location + new Vector2(-192, -96), Color.White);
        }


    }
}
