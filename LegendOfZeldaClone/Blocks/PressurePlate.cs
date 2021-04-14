using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class PressurePlate : BlockKernel
    {
        private readonly GameStateMachine game;

        public PressurePlate(Vector2 location, ISprite sprite, int height, int width, ObjectHeight objectHeight, GameStateMachine game, int oversize) 
            : base(location, sprite, height, width, objectHeight, false, false)
        {
            this.game = game;
            Location = location - LoZHelpers.Scale(oversize) * Vector2.One;
            base.height += + oversize * 2;
            base.width += oversize * 2;
        }

        public override void Draw(SpriteBatch spriteBatch) { }
        public override void DrawAt(SpriteBatch spriteBatch, Vector2 location) { }
        public void CloseDoors()
        {
            game.CurrentRoom.CloseDoors();
        }
    }
}
