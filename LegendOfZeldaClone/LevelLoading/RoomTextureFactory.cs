using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace LegendOfZeldaClone.LevelLoading
{
    class RoomTextureFactory
    {

        private Texture2D tiles;
        private Texture2D background;

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
            background = content.Load<Texture2D>("Background");
        }

        public ISprite CreateTiles() => new BackgroundSprite(tiles, 2, 192, 192, 112);
        public ISprite CreateWalls() => new BackgroundSprite(background, 522, 11, 256, 176);
    }
}
