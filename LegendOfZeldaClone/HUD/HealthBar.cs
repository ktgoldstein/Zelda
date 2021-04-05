using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class HealthBar : ISprite
    {
        private readonly ISprite fullHealthHeartSprite;
        private readonly ISprite halfHealthHeartSprite;
        private readonly ISprite noHealthHeartSprite;
        private readonly GameStateMachine game;

        public HealthBar(GameStateMachine game)
        {
            fullHealthHeartSprite = HUDTextureFactory.Instance.CreateFullHealthHeart();
            halfHealthHeartSprite = HUDTextureFactory.Instance.CreateHalfHealthHeart();
            noHealthHeartSprite = HUDTextureFactory.Instance.CreateNoHealthHeart();
            this.game = game;
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            int heartCounter = 0;
            int copyOfHealth = CurrentHealth;
            while (copyOfHealth > 0 || heartCounter < (MaxHealth / 2))
            {
                if (copyOfHealth == 1)
                {
                    halfHealthHeartSprite.Draw(spriteBatch, vector);
                    copyOfHealth = 0;
                }
                else if (copyOfHealth == 0)
                {
                    noHealthHeartSprite.Draw(spriteBatch, vector);
                }
                else
                {
                    fullHealthHeartSprite.Draw(spriteBatch, vector);
                    copyOfHealth -= 2;
                }
                heartCounter++;
                vector.X += LoZHelpers.Scale(8);
            }
        }

        private int MaxHealth => game.Player.MaxHealth;
        private int CurrentHealth => game.Player.Health;
    }
}
