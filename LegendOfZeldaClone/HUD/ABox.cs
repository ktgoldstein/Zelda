using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class ABox : ISprite
    {
        private readonly ISprite bBoxSprite;
        private readonly ISprite currItem;
        private readonly Vector2 currItemLocation;

        public ABox()
        {
            bBoxSprite = HUDTextureFactory.Instance.CreateABox();
            currItem = HUDTextureFactory.Instance.CreateInventorySword();
            currItemLocation = LoZHelpers.ABoxItemLocation;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            bBoxSprite.Draw(spriteBatch, vector);
            currItem.Draw(spriteBatch, currItemLocation);
        }
    }
}
