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

        private static readonly LinkSpriteFactory instance = new LinkSpriteFactory();
        private Texture2D linkSpriteSheet;
        private readonly int spriteWidth = 16;
        private readonly int spriteHeight = 16;
        private readonly int atlasGap = 2;

        private LinkSpriteFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            linkSpriteSheet = content.Load<Texture2D>("linkSpriteSheet");
        }

        public ILinkSprite CreateLinkStandingDownSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingDown;
            return new LinkStandingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }
 
        public ILinkSprite CreateLinkStandingUpSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingUp;
            return new LinkStandingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public ILinkSprite CreateLinkStandingLeftSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingLeft;
            return new LinkStandingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public ILinkSprite CreateLinkStandingRightSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingRight;
            return new LinkStandingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public ILinkSprite CreateLinkWalkingDownSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingDown;
            return new LinkWalkingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public ILinkSprite CreateLinkWalkingUpSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingUp;
            return new LinkWalkingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public ILinkSprite CreateLinkWalkingLeftSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingLeft;
            return new LinkWalkingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public ILinkSprite CreateLinkWalkingRightSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingRight;
            return new LinkWalkingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public ILinkSprite CreateLinkUsingItemDownSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemDown;
            return new LinkUsingItemSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public ILinkSprite CreateLinkUsingItemUpSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemUp;
            return new LinkUsingItemSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public ILinkSprite CreateLinkUsingItemLeftSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemLeft;
            return new LinkUsingItemSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public ILinkSprite CreateLinkUsingItemRightSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemRight;
            return new LinkUsingItemSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }

        public ILinkSprite CreateLinkPickingUpItemSprite(LinkSkinType skinOffset, int frame)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemDown;
            return new LinkPickingUpItemSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap, frame);
        }
    }
}
