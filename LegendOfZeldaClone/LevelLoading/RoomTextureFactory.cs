using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace LegendOfZeldaClone.LevelLoading
{
    class RoomTextureFactory
    {
        private Texture2D tiles;
        private Texture2D walls;
        private Texture2D miniMap;
        private Texture2D text;
        
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
            text = content.Load<Texture2D>("Background");
        }

        public ISprite CreateMiniMap() => new MapSprite(miniMap, 1, 1, 1);
        public ISprite CreateWalls() => new BackgroundSprite(walls, 522, 11, 256, 176);
        public ISprite CreateTiles() => new BackgroundSprite(tiles, 2, 192, 192, 112);
        public ISprite CreateL() => new TextSprite(text, 83, 19, 6, 7);
        public ISprite CreateE() => new TextSprite(text, 58, 11, 7, 7);
        public ISprite CreateV() => new TextSprite(text, 122, 19, 7, 7);
        public ISprite CreateDash() => new TextSprite(text, 58, 38, 6, 1);
        public ISprite CreateOne() => new TextSprite(text, 3, 19, 6, 7);
    }
}
