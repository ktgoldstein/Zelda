using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class LifeText : ISprite
    {
        private readonly ISprite lifeTextSprite;

        public LifeText()
        {
            lifeTextSprite = HUDTextureFactory.Instance.CreateLifeText();
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            lifeTextSprite.Draw(spriteBatch, vector);
        }
    }
}
