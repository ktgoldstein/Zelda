using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    class RKBCount : ISprite
    {
        private readonly ISprite rupeeCountSprite;
        private readonly ISprite keyCountSprite;
        private readonly ISprite bombCountSprite;
        private readonly ISprite xSprite;
        private readonly ISprite zeroSprite;
        private readonly ISprite oneSprite;
        private readonly ISprite twoSprite;
        private readonly ISprite threeSprite;
        private readonly ISprite fourSprite;
        private readonly ISprite fiveSprite;
        private readonly ISprite sixSprite;
        private readonly ISprite sevenSprite;
        private readonly ISprite eightSprite;
        private readonly ISprite nineSprite;
        private readonly int space1 = 8;

        public RKBCount()
        {
            rupeeCountSprite = LevelLoading.HUDTextureFactory.Instance.CreateRupeeCount();

            bombCountSprite = LevelLoading.HUDTextureFactory.Instance.CreateBombCount();
            xSprite = LevelLoading.RoomTextureFactory.Instance.CreateX();
            zeroSprite = LevelLoading.RoomTextureFactory.Instance.Create0();
            oneSprite = LevelLoading.RoomTextureFactory.Instance.Create1();
            twoSprite = LevelLoading.RoomTextureFactory.Instance.Create2();
            threeSprite = LevelLoading.RoomTextureFactory.Instance.Create3();
            fourSprite = LevelLoading.RoomTextureFactory.Instance.Create4();
            fiveSprite = LevelLoading.RoomTextureFactory.Instance.Create5();
            sixSprite = LevelLoading.RoomTextureFactory.Instance.Create6();
            sevenSprite = LevelLoading.RoomTextureFactory.Instance.Create7();
            eightSprite = LevelLoading.RoomTextureFactory.Instance.Create8();
            nineSprite = LevelLoading.RoomTextureFactory.Instance.Create9();
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            
        }
    }
}
