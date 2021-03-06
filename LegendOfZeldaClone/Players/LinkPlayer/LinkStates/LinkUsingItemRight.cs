using LegendOfZeldaClone.Players.LinkPlayer.LinkStates;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkUsingItemRight : ILinkState
    {
        private readonly ILinkPlayer linkPlayer;
        private readonly ILinkSprite linkSprite;

        public Direction BlockingDirection { get { return Direction.None; } }

        public LinkUsingItemRight(ILinkPlayer link, int frame = 0)
        {
            linkPlayer = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkUsingItemRightSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void Action() { }
        public void Charge() => linkPlayer.SetState(new LinkChargeState(linkPlayer, 1));
        public void PickUpItem(IItem item) => linkPlayer.SetState(linkPlayer.GetStatePickingUpItem(item));
        public void PickUpTriforce(IItem triforce) => linkPlayer.SetState(linkPlayer.GetStatePickingUpTriforce(triforce));
        public void Die() => linkPlayer.SetState(linkPlayer.GetStateDying());
        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.UsingItemRight, linkSprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => linkSprite.Draw(spriteBatch, linkPlayer.Location);

        public void Update()
        {
            linkSprite.Update();
            if (linkSprite.AnimationDone())
                linkPlayer.SetState(linkPlayer.GetStateStandingRight());
        }
    }
}
