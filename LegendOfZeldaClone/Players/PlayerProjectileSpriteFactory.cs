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
        private readonly int verticalSwordWidth, horizontalSwordHeight = 8;
        private readonly int verticalSwordHeight, horizontalSwordWidth = 16;
        private readonly int atlasGap = 2;

        private PlayerProjectileSpriteFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            playerProjectileSpriteSheet = content.Load<Texture2D>("playerProjectileSpriteSheet");
        }

        public IPlayerProjectile CreateSwordDownSprite(SwordSkinType WoodenSword, )
        {
            int spriteWidth = verticalSwordWidth;
            int spriteHeight = verticalSwordHeight;
            if (direction == Direction.Left || direction == Direction.Right)
            {
                spriteWidth = horizontalSwordWidth;
                spriteHeight = horizontalSwordHeight;
            }
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingDown;
            return new SwordProjectileSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public IPlayerProjectile CreateSwordUpSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingUp;
            return new LinkStandingSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public IPlayerProjectile CreateSwordLeftSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingLeft;
            return new LinkStandingSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public IPlayerProjectile CreateSwordRightSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingRight;
            return new LinkStandingSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }


    }
}
