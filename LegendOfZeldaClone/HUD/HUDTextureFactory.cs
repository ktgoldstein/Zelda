using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace LegendOfZeldaClone
{
    class HUDTextureFactory
    {
        private Texture2D miniMap;
        private Texture2D text;
        
        public static HUDTextureFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private static HUDTextureFactory instance = new HUDTextureFactory();

        private HUDTextureFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            miniMap = content.Load<Texture2D>("LevelLoading\\Level 1");
            text = content.Load<Texture2D>("Background");
        }

        public ISprite CreateMiniMap() => new MapSprite(miniMap, 1, 1, 1);
        public ISprite CreateL() => new TextSprite(text, 83, 19, 6, 7);
        public ISprite CreateE() => new TextSprite(text, 58, 11, 7, 7);
        public ISprite CreateV() => new TextSprite(text, 122, 19, 7, 7);
        public ISprite CreateDash() => new TextSprite(text, 58, 38, 6, 1);
        public ISprite Create1() => new TextSprite(text, 3, 19, 6, 7);
        public ISprite CreateRupeeCount() => new TextSprite(text, 219, 131, 8, 8);
        public ISprite CreateKeyCount() => new TextSprite(text, 227, 131, 8, 8);
        public ISprite CreateBombCount() => new TextSprite(text, 2, 67, 8, 8);
        public ISprite CreateX() => new TextSprite(text, 2, 35, 7, 7);
        public ISprite Create0() => new TextSprite(text, 2, 11, 7, 7);
        public ISprite Create2() => new TextSprite(text, 10, 11, 7, 7);
        public ISprite Create3() => new TextSprite(text, 10, 19, 7, 7);
        public ISprite Create4() => new TextSprite(text, 18, 11, 7, 7);
        public ISprite Create5() => new TextSprite(text, 18, 19, 7, 7);
        public ISprite Create6() => new TextSprite(text, 26, 11, 7, 7);
        public ISprite Create7() => new TextSprite(text, 26, 19, 7, 7);
        public ISprite Create8() => new TextSprite(text, 34, 11, 7, 7);
        public ISprite Create9() => new TextSprite(text, 34, 19, 7, 7);
    }
}
