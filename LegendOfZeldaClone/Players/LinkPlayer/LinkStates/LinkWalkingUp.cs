using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZeldaClone
{
    public class LinkWalkingUp : ILinkState
    {
        private readonly ILinkPlayer linkPlayer;
        private readonly ILinkSprite linkSprite;

        public Direction BlockingDirection { get { return Direction.Up; } }

        public LinkWalkingUp(ILinkPlayer link, int frame = 0)
        {
            linkPlayer = link;
            linkSprite = LinkSpriteFactory.Instance.CreateLinkWalkingUpSprite(link.SkinType, frame);
        }

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void Charge() { }
        public void Action() => linkPlayer.SetState(linkPlayer.GetStateUsingItemUp());
        public void PickUpItem(IItem item) => linkPlayer.SetState(linkPlayer.GetStatePickingUpItem(item));
        public void PickUpTriforce(IItem triforce) => linkPlayer.SetState(linkPlayer.GetStatePickingUpTriforce(triforce));
        public void Die() => linkPlayer.SetState(linkPlayer.GetStateDying());
        public Tuple<LinkStateType, int> GetState() => Tuple.Create(LinkStateType.WalkingUp, linkSprite.CurrentFrame);
        public void Draw(SpriteBatch spriteBatch) => linkSprite.Draw(spriteBatch, linkPlayer.Location);

        public void Update()
        {
            linkPlayer.Location -= new Vector2(0, linkPlayer.Speed);
            linkSprite.Update();
            int linkAlignment = ((int)linkPlayer.Location.Y - LoZHelpers.HUDHeight) % LoZHelpers.Scale(8);
            if (linkSprite.AnimationDone() || linkAlignment == 0)
                linkPlayer.SetState(linkPlayer.GetStateStandingUp());
            else if (linkAlignment % 2 == 1 || linkAlignment % 2 == -1)
                linkPlayer.Location -= new Vector2(0, LoZHelpers.Scale(1));
        }
    }
}
