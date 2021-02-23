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
            return new NonAnimatedItem(itemTexture, 140, 0, 12, 12, 12, 12);
        }

        public ISprite CreateKey()
        {
            return new NonAnimatedItem(itemTexture, 130, 17, 8, 17, 8, 16);
        }

        public ISprite CreateMagicalKey()
        {
            return new NonAnimatedItem(itemTexture, 129, 36, 8, 17, 8, 16);
        }

        public ISprite CreateBoomerang()
        {
            return new NonAnimatedItem(itemTexture, 0, 39, 7, 8, 12, 12);
        }

        public ISprite CreateBow()
        {
            return new NonAnimatedItem(itemTexture, 12, 98, 13, 17, 12, 16);
        }

        public ISprite CreateHeart()
        {
            return new AnimatedItem(itemTexture, 0, 0, 7, 7, 8, 8);
        }

        public ISprite CreateFullHealthHeart()
        {
            return new NonAnimatedItem(itemTexture, 0, 0, 7, 7, 8, 8);
        }

        public ISprite CreateHalfHealthHeart()
        {
            return new NonAnimatedItem(itemTexture, 0, 19, 7, 7, 8, 8);
        }

        public ISprite CreateNoHealthHeart()
        {
            return new NonAnimatedItem(itemTexture, 0, 29, 7, 7, 8, 8);
        }

        public ISprite CreateFlashingRupee()
        {
            return new AnimatedItem(itemTexture, 36, 0, 10, 16, 12, 16);
        }

        public ISprite CreateGoldRupee()
        {
            return new NonAnimatedItem(itemTexture, 36, 0, 10, 16, 12, 16);
        }

        public ISprite CreateBlueRupee()
        {
            return new NonAnimatedItem(itemTexture, 36, 18, 10, 16, 12, 16);
        }

        public ISprite CreateArrow()
        {
            return new NonAnimatedItem(itemTexture, 78, 0, 6, 15, 8, 16);
        }

        public ISprite CreateSilverArrow()
        {
            return new NonAnimatedItem(itemTexture, 78, 17, 6, 15, 8, 16);
        }

        public ISprite CreateBomb()
        {
            return new NonAnimatedItem(itemTexture, 14, 83, 9, 14, 12, 16);
        }

        public ISprite CreateFairy()
        {
            return new AnimatedItem(itemTexture, 25, 0, 9, 15, 12, 16);
        }

        public ISprite CreateClock()
        {
            return new NonAnimatedItem(itemTexture, 10, 15, 12, 16, 12, 16);
        }

        public ISprite CreateTriforcePiece()
        {
            return new AnimatedItem(itemTexture, 141, 13, 12, 10, 12, 12);
        }

        public ISprite CreateHeartContainer()
        {
            return new NonAnimatedItem(itemTexture, 9, 0, 14, 14, 16, 16);
        }

        public ISprite CreateMap()
        {
            return new NonAnimatedItem(itemTexture, 58, 0, 9, 16, 12, 16);
        }

        public ISprite CreateLifePotion()
        {
            return new NonAnimatedItem(itemTexture, 48, 17, 8, 15, 8, 16);
        }

        public ISprite CreateSword()
        {
            return new NonAnimatedItem(itemTexture, 69, 0, 7, 16, 8, 16);
        }

        public ISprite CreateBlueCandle()
        {
            return new NonAnimatedItem(itemTexture, 87, 17, 9, 16, 12, 16);
        }

        public ISprite CreateBlueRing()
        {
            return new NonAnimatedItem(itemTexture, 0, 70, 8, 9, 8, 8);
        }
    }
}
