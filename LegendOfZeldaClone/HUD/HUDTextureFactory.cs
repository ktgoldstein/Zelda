using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace LegendOfZeldaClone
{
    class HUDTextureFactory
    {
        private Texture2D miniMap;
        private Texture2D inventory;
        
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
            inventory = content.Load<Texture2D>("LoZInventorySpriteSheet");
        }

        public ISprite CreateMiniMap() => new MapSprite(miniMap, 1, 1, 1);
        public ISprite CreateLevelName() => new TextSprite(inventory, 584, 1, 48, 8);
        public ISprite Create1() => new TextSprite(inventory, 537, 117, 8, 8);
        public ISprite CreateRupeeCount() => new TextSprite(inventory, 346, 27, 8, 8);
        public ISprite CreateKeyCount() => new TextSprite(inventory, 346, 43, 8, 8);
        public ISprite CreateBombCount() => new TextSprite(inventory, 346, 51, 8, 8);
        public ISprite CreateX() => new TextSprite(inventory, 519, 117, 8, 8);
        public ISprite Create0() => new TextSprite(inventory, 528, 117, 8, 8);
        public ISprite Create2() => new TextSprite(inventory, 546, 117, 8, 8);
        public ISprite Create3() => new TextSprite(inventory, 555, 117, 8, 8);
        public ISprite Create4() => new TextSprite(inventory, 564, 117, 8, 8);
        public ISprite Create5() => new TextSprite(inventory, 573, 117, 8, 8);
        public ISprite Create6() => new TextSprite(inventory, 582, 117, 8, 8);
        public ISprite Create7() => new TextSprite(inventory, 591, 117, 8, 8);
        public ISprite Create8() => new TextSprite(inventory, 600, 117, 8, 8);
        public ISprite Create9() => new TextSprite(inventory, 609, 117, 8, 8);
    }
}
