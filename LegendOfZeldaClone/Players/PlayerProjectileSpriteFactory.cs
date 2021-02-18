using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class PlayerProjectileSpriteFactory
    {
        public static PlayerProjectileSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private static readonly PlayerProjectileSpriteFactory instance = new PlayerProjectileSpriteFactory();
        private Texture2D playerProjectileSpriteSheet;
        private readonly int spriteSectionHeight = 16;
        private readonly int spriteSectionWidth = 32;
        private readonly int atlasGap = 2;

        private PlayerProjectileSpriteFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            playerProjectileSpriteSheet = content.Load<Texture2D>("playerProjectileSpriteSheet");
        }

        public ISprite CreateSwordUpSprite(SwordSkinType skinType)
        {
            int spriteWidth = 7;
            int spriteHeight = 16;
            int yOffset = 0;
            int xOffset = (spriteSectionWidth + atlasGap) * (int)skinType;
            return new StaticProjectileSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight);
        }

        public ISprite CreateSwordDownSprite(SwordSkinType skinType)
        {
            int spriteWidth = 7;
            int spriteHeight = 16;
            int yOffset = 0;
            int xOffset = (spriteSectionWidth + atlasGap) * (int)skinType + 8;
            return new StaticProjectileSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight);
        }

        public ISprite CreateSwordRightSprite(SwordSkinType skinType)
        {
            int spriteWidth = 16;
            int spriteHeight = 7;
            int yOffset = 0;
            int xOffset = (spriteSectionWidth + atlasGap) * (int)skinType + 16;
            return new StaticProjectileSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight);
        }

        public ISprite CreateSwordLeftSprite(SwordSkinType skinType)
        {
            int spriteWidth = 16;
            int spriteHeight = 7;
            int yOffset = 8;
            int xOffset = (spriteSectionWidth + atlasGap) * (int)skinType + 16;
            return new StaticProjectileSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight);
        }
    }
}
