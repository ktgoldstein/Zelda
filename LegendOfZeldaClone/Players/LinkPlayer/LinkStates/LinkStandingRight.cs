using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkStandingRight : ILinkState
    {
        private readonly ILinkPlayer linkPlayer;
        private readonly ILinkSprite linkSprite;

        public LinkStandingRight(ILinkPlayer link, int frame = 0)
        {
            this.linkPlayer = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkStandingRightSprite(link.SkinType, frame);
        }

        public void MoveUp() => linkPlayer.SetState(linkPlayer.GetStateWalkingingUp());
        public void MoveDown() => linkPlayer.SetState(linkPlayer.GetStateWalkingingDown());
        public void MoveLeft() => linkPlayer.SetState(linkPlayer.GetStateWalkingingLeft());
        public void MoveRight() => linkPlayer.SetState(linkPlayer.GetStateWalkingingRight());

        public Direction Action()
        {
            linkPlayer.SetState(linkPlayer.GetStateUsingItemRight());
            return Direction.Right;
        }

        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.StandingRight, linkSprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => linkSprite.Draw(spriteBatch, linkPlayer.Location);
        public void Update() => linkSprite.Update();
    }
}
