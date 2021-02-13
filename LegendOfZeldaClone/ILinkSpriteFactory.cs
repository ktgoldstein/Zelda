using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public enum LinkSkinType
    {
        Normal = 0,
        BlueRing = 1,
        DamagedOne = 6,
        DamagedTwo = 7,
        DamagedThreeDungeonOne = 9
    }

    public enum LinkSpriteType
    {
        FacingDown = 0,
        FacingUp = 2,
        FacingRight = 4,
        FacingLeft = 6,
        UsingItemDown = 14,
        UsingItemUp = 15,
        UsingItemRight = 16,
        UsingItemLeft = 17,
        PickingUpItem = 18
    }

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

        public ISprite CreateLinkStandingDownSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingDown;
            return new LinkStandingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }
 
        public ISprite CreateLinkStandingUpSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingUp;
            return new LinkStandingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ISprite CreateLinkStandingLeftSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingLeft;
            return new LinkStandingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ISprite CreateLinkStandingRightSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingRight;
            return new LinkStandingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ISprite CreateLinkWalkingDownSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingDown;
            return new LinkWalkingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ISprite CreateLinkWalkingUpSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingUp;
            return new LinkWalkingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ISprite CreateLinkWalkingLeftSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingLeft;
            return new LinkWalkingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ISprite CreateLinkWalkingRightSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.FacingRight;
            return new LinkWalkingSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ISprite CreateLinkUsingItemDownSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemDown;
            return new LinkUsingItemSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ISprite CreateLinkUsingItemUpSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemUp;
            return new LinkUsingItemSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ISprite CreateLinkUsingItemLeftSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemLeft;
            return new LinkUsingItemSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ISprite CreateLinkUsingItemRightSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemRight;
            return new LinkUsingItemSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }

        public ISprite CreateLinkPickingUpItemSprite(LinkSkinType skinOffset)
        {
            int yOffset = (spriteHeight + atlasGap) * (int)skinOffset;
            int xOffset = (spriteHeight + atlasGap) * (int)LinkSpriteType.UsingItemDown;
            return new LinkPickingUpItemSprite(linkSpriteSheet, xOffset, yOffset, spriteWidth, spriteHeight, atlasGap);
        }
    }
}
