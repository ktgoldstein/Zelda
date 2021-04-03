using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class ABox : ISprite
    {
        private readonly ISprite bBoxSprite;
        private readonly ISprite currItem;
        private GameStateMachine game;

        public ABox(GameStateMachine game)
        {
            bBoxSprite = HUDTextureFactory.Instance.CreateABox();
            currItem = HUDTextureFactory.Instance.CreateInventorySword();
            this.game = game;
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch, Vector2 vector)
        {
            bBoxSprite.Draw(spriteBatch, vector);
            if (game.CurrentGameState == GameState.Play)
                currItem.Draw(spriteBatch, LoZHelpers.ABoxItemLocation);
            else
                currItem.Draw(spriteBatch, LoZHelpers.ABoxItemPauseLocation);
        }
    }
}
