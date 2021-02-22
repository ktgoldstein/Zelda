using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public interface ILinkState
    {
        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public Direction Action();
        public Tuple<LinkStateType, int> GetState();
        public void Draw(SpriteBatch spriteBatch);
        public void Update();
    }
}
