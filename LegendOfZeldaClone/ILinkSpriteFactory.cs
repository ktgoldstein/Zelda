using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class LinkSpriteFactory
    {
        public static LinkSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private static LinkSpriteFactory instance = new LinkSpriteFactory();
        private Texture2D linkSpriteSheet;
        private int spriteWidth = 16;
        private int spriteHeight = 16;
        private int atlasGap = 2;
        
        private LinkSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            linkSpriteSheet = content.Load<Texture2D>("linkSpriteSheet");
        }

        public ILinkSprite CreateLinkStandingDownSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingDown;
            return new LinkStandingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }
 
        public ILinkSprite CreateLinkStandingUpSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingUp;
            return new LinkStandingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ILinkSprite CreateLinkStandingLeftSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingLeft;
            return new LinkStandingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ILinkSprite CreateLinkStandingRightSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingRight;
            return new LinkStandingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ILinkSprite CreateLinkWalkingDownSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingDown;
            return new LinkWalkingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ILinkSprite CreateLinkWalkingUpSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingUp;
            return new LinkWalkingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ILinkSprite CreateLinkWalkingLeftSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingLeft;
            return new LinkWalkingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ILinkSprite CreateLinkWalkingRightSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingRight;
            return new LinkWalkingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ILinkSprite CreateLinkUsingItemDownSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemDown;
            return new LinkUsingItemSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ILinkSprite CreateLinkUsingItemUpSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemUp;
            return new LinkUsingItemSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ILinkSprite CreateLinkUsingItemLeftSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemLeft;
            return new LinkUsingItemSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ILinkSprite CreateLinkUsingItemRightSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemRight;
            return new LinkUsingItemSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ILinkSprite CreateLinkPickingUpItemSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemDown;
            return new LinkPickingUpItemSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }
    }
}
