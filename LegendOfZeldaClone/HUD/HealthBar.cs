using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class HealthBar
    {
        private ISprite fullHealthHeartSprite;
        private ISprite halfHealthHeartSprite;
        private ISprite noHealthHeartSprite;
        private int maxHealth;
        private int currentHealth;
        private int heartCounter;
        LegendOfZeldaDungeon game;

        public HealthBar(LegendOfZeldaDungeon game)
        {
            fullHealthHeartSprite = HUDTextureFactory.Instance.CreateFullHealthHeart();
            halfHealthHeartSprite = HUDTextureFactory.Instance.CreateHalfHealthHeart();
            noHealthHeartSprite = HUDTextureFactory.Instance.CreateNoHealthHeart();
            maxHealth = game.Player.MaxHealth;
            currentHealth = game.Player.Health;
            heartCounter = 0;
            this.game = game;
        }

        public void Update() 
        {
            heartCounter = 0;
            maxHealth = game.Player.MaxHealth;
            currentHealth = game.Player.Health;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            while (currentHealth > 0 || heartCounter < (maxHealth / 2))
            {
                if (currentHealth == 1)
                {
                    halfHealthHeartSprite.Draw(spriteBatch, vector);
                    currentHealth = 0;
                }
                else if (currentHealth == 0)
                {
                    noHealthHeartSprite.Draw(spriteBatch, vector);
                }
                else
                {
                    fullHealthHeartSprite.Draw(spriteBatch, vector);
                    currentHealth -= 2;
                }
                heartCounter++;
                vector.X += LoZHelpers.Scale(8);
            }
        }
    }
}
