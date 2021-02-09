using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZeldaClone
{
    public interface ILinkState
    {
        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public void Action();
        public int Damage(int amount);
        public void Draw(SpriteBatch spriteBatch, Vector2 location);
        public void Update(Vector2 location);
    }

    public class LinkNormalStandingDown : ILinkState
    {

    }

    // Simon edit after this comment

}
