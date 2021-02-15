using System;
using System.Collections.Generic;
using System.Text;
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
            return new NonAnimatedItem(itemTexture, 130, 17, 8, 16, 8, 16);
        }

        public ISprite CreateMagicalKey()
        {
            return new NonAnimatedItem(itemTexture, 129, 36, 8, 16, 8, 16);
        }

        public ISprite CreateBoomerang()
        {
            return new NonAnimatedItem(itemTexture, 0, 36, 6, 8, 8, 8);
        }

        public ISprite CreateMagicalBoomerang()
        {
            return new NonAnimatedItem(itemTexture, 0, 46, 6, 8, 8, 8);
        }

        public ISprite CreateBow()
        {
            return new NonAnimatedItem(itemTexture, 12, 98, 12, 17, 12, 16);
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
            return new AnimatedItem(itemTexture, 36, 0, 9, 15, 8, 16);
        }

        public ISprite CreateGoldRupee()
        {
            return new NonAnimatedItem(itemTexture, 36, 0, 9, 15, 8, 16);
        }

        public ISprite CreateBlueRupee()
        {
            return new NonAnimatedItem(itemTexture, 36, 17, 9, 15, 8, 16);
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
            return new NonAnimatedItem(itemTexture, 58, 0, 9, 15, 12, 16);
        }
        public ISprite CreateLetter()
        {
            return new NonAnimatedItem(itemTexture, 58, 17, 9, 15, 12, 16);
        }

        public ISprite CreateSecondPotion()
        {
            return new NonAnimatedItem(itemTexture, 48, 0, 8, 15, 8, 16);
        }

        public ISprite CreateLifePotion()
        {
            return new NonAnimatedItem(itemTexture, 48, 17, 8, 15, 8, 16);
        }

        public ItemInterface CreateSword()
        {
            return new Sword(itemTexture);
        }

        public ItemInterface CreateShield()
        {
            return new Shield(itemTexture);
        }

        public ItemInterface CreateCandle()
        {
            return new Candle(itemTexture);
        }

        public ItemInterface CreateRing()
        {
            return new Ring(itemTexture);
        }

        public ItemInterface CreateStaff()
        {
            return new Staff(itemTexture);
        }

        public ItemInterface CreateBook()
        {
            return new Book(itemTexture);
        }
    }
}
