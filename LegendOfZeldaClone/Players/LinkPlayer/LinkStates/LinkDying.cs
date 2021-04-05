using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkDying : ILinkState
    {
        private readonly ILinkPlayer linkPlayer;
        private readonly ILinkSprite linkSprite;

        public Direction BlockingDirection { get { return Direction.None; } }

        public LinkDying(ILinkPlayer link, int frame = 0)
        {
            linkPlayer = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkDyingSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void Action() { }
        public void PickUpItem(IItem item) { }
        public void PickUpTriforce(IItem triforce) { }
        public void Die() { }
        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.Dying, linkSprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch)
        {
            linkSprite.Draw(spriteBatch, linkPlayer.Location);
        }

        public void Update()
        {
            linkSprite.Update();
        }
    }
}
