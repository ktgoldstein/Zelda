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
        private readonly int spriteWidth = 16;
        private readonly int spriteHeight = 16;
        private readonly int atlasGap = 2;

        private PlayerProjectileSpriteFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            playerProjectileSpriteSheet = content.Load<Texture2D>("playerProjectileSpriteSheet");
        }

        public IPlayerProjectile CreateWoodenSwordDownSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingDown;
            return new LinkStandingSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public IPlayerProjectile CreateWoodenSwordDownSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingUp;
            return new LinkStandingSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public IPlayerProjectile CreateWoodenSwordDownSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingLeft;
            return new LinkStandingSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public IPlayerProjectile CreateWoodenSwordDownSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingRight;
            return new LinkStandingSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public IPlayerProjectile CreateLinkWalkingDownSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingDown;
            return new LinkWalkingSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public IPlayerProjectile CreateLinkWalkingUpSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingUp;
            return new LinkWalkingSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public IPlayerProjectile CreateLinkWalkingLeftSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingLeft;
            return new LinkWalkingSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public IPlayerProjectile CreateLinkWalkingRightSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingRight;
            return new LinkWalkingSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public IPlayerProjectile CreateLinkUsingItemDownSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemDown;
            return new LinkUsingItemSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public IPlayerProjectile CreateLinkUsingItemUpSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemUp;
            return new LinkUsingItemSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public IPlayerProjectile CreateLinkUsingItemLeftSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemLeft;
            return new LinkUsingItemSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public IPlayerProjectile CreateLinkUsingItemRightSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemRight;
            return new LinkUsingItemSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public IPlayerProjectile CreateLinkPickingUpItemSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemDown;
            return new LinkPickingUpItemSprite(playerProjectileSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }
    }
}
