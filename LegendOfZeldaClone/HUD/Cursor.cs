using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class Cursor : ISprite
    {
        private readonly ISprite cursorSprite;
        private readonly GameStateMachine game;
        private int animationSpeed;

        public Cursor(GameStateMachine game)
        {
            cursorSprite = HUDTextureFactory.Instance.CreateCursor();
            this.game = game;
            animationSpeed = 0;
        }

        public void Update()
        {
            animationSpeed++;
            if (animationSpeed % 2 == 0)
                cursorSprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            cursorSprite.Draw(spriteBatch, vector);
        }
    }
}
