using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class BombCount : ISprite
    {
        private readonly ISprite bombCountSprite;
        private readonly ISprite xSprite;
        private ISprite numberSprite;

        public BombCount()
        {
            bombCountSprite = HUDTextureFactory.Instance.CreateBombCount();
            xSprite = HUDTextureFactory.Instance.CreateX();
            numberSprite = HUDTextureFactory.Instance.CreateNumber(0);
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            bombCountSprite.Draw(spriteBatch, vector);
            vector.X += LoZHelpers.Scale(8);
            xSprite.Draw(spriteBatch, vector);
            vector.X += LoZHelpers.Scale(8);
            numberSprite.Draw(spriteBatch, vector);
        }
    }
}
