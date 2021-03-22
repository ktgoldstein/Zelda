using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LegendOfZeldaClone
{
    public class LevelName : ISprite
    {
        private readonly ISprite levelNameSprite;
        private readonly ISprite oneSprite;

        public LevelName()
        {
            levelNameSprite = HUDTextureFactory.Instance.CreateLevelName();
            oneSprite = HUDTextureFactory.Instance.Create1();
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            levelNameSprite.Draw(spriteBatch, vector);
            vector.X += LoZHelpers.Scale(48);
            oneSprite.Draw(spriteBatch, vector);
        }
    }
}
