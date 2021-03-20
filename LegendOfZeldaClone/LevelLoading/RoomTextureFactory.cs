using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace LegendOfZeldaClone.LevelLoading
{
    class RoomTextureFactory
    {
        private Texture2D tiles;
        private Texture2D walls;
        private Texture2D miniMap;
        
        public static RoomTextureFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private static RoomTextureFactory instance = new RoomTextureFactory();

        private RoomTextureFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            tiles = content.Load<Texture2D>("Background");
            walls = content.Load<Texture2D>("Background");
            miniMap = content.Load<Texture2D>("LevelLoading\\Level 1");
        }

        public ISprite CreateMiniMap() => new MapSprite(miniMap, 1, 1, 1);
        public ISprite CreateWalls() => new BackgroundSprite(walls, 522, 11, 256, 176);
        public ISprite CreateTiles() => new BackgroundSprite(tiles, 2, 192, 192, 112);
    }
}
