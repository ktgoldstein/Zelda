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
            rupeeCountSprite = HUDTextureFactory.Instance.CreateRupeeCount();
            keyCountSprite = HUDTextureFactory.Instance.CreateBombCount();
            bombCountSprite = HUDTextureFactory.Instance.CreateBombCount();
            xSprite = HUDTextureFactory.Instance.CreateX();
            zeroSprite = HUDTextureFactory.Instance.Create0();
            oneSprite = HUDTextureFactory.Instance.Create1();
            twoSprite = HUDTextureFactory.Instance.Create2();
            threeSprite = HUDTextureFactory.Instance.Create3();
            fourSprite = HUDTextureFactory.Instance.Create4();
            fiveSprite = HUDTextureFactory.Instance.Create5();
            sixSprite = HUDTextureFactory.Instance.Create6();
            sevenSprite = HUDTextureFactory.Instance.Create7();
            eightSprite = HUDTextureFactory.Instance.Create8();
            nineSprite = HUDTextureFactory.Instance.Create9();
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            
        }
    }
}
