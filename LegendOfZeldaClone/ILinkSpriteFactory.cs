using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface ILinkSpriteFactory
    {
        public static ILinkSpriteFactory Instance { get; }
        public void LoadAllTextures(ContentManager content);
        public void UnloadAllTextures(ContentManager content);
        public ISprite CreateLinkStandingDownSprite();
        public ISprite CreateLinkStandingUpSprite();
        public ISprite CreateLinkStandingLeftSprite();
        public ISprite CreateLinkStandingRightSprite();
        public ISprite CreateLinkWalkingDownSprite();
        public ISprite CreateLinkWalkingUpSprite();
        public ISprite CreateLinkWalkingLeftSprite();
        public ISprite CreateLinkWalkingRightSprite();
        public ISprite CreateLinkUsingItemDownSprite();
        public ISprite CreateLinkUsingItemUpSprite();
        public ISprite CreateLinkUsingItemLeftSprite();
        public ISprite CreateLinkUsingItemRightSprite();
        public ISprite CreateLinkPickingUpItemSprite();
    }

    public class NormalLinkSpriteFactory : ILinkSpriteFactory
    {
        public static NormalLinkSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private static NormalLinkSpriteFactory instance = new NormalLinkSpriteFactory();
        private Texture2D linkSpriteSheet;
        private int spriteWidth = 16;
        private int spriteHeight = 16;
        private int atlasGap = 2;
        
        private NormalLinkSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            linkSpriteSheet = content.Load<Texture2D>("linkSpriteSheet");
        }
    }

    public interface IPlayerSprite : ISprite
    {
        public bool AnimationDone();
    }
}
