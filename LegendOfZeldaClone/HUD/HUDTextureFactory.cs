using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace LegendOfZeldaClone
{
    class HUDTextureFactory
    {
        private Texture2D miniMap;
        private Texture2D pauseMap;
        private Texture2D addRoomOnMap;
        private Texture2D inventory;
        private Texture2D locationTracker;
        private Texture2D triForceIndicator;

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
            miniMap = content.Load<Texture2D>("HUD\\Level 1 (Blank)");
            pauseMap = content.Load<Texture2D>("HUD\\PauseMap");
            addRoomOnMap = content.Load<Texture2D>("HUD\\Map Rooms");
            locationTracker = content.Load<Texture2D>("HUD\\Link Room Tracker");
            triForceIndicator = content.Load<Texture2D>("HUD\\TriForceFlash");
            inventory = content.Load<Texture2D>("LoZInventorySpriteSheet");
        }

        public ISprite CreateMiniMap() => new MapSprite(miniMap, 1, 1, 1);
        public ISprite CreatePauseMap() => new PauseMapSprite(pauseMap, 5, 0, 128, 79);
        public ISprite CreatePauseMapRooms(PauseMapRoomType roomType)
        {
            return roomType switch
            {
                PauseMapRoomType.NoRooms => new PauseMapSprite(addRoomOnMap, 0, 0, 8, 8),
                PauseMapRoomType.RoomR => new PauseMapSprite(addRoomOnMap, 9, 0, 8, 8),
                PauseMapRoomType.RoomL => new PauseMapSprite(addRoomOnMap, 18, 0, 8, 8),
                PauseMapRoomType.RoomLR => new PauseMapSprite(addRoomOnMap, 27, 0, 8, 8),
                PauseMapRoomType.RoomD => new PauseMapSprite(addRoomOnMap, 36, 0, 8, 8),
                PauseMapRoomType.RoomDR => new PauseMapSprite(addRoomOnMap, 45, 0, 8, 8),
                PauseMapRoomType.RoomDL => new PauseMapSprite(addRoomOnMap, 54, 0, 8, 8),
                PauseMapRoomType.RoomDLR => new PauseMapSprite(addRoomOnMap, 63, 0, 8, 8),
                PauseMapRoomType.RoomU => new PauseMapSprite(addRoomOnMap, 72, 0, 8, 8),
                PauseMapRoomType.RoomUR => new PauseMapSprite(addRoomOnMap, 81, 0, 8, 8),
                PauseMapRoomType.RoomUL => new PauseMapSprite(addRoomOnMap, 90, 0, 8, 8),
                PauseMapRoomType.RoomULR => new PauseMapSprite(addRoomOnMap, 99, 0, 8, 8),
                PauseMapRoomType.RoomUD => new PauseMapSprite(addRoomOnMap, 108, 0, 8, 8),
                PauseMapRoomType.RoomUDR => new PauseMapSprite(addRoomOnMap, 117, 0, 8, 8),
                PauseMapRoomType.RoomUDL => new PauseMapSprite(addRoomOnMap, 126, 0, 8, 8),
                PauseMapRoomType.AllRooms => new PauseMapSprite(addRoomOnMap, 135, 0, 8, 8),
            };
        }
        public ISprite CreateLocationTracker() => new MapSprite(locationTracker, 1, 1, 1);
        public ISprite CreateTriForceIndicator() => new MapSprite(triForceIndicator, 2, 1, 2);
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
        public ISprite CreateInventorySelectionBox() => new InventorySprite(inventory, 1, 11, 123, 88);
        public ISprite CreateInventoryBox() => new InventorySprite(inventory, 124, 11, 99, 88);
        public ISprite CreateInventoryRing() => new InventorySprite(inventory, 549, 156, 8, 16);
        public ISprite CreateInventoryBoomerang() => new InventorySprite(inventory, 584, 137, 8, 16);
        public ISprite CreateInventoryBomb() => new InventorySprite(inventory, 604, 137, 8, 16);
        public ISprite CreateInventoryBow() => new InventorySprite(inventory, 633, 137, 8, 16);
        public ISprite CreateInventoryArrow() => new InventorySprite(inventory, 615, 137, 8, 16);
        public ISprite CreateInventoryCandle() => new InventorySprite(inventory, 644, 137, 8, 16);
        public ISprite CreateInventoryPotion() => new InventorySprite(inventory, 695, 137, 8, 16);
        public ISprite CreateInventoryMap() => new InventorySprite(inventory, 601, 156, 8, 16);
        public ISprite CreateInventoryCompass() => new InventorySprite(inventory, 612, 156, 15, 16);
        public ISprite CreateMapCompassHolder() => new InventorySprite(inventory, 258, 112, 80, 88);
        public ISprite CreateCursor() => new AnimatedInventorySprite(inventory, 536, 137, 16, 16);
    }
}
