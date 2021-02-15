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

        public ISprite CreateLionKey()
        {
            return new NonAnimatedItem(itemTexture, 129, 36, 8, 16, 8, 16);
        }

        public ISprite CreateBoomerang()
        {
            return new NonAnimatedItem(itemTexture, 0, 36, 6, 8, 8, 8);
        }

        public ISprite CreateBlueBoomerang()
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

        public ISprite CreateBlueArrow()
        {
            return new NonAnimatedItem(itemTexture, 78, 17, 6, 15, 8, 16);
        }

        public ItemInterface CreateBomb()
        {
            return new Bomb(itemTexture);
        }

        public ItemInterface CreateFairy()
        {
            return new Fairy(itemTexture);
        }

        public ItemInterface CreateClock()
        {
            return new Clock(itemTexture);
        }

        public ItemInterface CreateTriforcePiece()
        {
            return new TriforcePiece(itemTexture);
        }

        public ItemInterface CreateHeartContainer()
        {
            return new HeartContainer(itemTexture);
        }

        public ItemInterface CreateMap()
        {
            return new Map(itemTexture);
        }

        public ItemInterface CreatePotion()
        {
            return new Potion(itemTexture);
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
