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

        private ItemSpriteFactory()
        {

        }

        public void LoadAllTextures(ContentManager content)
        {
            itemTexture = content.Load<Texture2D>("LoZItemsSpreadsheet");
        }

        public ItemInterface CreateCompass()
        {
            return new Compass(itemTexture);
        }

        public ItemInterface CreateKey()
        {
            return new Key(itemTexture);
        }

        public ItemInterface CreateBoomerang()
        {
            return new Boomerang(itemTexture);
        }

        public ItemInterface CreateBow()
        {
            return new Bow(itemTexture);
        }

        public ItemInterface CreateHeart()
        {
            return new Heart(itemTexture);
        }

        public ItemInterface CreateRupee()
        {
            return new Rupee(itemTexture);
        }

        public ItemInterface CreateArrow()
        {
            return new Arrow(itemTexture);
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
    }
}
