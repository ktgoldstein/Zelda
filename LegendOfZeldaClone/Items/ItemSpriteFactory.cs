using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class ItemSpriteFactory
    {
        private Texture2D itemTexture;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            itemTexture = content.Load<Texture2D>("LoZItemsSpreadsheet");
        }

        public ISprite CreateCompass()
        {
            return new NonAnimatedItem(itemTexture, 141, 0, 11, 12);
        }

        public ISprite CreateKey()
        {
            return new NonAnimatedItem(itemTexture, 130, 18, 8, 16);
        }

        public ISprite CreateMagicalKey()
        {
            return new NonAnimatedItem(itemTexture, 129, 36, 8, 16);
        }

        public ISprite CreateBoomerang()
        {
            return new NonAnimatedItem(itemTexture, 1, 39, 5, 8);
        }

        public ISprite CreateBow()
        {
            return new NonAnimatedItem(itemTexture, 15, 99, 8, 16);
        }

        public ISprite CreateHeart()
        {
            return new AnimatedItem(itemTexture, 0, 0, 7, 8);
        }

        public ISprite CreateFullHealthHeart()
        {
            return new NonAnimatedItem(itemTexture, 0, 0, 7, 8);
        }

        public ISprite CreateHalfHealthHeart()
        {
            return new NonAnimatedItem(itemTexture, 0, 19, 7, 8);
        }

        public ISprite CreateNoHealthHeart()
        {
            return new NonAnimatedItem(itemTexture, 0, 29, 7, 8);
        }

        public ISprite CreateFlashingRupee()
        {
            return new AnimatedItem(itemTexture, 37, 0, 8, 16);
        }

        public ISprite CreateGoldRupee()
        {
            return new NonAnimatedItem(itemTexture, 37, 0, 8, 16);
        }

        public ISprite CreateBlueRupee()
        {
            return new NonAnimatedItem(itemTexture, 37, 18, 8, 16);
        }

        public ISprite CreateArrow()
        {
            return new NonAnimatedItem(itemTexture, 79, 0, 5, 16);
        }

        public ISprite CreateSilverArrow()
        {
            return new NonAnimatedItem(itemTexture, 79, 17, 5, 16);
        }

        public ISprite CreateBomb()
        {
            return new NonAnimatedItem(itemTexture, 14, 83, 8, 14);
        }

        public ISprite CreateFairy()
        {
            return new AnimatedItem(itemTexture, 26, 0, 8, 16);
        }

        public ISprite CreateClock()
        {
            return new NonAnimatedItem(itemTexture, 11, 15, 11, 16);
        }

        public ISprite CreateTriforcePiece()
        {
            return new AnimatedItem(itemTexture, 142, 14, 10, 10);
        }

        public ISprite CreateHeartContainer()
        {
            return new NonAnimatedItem(itemTexture, 10, 0, 13, 13);
        }

        public ISprite CreateMap()
        {
            return new NonAnimatedItem(itemTexture, 59, 0, 8, 16);
        }

        public ISprite CreateLifePotion()
        {
            return new NonAnimatedItem(itemTexture, 48, 17, 8, 16);
        }

        public ISprite CreateSword()
        {
            return new NonAnimatedItem(itemTexture, 69, 0, 7, 16);
        }

        public ISprite CreateBlueCandle()
        {
            return new NonAnimatedItem(itemTexture, 87, 17, 8, 16);
        }

        public ISprite CreateBlueRing()
        {
            return new NonAnimatedItem(itemTexture, 0, 70, 7, 9);
        }
    }
}
