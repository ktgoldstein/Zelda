using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class RupeeCount : ISprite
    {
        private readonly ISprite rupeeCountSprite;
        private readonly ISprite xSprite;
        private ISprite numberSprite;
        private int numberOfRupees;
        private int[] digitArray = new int[3];
        private readonly GameStateMachine game;

        public RupeeCount(GameStateMachine game)
        {
            rupeeCountSprite = HUDTextureFactory.Instance.CreateRupeeCount();
            xSprite = HUDTextureFactory.Instance.CreateX();
            numberSprite = HUDTextureFactory.Instance.CreateNumber(0);
            numberOfRupees = 0;
            this.game = game;
            digitArray[0] = numberOfRupees;
        }

        public void Update()
        {
            numberOfRupees = game.Player.Inventory.RupeesHeld;
            int placeHolder = numberOfRupees;
            int digitCount = 0;
            while (placeHolder > 0)
            {
                digitArray[digitCount] = placeHolder % 10;
                placeHolder /= 10;
                digitCount++;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            rupeeCountSprite.Draw(spriteBatch, vector);
            vector.X += LoZHelpers.Scale(8);
            if (numberOfRupees >= 100)
            {
                numberSprite = HUDTextureFactory.Instance.CreateNumber(digitArray[2]);
                numberSprite.Draw(spriteBatch, vector);
            }
            else
            {
                xSprite.Draw(spriteBatch, vector);
            }
            vector.X += LoZHelpers.Scale(8);
            if (numberOfRupees >= 10)
            {
                numberSprite = HUDTextureFactory.Instance.CreateNumber(digitArray[1]);
                numberSprite.Draw(spriteBatch, vector);
                vector.X += LoZHelpers.Scale(8);
            }
            numberSprite = HUDTextureFactory.Instance.CreateNumber(digitArray[0]);
            numberSprite.Draw(spriteBatch, vector);
        }
    }
}
