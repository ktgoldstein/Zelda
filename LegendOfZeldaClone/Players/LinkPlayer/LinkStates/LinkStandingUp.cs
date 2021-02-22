using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkStandingUp : ILinkState
    {
        private readonly ILinkPlayer linkPlayer;
        private readonly ILinkSprite linkSprite;

        public LinkStandingUp(ILinkPlayer link, int frame = 0)
        {
            this.linkPlayer = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkStandingUpSprite(link.SkinType, frame);
        }

        public void MoveUp() => linkPlayer.SetState(linkPlayer.GetStateWalkingingUp());
        public void MoveDown() => linkPlayer.SetState(linkPlayer.GetStateWalkingingDown());
        public void MoveLeft() => linkPlayer.SetState(linkPlayer.GetStateWalkingingLeft());
        public void MoveRight() => linkPlayer.SetState(linkPlayer.GetStateWalkingingRight());
        
        public Direction Action()
        {
            linkPlayer.SetState(linkPlayer.GetStateUsingItemUp());
            return Direction.Up;
        }

        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.StandingUp, linkSprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => linkSprite.Draw(spriteBatch, linkPlayer.Location);
        public void Update() => linkSprite.Update();
    }
}
