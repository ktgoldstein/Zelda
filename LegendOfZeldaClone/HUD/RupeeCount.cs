using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class RupeeCount : ISprite
    {
        private readonly ISprite rupeeCountSprite;
        private readonly ISprite xSprite;
        private ISprite numberSprite;

        public RupeeCount()
        {
            rupeeCountSprite = HUDTextureFactory.Instance.CreateRupeeCount();
            xSprite = HUDTextureFactory.Instance.CreateX();
            numberSprite = HUDTextureFactory.Instance.Create0();
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            rupeeCountSprite.Draw(spriteBatch, vector);
            vector.X += LoZHelpers.Scale(8);
            xSprite.Draw(spriteBatch, vector);
            vector.X += LoZHelpers.Scale(8);
            numberSprite.Draw(spriteBatch, vector);
        }
    }
}
