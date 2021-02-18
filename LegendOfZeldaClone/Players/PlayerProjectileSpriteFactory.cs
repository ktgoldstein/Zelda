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

        public ISprite CreateSwordBeamExplosionUpLeftSprite(SwordSkinType skinType)
        {
            int spriteWidth = 8;
            int spriteHeight = 16;
            int xOffset = (spriteSectionWidth + atlasGap) * (int)skinType;
            int yOffset = (spriteSectionHeight + atlasGap);
            return new StaticProjectileSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight);
        }

        public ISprite CreateSwordBeamExplosionUpRightSprite(SwordSkinType skinType)
        {
            int spriteWidth = 8;
            int spriteHeight = 16;
            int xOffset = (spriteSectionWidth + atlasGap) * (int)skinType + 8;
            int yOffset = (spriteSectionHeight + atlasGap);
            return new StaticProjectileSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight);
        }

        public ISprite CreateSwordBeamExplosionDownLeftSprite(SwordSkinType skinType)
        {
            int spriteWidth = 8;
            int spriteHeight = 16;
            int xOffset = (spriteSectionWidth + atlasGap) * (int)skinType + 16;
            int yOffset = (spriteSectionHeight + atlasGap);
            return new StaticProjectileSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight);
        }

        public ISprite CreateSwordBeamExplosionDownRightSprite(SwordSkinType skinType)
        {
            int spriteWidth = 8;
            int spriteHeight = 16;
            int xOffset = (spriteSectionWidth + atlasGap) * (int)skinType + 24;
            int yOffset = (spriteSectionHeight + atlasGap);
            return new StaticProjectileSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight);
        }

        public ISprite CreateArrowUpSprite(ArrowSkinType skinType)
        {
            int spriteWidth = 8;
            int spriteHeight = 16;
            int xOffset = (spriteSectionWidth + atlasGap) * (int)skinType;
            int yOffset = (spriteSectionHeight + atlasGap) * 2;
            return new StaticProjectileSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight);
        }

        public ISprite CreateArrowDownSprite(ArrowSkinType skinType)
        {
            int spriteWidth = 8;
            int spriteHeight = 16;
            int xOffset = (spriteSectionWidth + atlasGap) * (int)skinType + 8;
            int yOffset = (spriteSectionHeight + atlasGap) * 2;
            return new StaticProjectileSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight);
        }

        public ISprite CreateArrowRightSprite(ArrowSkinType skinType)
        {
            int spriteWidth = 16;
            int spriteHeight = 8;
            int xOffset = (spriteSectionWidth + atlasGap) * (int)skinType + 16;
            int yOffset = (spriteSectionHeight + atlasGap) * 2;
            return new StaticProjectileSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight);
        }

        public ISprite CreateArrowLeftSprite(ArrowSkinType skinType)
        {
            int spriteWidth = 16;
            int spriteHeight = 8;
            int xOffset = (spriteSectionWidth + atlasGap) * (int)skinType + 16;
            int yOffset = (spriteSectionHeight + atlasGap) * 2 + 8;
            return new StaticProjectileSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight);
        }
    }
}
