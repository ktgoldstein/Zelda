using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkUsingItemDown : ILinkState
    {
        private readonly ILinkPlayer linkPlyer;
        private readonly ILinkSprite linkSprite;

        public LinkUsingItemDown(ILinkPlayer link, int frame = 0)
        {
            this.linkPlyer = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkUsingItemDownSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public Direction Action() => Direction.None;
        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.UsingItemDown, linkSprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => linkSprite.Draw(spriteBatch, linkPlyer.Location);

        public void Update()
        {
            linkSprite.Update();
            if (linkSprite.AnimationDone())
                linkPlyer.SetState(linkPlyer.GetStateStandingDown());
        }
    }
}
