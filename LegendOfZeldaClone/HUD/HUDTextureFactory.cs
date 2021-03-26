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
        public ISprite CreateLevelName() => new InventorySprite(inventory, 584, 1, 48, 8);
        public ISprite CreateRupeeCount() => new InventorySprite(inventory, 346, 27, 8, 8);
        public ISprite CreateKeyCount() => new InventorySprite(inventory, 346, 43, 8, 8);
        public ISprite CreateBombCount() => new InventorySprite(inventory, 346, 51, 8, 8);
        public ISprite CreateX() => new InventorySprite(inventory, 519, 117, 8, 8);
        public ISprite CreateNumber(int number)
        {
            return number switch
            {
                1 => new InventorySprite(inventory, 537, 117, 8, 8),
                2 => new InventorySprite(inventory, 546, 117, 8, 8),
                3 => new InventorySprite(inventory, 555, 117, 8, 8),
                4 => new InventorySprite(inventory, 564, 117, 8, 8),
                5 => new InventorySprite(inventory, 573, 117, 8, 8),
                6 => new InventorySprite(inventory, 582, 117, 8, 8),
                7 => new InventorySprite(inventory, 591, 117, 8, 8),
                8 => new InventorySprite(inventory, 600, 117, 8, 8),
                9 => new InventorySprite(inventory, 609, 117, 8, 8),
                _ => new InventorySprite(inventory, 528, 117, 8, 8),
            };
        }
        public ISprite CreateBBox() => new InventorySprite(inventory, 381, 27, 18, 29);
        public ISprite CreateABox() => new InventorySprite(inventory, 405, 27, 18, 29);
        public ISprite CreateLifeText() => new InventorySprite(inventory, 434, 27, 64, 16);
        public ISprite CreateFullHealthHeart() => new InventorySprite(inventory, 645, 117, 8, 8);
        public ISprite CreateHalfHealthHeart() => new InventorySprite(inventory, 636, 117, 8, 8);
        public ISprite CreateNoHealthHeart() => new InventorySprite(inventory, 627, 117, 8, 8);
        public ISprite CreateInventorySword() => new InventorySprite(inventory, 555, 137, 8, 16);
        public ISprite CreateInventoryBox() => new InventorySprite(inventory, 1, 11, 123, 88);
        public ISprite CreateInventorySelectionBox() => new InventorySprite(inventory, 124, 11, 99, 88);
    }
}
