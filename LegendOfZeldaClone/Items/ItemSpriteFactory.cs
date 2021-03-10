using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class ItemSpriteFactory
    {
        public static ItemSpriteFactory Instance { get { return instance; } }

        private static ItemSpriteFactory instance = new ItemSpriteFactory();
        private Texture2D itemTexture;
        private ItemSpriteFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            itemTexture = content.Load<Texture2D>("LoZItemsSpreadsheet");
        }

        public ISprite CreateCompass()
        {
            return new StaticItemSprite(itemTexture, 141, 0, 11, 12);
        }

        public ISprite CreateKey()
        {
            return new StaticItemSprite(itemTexture, 130, 18, 8, 16);
        }

        public ISprite CreateBoomerang()
        {
            return new StaticItemSprite(itemTexture, 1, 39, 5, 8);
        }

        public ISprite CreateBow()
        {
            return new StaticItemSprite(itemTexture, 15, 99, 8, 16);
        }

        public ISprite CreateHeart()
        {
            return new AnimatedItemSprite(itemTexture, 0, 0, 7, 8);
        }

        public ISprite CreateFullHealthHeart()
        {
            return new StaticItemSprite(itemTexture, 0, 0, 7, 8);
        }

        public ISprite CreateHalfHealthHeart()
        {
            return new StaticItemSprite(itemTexture, 0, 19, 7, 8);
        }

        public ISprite CreateNoHealthHeart()
        {
            return new StaticItemSprite(itemTexture, 0, 29, 7, 8);
        }

        public ISprite CreateFlashingRupee()
        {
            return new AnimatedItemSprite(itemTexture, 37, 0, 8, 16);
        }

        public ISprite CreateGoldRupee()
        {
            return new StaticItemSprite(itemTexture, 37, 0, 8, 16);
        }

        public ISprite CreateBlueRupee()
        {
            return new StaticItemSprite(itemTexture, 37, 18, 8, 16);
        }

        public ISprite CreateArrow()
        {
            return new StaticItemSprite(itemTexture, 79, 0, 5, 16);
        }

        public ISprite CreateBomb()
        {
            return new StaticItemSprite(itemTexture, 14, 83, 8, 14);
        }

        public ISprite CreateFairy()
        {
            return new AnimatedItemSprite(itemTexture, 26, 0, 8, 16);
        }

        public ISprite CreateClock()
        {
            return new StaticItemSprite(itemTexture, 11, 15, 11, 16);
        }

        public ISprite CreateTriforcePiece()
        {
            return new AnimatedItemSprite(itemTexture, 142, 14, 10, 10);
        }

        public ISprite CreateHeartContainer()
        {
            return new StaticItemSprite(itemTexture, 10, 0, 13, 13);
        }

        public ISprite CreateMap()
        {
            return new StaticItemSprite(itemTexture, 59, 0, 8, 16);
        }

        public ISprite CreateLifePotion()
        {
            return new StaticItemSprite(itemTexture, 48, 17, 8, 16);
        }

        public ISprite CreateSword()
        {
            return new StaticItemSprite(itemTexture, 69, 0, 7, 16);
        }

        public ISprite CreateBlueCandle()
        {
            return new StaticItemSprite(itemTexture, 87, 17, 8, 16);
        }

        public ISprite CreateBlueRing()
        {
            return new StaticItemSprite(itemTexture, 0, 70, 7, 9);
        }
    }
}
