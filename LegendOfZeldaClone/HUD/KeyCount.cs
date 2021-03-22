using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class KeyCount : ISprite
    {
        private readonly ISprite keyCountSprite;
        private readonly ISprite xSprite;
        private ISprite numberSprite;

        public KeyCount()
        {
            keyCountSprite = HUDTextureFactory.Instance.CreateKeyCount();
            xSprite = HUDTextureFactory.Instance.CreateX();
            numberSprite = HUDTextureFactory.Instance.Create0();
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            keyCountSprite.Draw(spriteBatch, vector);
            vector.X += LoZHelpers.Scale(8);
            xSprite.Draw(spriteBatch, vector);
            vector.X += LoZHelpers.Scale(8);
            numberSprite.Draw(spriteBatch, vector);
        }
    }
}
