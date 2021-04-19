using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkStandingLeft : ILinkState
    {
        private readonly ILinkPlayer linkPlayer;
        private readonly ILinkSprite linkSprite;

        public Direction BlockingDirection { get { return Direction.Left; } }

        public LinkStandingLeft(ILinkPlayer link, int frame = 0)
        {
            linkPlayer = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkStandingLeftSprite(link.SkinType, frame);
        }

        public void MoveUp() => linkPlayer.SetState(linkPlayer.GetStateWalkingingUp());
        public void MoveDown() => linkPlayer.SetState(linkPlayer.GetStateWalkingingDown());
        public void MoveLeft() => linkPlayer.SetState(linkPlayer.GetStateWalkingingLeft());
        public void MoveRight() => linkPlayer.SetState(linkPlayer.GetStateWalkingingRight());
        public void Action() => linkPlayer.SetState(linkPlayer.GetStateUsingItemLeft());
        public void PickUpItem(IItem item) => linkPlayer.SetState(linkPlayer.GetStatePickingUpItem(item));
        public void Die() => linkPlayer.SetState(linkPlayer.GetStateDying());
        public void PickUpTriforce(IItem triforce) => linkPlayer.SetState(linkPlayer.GetStatePickingUpTriforce(triforce));
        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.StandingLeft, linkSprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => linkSprite.Draw(spriteBatch, linkPlayer.Location);
        public void Update() => linkSprite.Update();
        public void Charge() { }
    }
}
