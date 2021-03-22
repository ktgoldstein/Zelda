using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class KeyCount : ISprite
    {
        private readonly ISprite keyCountSprite;
        private readonly ISprite xSprite;
        private ISprite numberSprite;
        private int numberOfKeys;
        private int[] digitArray = new int[3];
        private readonly LegendOfZeldaDungeon game;

        public KeyCount(LegendOfZeldaDungeon game)
        {
            keyCountSprite = HUDTextureFactory.Instance.CreateKeyCount();
            xSprite = HUDTextureFactory.Instance.CreateX();
            numberSprite = HUDTextureFactory.Instance.CreateNumber(0);
            numberOfKeys = 0;
            this.game = game;
            digitArray[0] = numberOfKeys;
        }

        public void Update() 
        {
            numberOfKeys = game.Player.Inventory.KeysHeld;
            int placeHolder = numberOfKeys;
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
            keyCountSprite.Draw(spriteBatch, vector);
            vector.X += LoZHelpers.Scale(8);
            if (numberOfKeys >= 100)
            {
                numberSprite = HUDTextureFactory.Instance.CreateNumber(digitArray[2]);
                numberSprite.Draw(spriteBatch, vector);
            }
            else
            {
                xSprite.Draw(spriteBatch, vector);
            }
            vector.X += LoZHelpers.Scale(8);
            if (numberOfKeys >= 10)
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
