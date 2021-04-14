using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class MovableBlockGoal : BlockKernel
    {
        private ISprite test;
        public MovableBlockGoal(Vector2 location, int height, int width, ObjectHeight objectHeight)
            : base(location, null, height, width, objectHeight, false, false) {
            test = BlockSpriteFactory.Instance.CreateDarkBlock();
        }

        public override void Draw(SpriteBatch spriteBatch) { test.Draw(spriteBatch, Location); }
        public override void DrawAt(SpriteBatch spriteBatch, Vector2 location) { test.Draw(spriteBatch, location); }
    }
}
