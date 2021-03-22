using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class ABox : ISprite
    {
        private readonly ISprite bBoxSprite;
        public ISprite CurrItem { get; set; }

        public ABox()
        {
            bBoxSprite = HUDTextureFactory.Instance.CreateABox();
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            bBoxSprite.Draw(spriteBatch, vector);
        }
    }
}
