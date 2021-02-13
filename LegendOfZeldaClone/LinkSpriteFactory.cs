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
    }

    public interface IPlayerSprite : ISprite
    {
        public bool AnimationDone();
    }
}
