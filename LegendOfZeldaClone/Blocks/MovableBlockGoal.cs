using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public class MovableBlockGoal : BlockKernel
    {
        public MovableBlockGoal(Vector2 location, int height, int width, ObjectHeight objectHeight)
            : base(location, null, height, width, objectHeight, false, false) {
        }

        public override void Draw(SpriteBatch spriteBatch) {}
        public override void DrawAt(SpriteBatch spriteBatch, Vector2 location) {}
    }
}
