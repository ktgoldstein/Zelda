using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public interface ILinkState
    {
        public Direction BlockingDirection { get; }
        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
        public void Action();
        public void PickUpItem(IItem item);
        public Tuple<LinkStateType, int> GetState();
        public void Draw(SpriteBatch spriteBatch);
        public void Update();
    }
}
